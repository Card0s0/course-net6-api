using Microsoft.AspNetCore.Mvc;
using ModelInterface.Services.Interfaces;

namespace ModelInterface.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonController : ControllerBase
{

    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService personService;

    public PersonController(
        ILogger<PersonController> logger,
        IPersonService personService)
    {
        _logger = logger;
        this.personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var persons = this.personService.FindAll();
        if (!persons.Any())
        {
            return NotFound();
        }
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = this.personService.FindById(id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person is null)
        {
            return BadRequest();
        }

        return Ok(this.personService.Create(person));
    }


    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person is null)
        {
            return BadRequest();
        }

        return Ok(this.personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        this.personService.Delete(id);
        return NoContent();
    }

}
