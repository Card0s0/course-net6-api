using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    [HttpGet("sum/{primaryParam}/{secondParam}")]
    public IActionResult Addition(string primaryParam, string secondParam)
    {
        try
        {
            return Ok(this.MainCalculate(Operation.Sum, primaryParam, secondParam));
        }
        catch
        {
            return BadRequest("Input Invalid");
        }
    }

    [HttpGet("sub/{primaryParam}/{secondParam}")]
    public IActionResult Subtract(string primaryParam, string secondParam)
    {
        try
        {
            return Ok(this.MainCalculate(Operation.Subtract, primaryParam, secondParam));
        }
        catch
        {
            return BadRequest("Input Invalid");
        }
    }

    [HttpGet("mul/{primaryParam}/{secondParam}")]
    public IActionResult Multiply(string primaryParam, string secondParam)
    {
        try
        {
            return Ok(this.MainCalculate(Operation.Multiply, primaryParam, secondParam));
        }
        catch
        {
            return BadRequest("Input Invalid");
        }
    }

    [HttpGet("div/{primaryParam}/{secondParam}")]
    public IActionResult Divide(string primaryParam, string secondParam)
    {
        try
        {
            return Ok(this.MainCalculate(Operation.Divide, primaryParam, secondParam));
        }
        catch
        {
            return BadRequest("Input Invalid");
        };
    }

    [HttpGet("ave/{primaryParam}/{secondParam}")]
    public IActionResult Average(string primaryParam, string secondParam)
    {
        try
        {
            return Ok(this.MainCalculate(Operation.Average, primaryParam, secondParam));
        }
        catch
        {
            return BadRequest("Input Invalid");
        }
    }

    private decimal MainCalculate(Operation operation,
                                  string param1,
                                  string param2)
    {

        if (IsNumeric(param1) && IsNumeric(param2))
        {
            switch (operation)
            {
                case Operation.Sum:
                    return ConvertToDecimal(param1) + ConvertToDecimal(param2);

                case Operation.Divide:
                    return ConvertToDecimal(param1) / ConvertToDecimal(param2);

                case Operation.Subtract:
                    return ConvertToDecimal(param1) - ConvertToDecimal(param2);

                case Operation.Multiply:
                    return ConvertToDecimal(param1) * ConvertToDecimal(param2);

                case Operation.Average:
                    return (this.MainCalculate(Operation.Divide, (this.MainCalculate(Operation.Sum, param1, param2).ToString()), 2.ToString()));

                case Operation.Square:
                default:
                    return 0;

            }
             ;
        }

        throw new Exception("invalid");
    }

    private decimal ConvertToDecimal(string value)
    {
        var decimalResult = 0M;
        decimal.TryParse(value, out decimalResult);

        return decimalResult;
    }

    private bool IsNumeric(string value)
    {
        double doubleValue = 0;

        var isNumeric = double.TryParse(value, out doubleValue);

        if (isNumeric)
        {
            return true;
        }

        return false;
    }

    public enum Operation
    {
        Sum = 0,
        Subtract = 1,
        Multiply = 2,
        Divide = 3,
        Average = 4,
        Square = 5
    }
}
