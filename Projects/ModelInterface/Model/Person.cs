namespace ModelInterface.Controllers;

public class Person
{
    public Person(
        long id,
        string firstName,
        string lastName,
        string address,
        string gender)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Address = address;
        this.Gender = gender;
    }

    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string Gender { get; set; }

}