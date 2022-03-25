using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tax.API.Application.Queries.Interfaces;
using Tax.API.Application.ViewModels;
using Tax.Infrastructure.Dtos;
using Tax.Infrastructure.Exceptions;

namespace Tax.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [OpenApiTag("Tax Calculator Service", Description = "Endpoints exposed to calculate tax")]
    public class TaxCalculatorController : Controller
    {
        private readonly ICalculateTaxQuery _calculateTaxQuery;
        private readonly IGetTaxRateByLocationQuery _getTaxRateByLocationQuery;
        public TaxCalculatorController(ICalculateTaxQuery calculateTaxQuery, IGetTaxRateByLocationQuery getTaxRateByLocationQuery)
        {
            _calculateTaxQuery = calculateTaxQuery;
            _getTaxRateByLocationQuery = getTaxRateByLocationQuery;
        }

        [HttpPost]
        [Route("calculatetax")]
        [ProducesResponseType(typeof(SalesTaxViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<SalesTaxViewModel>> CalculateTaxAsync([FromHeader] int customerId, [FromBody] SalesTaxRequest request)
        {
            var taxViewModel = new SalesTaxViewModel();

            if (request == null)
            {
                return BadRequest("Request body must be provided!");
            }

            try
            {
                taxViewModel = await _calculateTaxQuery.CalculateTaxAsync(customerId, request);
            }
            catch(EmptyCustomerException ex)
            {
                //Write logs and do cool stuff here
                Console.WriteLine(ex.ErrorMessage);
                return Problem(title: "Internal Exception Occurred!", detail: ex.ErrorMessage, statusCode: 500);
            }
            catch (CalculateTaxException ex)
            {
                //Write logs and do cool stuff here
                Console.WriteLine(ex.ErrorMessage);
                return Problem(title: "Internal Exception Occurred!", detail: ex.ErrorMessage, statusCode: 500);
            }
            catch (Exception ex)
            {
                //Write logs and do cool stuff here
                Console.WriteLine(ex.Message);
                return Problem(title: "Internal Exception Occurred!", detail: ex.Message, statusCode: 500);
            }

            return Ok(taxViewModel);
        }

        [HttpGet]
        [Route("taxratebylocation")]
        [ProducesResponseType(typeof(TaxRateViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<TaxRateViewModel>> GetTaxRateByLocationAsync([FromHeader] int customerId, [FromQuery] string zip)
        {
            var taxRateViewModel = new TaxRateViewModel();

            if (string.IsNullOrEmpty(zip) || customerId <= 0)
            {
                return BadRequest("CustomerId and Zip must be provided!");
            }

            try
            {
                taxRateViewModel = await _getTaxRateByLocationQuery.GetTaxRateByLocationAsync(customerId, zip);
            }
            catch (EmptyCustomerException ex)
            {
                //Write logs and do cool stuff here
                Console.WriteLine(ex.ErrorMessage);
                return Problem(title: "Internal Exception Occurred!", detail: ex.ErrorMessage, statusCode: 500);
            }
            catch (TaxRateLocationException ex)
            {
                //Write logs and do cool stuff here
                Console.WriteLine(ex.ErrorMessage);
                return Problem(title: "Internal Exception Occurred!", detail: ex.ErrorMessage, statusCode: 500);
            }
            catch (Exception ex)
            {
                //Write logs and do cool stuff here
                Console.WriteLine(ex.Message);
                return Problem(title: "Internal Exception Occurred!", detail: ex.Message, statusCode: 500);
            }

            return Ok(taxRateViewModel);
        }
    }
}
