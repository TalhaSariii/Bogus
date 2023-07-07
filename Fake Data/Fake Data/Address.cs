namespace FakeData
{
    public class Address
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetName { get; set; }

        public override string ToString()
        {
            return $"City: {City}\n" +
                $"Zip Code: {ZipCode}\n" +
                $"Street Name: {StreetName}";
        }
    }
}
