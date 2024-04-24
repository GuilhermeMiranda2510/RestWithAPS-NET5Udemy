using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAPSNETUdemy.Model;
using RestWithAPSNETUdemy.Business;

namespace RestWithAPSNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //{
            //    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //    return Ok(sum.ToString());
            //}

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            //if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //{
            //    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //    return Ok(sum.ToString());
            //}

            var person = _personBusiness.FindByID(id);

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

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest();
            }

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            //{
            //    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            //    return Ok(sum.ToString());
            //}

            _personBusiness.Delete(id);
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
