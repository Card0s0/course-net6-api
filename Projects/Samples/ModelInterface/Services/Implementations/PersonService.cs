using ModelInterface.Controllers;
using ModelInterface.Services.Interfaces;

namespace ModelInterface.Services.Implementations;

public class PersonService : IPersonService
{
    public volatile int count;

    public Person Create(Person person)
    {
        return person;
    }

    public void Delete(long id)
    {

    }

    public IEnumerable<Person> FindAll()
    {
        IList<Person> persons = new List<Person>();
        for (var i = 0; i < 8; i++)
        {
            Person person = MockPerson(i);
            persons.Add(person);
        }
        return persons;
    }


    public Person FindById(long id) => new Person(
        id,
        "Anderson",
        "Cardoso",
        "Lisboa",
        "M");

    public Person Update(Person person)
    {
        return person;
    }

    private Person MockPerson(int i)
    {
        return new Person(IncrementAndGet(), $"FirstName {i}", $"LastName {i}", $"Address N{i}", "M");
    }

    private long IncrementAndGet()
    {
        return Interlocked.Increment(ref count);
    }
}