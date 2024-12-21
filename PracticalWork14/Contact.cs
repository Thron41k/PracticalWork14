namespace PracticalWork14;

public class Contact(string name, string lastName, long phoneNumber, string email)
{
    public string Name { get; } = name;
    public string LastName { get; } = lastName;
    public long PhoneNumber { get; } = phoneNumber;
    public string Email { get; } = email;
}

