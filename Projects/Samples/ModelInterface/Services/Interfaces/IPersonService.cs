using ModelInterface.Controllers;

namespace ModelInterface.Services.Interfaces;

public interface IPersonService
{
    Person Create(Person person);

    Person FindById(long id);

    Person Update(Person person);

    IEnumerable<Person> FindAll();

    void Delete(long id);
}
