
namespace ToDo;
public class Person
{
    // Auto-properties

    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Constructor
    public Person(string first, string last, int age)
    {
        FirstName = first;
        LastName  = last;
        Age       = age;
    }

    // Method
    public string FullName()
    {
        return $"{LastName}, {FirstName}";
    }

    public bool IsAdult()
    {
       if (Age < 18)
        {
            return false;
        }
        return true;
    }
}