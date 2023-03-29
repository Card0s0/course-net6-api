using Microsoft.AspNetCore.Mvc;
using ModelInterface.Services.Interfaces;

namespace ModelInterface.Controllers;

[ApiController]
[Route("[controller]")]
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
    public IEnumerable<Person> FindllPerson()
    {
        return this.personService.FindAll();
    }

    [HttpGet("{id}")]
    public Person FindByIdPerson(long id)
    {
        return this.personService.FindById(id);
    }

    [HttpPost(Name = "CreatePerson")]
    public Person CreatePerson([FromBody] Person person)
    {
        return this.personService.Create(person);
    }


    [HttpPut(Name = "UpdatePerson")]
    public Person UpdatePerson([FromBody] Person person)
    {
        return this.personService.Update(person);
    }

    [HttpDelete("{id}")]
    public void DeletePerson(long id)
    {
        this.personService.Delete(id);
    }

}
