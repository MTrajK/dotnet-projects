namespace DotNet.ProgrammingPrinciples.DRY.New
{
    public class Contact
    {
        private string _name;
        private string _city;
        private string _country;
        private string _address;
        private string _phoneNumber;

        public Contact(string name, string city, string country, string address, string phoneNumber)
        {
            _name = name;
            _city = city;
            _country = country;
            _address = address;
            _phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Name: {_name}, City: {_city}, Country: {_country}, Address: {_address}, Phone number: {_phoneNumber}";
        }
    }
}
