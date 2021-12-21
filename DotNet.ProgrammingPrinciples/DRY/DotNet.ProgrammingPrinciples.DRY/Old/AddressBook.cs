namespace DotNet.ProgrammingPrinciples.DRY.Old
{
    public class AddressBook
    {
        public string ContactsToString()
        {
            var contact1 = Contact1ToString();
            var contact2 = Contact2ToString();
            var contact3 = Contact3ToString();

            return string.Join("\n", new string[] { contact1, contact2, contact3 });
        }

        private string Contact1ToString()
        {
            var name = "Meto Trajkovski";
            var city = "Skopje";
            var country = "Macedonia";
            var address = "St.Bul. Partizanski Odredi";
            var phoneNumber = "+38975223305";

            return $"Name: {name}, City: {city}, Country: {country}, Address: {address}, Phone number: {phoneNumber}";
        }

        private string Contact2ToString()
        {
            var name = "Stole Popov";
            var city = "Skopje";
            var country = "Macedonia";
            var address = "St.Bul. ASNOM";
            var phoneNumber = "+38975223302";

            return $"Name: {name}, City: {city}, Country: {country}, Address: {address}, Phone number: {phoneNumber}";
        }

        private string Contact3ToString()
        {
            var name = "Mile Nemile";
            var city = "Skopje";
            var country = "Macedonia";
            var address = "St.Bul. Kliment Ohridski";
            var phoneNumber = "+38975223301";

            return $"Name: {name}, City: {city}, Country: {country}, Address: {address}, Phone number: {phoneNumber}";
        }
    }
}
