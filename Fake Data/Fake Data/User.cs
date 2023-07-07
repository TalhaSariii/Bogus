using System;

namespace FakeData
{
    public enum Gender
    {
        Male,
        Female
    }

    public class User
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public string GenderString { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName}\n" +
                $"Last Name: {LastName}\n" +
                $"Age: {Age}\n" +
                $"UserName: {UserName}\n" +
                $"Email: {EmailAddress}\n" +
                $"Gender: {GenderString}\n" +
                $"City: {Address.City}\n" +
                $"Zip Code: {Address.ZipCode}\n" +
                $"Street Name: {Address.StreetName}";
        }
    }
}

