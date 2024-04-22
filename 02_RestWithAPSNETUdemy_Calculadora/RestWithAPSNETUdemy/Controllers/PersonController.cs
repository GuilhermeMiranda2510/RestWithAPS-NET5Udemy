using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAPSNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //{
            //    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //    return Ok(sum.ToString());
            //}

            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            //if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //{
            //    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //    return Ok(sum.ToString());
            //}

            var person = _personService.FindByID(id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }   
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //{
            //    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //    return Ok(sum.ToString());
            //}

            _personService.Delete(id);
            return NoContent();
        }


        //[HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        //public IActionResult SubTraction(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        //public IActionResult MutiplicationTraction(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("division/{firstNumber}/{secondNumber}")]
        //public IActionResult DivisionTraction(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}



        //[HttpGet("mean/{firstNumber}/{secondNumber}")]
        //public IActionResult Mean(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) /2;
        //        return Ok(sum.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("square-root/{firstNumber}")]
        //public IActionResult SquareRoot(string firstNumber)
        //{
        //    if (IsNumeric(firstNumber))
        //    {
        //        var squareroot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        //        return Ok(squareroot.ToString());
        //    }

        //    return BadRequest("Invalid Input");
        //}

        //private bool IsNumeric(string strNumber)
        //{

        //    double number;
        //    bool isNumber = double.TryParse(strNumber,System.Globalization.NumberStyles.Any, 
        //                                    System.Globalization.NumberFormatInfo.InvariantInfo,out number);

        //    return isNumber;


        //    throw new NotImplementedException();
        //}

        //private decimal ConvertToDecimal(string strNumber)
        //{
        //    decimal decimalValue;
        //    if(decimal.TryParse(strNumber, out decimalValue))
        //    {
        //        return decimalValue;
        //    }
        //    return 0;
        //}


    }
}
