using DotNet.ProgrammingPrinciples.DRY.Old;
using NUnit.Framework;

namespace DotNet.ProgrammingPrinciples.DRY.UnitTests.Old
{
    [TestFixture]
    public class AddressBookTests
    {
        [Test]
        public void ContactsToString_Default_Returns3Contacts()
        {
            var addressBook = new AddressBook();
            var expectedContacts =
                "Name: Meto Trajkovski, City: Skopje, Country: Macedonia, Address: St.Bul. Partizanski Odredi, Phone number: +38975223305\n"
                + "Name: Stole Popov, City: Skopje, Country: Macedonia, Address: St.Bul. ASNOM, Phone number: +38975223302\n"
                + "Name: Mile Nemile, City: Skopje, Country: Macedonia, Address: St.Bul. Kliment Ohridski, Phone number: +38975223301";

            var contacts = addressBook.ContactsToString();

            Assert.AreEqual(expectedContacts, contacts);
        }
    }
}
