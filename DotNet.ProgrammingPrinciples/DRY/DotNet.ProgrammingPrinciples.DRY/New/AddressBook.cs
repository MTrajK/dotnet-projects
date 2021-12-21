namespace DotNet.ProgrammingPrinciples.DRY.New
{
    public class AddressBook
    {
        private const string CITY = "Skopje";
        private const string COUNTRY = "Macedonia";

        private Contact[] _contacts;

        public AddressBook()
        {
            _contacts = new Contact[]
            {
                new Contact("Meto Trajkovski", CITY, COUNTRY, "St.Bul. Partizanski Odredi", "+38975223305"),
                new Contact("Stole Popov", CITY, COUNTRY, "St.Bul. ASNOM", "+38975223302"),
                new Contact("Mile Nemile", CITY, COUNTRY, "St.Bul. Kliment Ohridski", "+38975223301"),
            };
        }

        public string ContactsToString()
        {
            return string.Join<Contact>("\n", _contacts);
        }
    }
}
