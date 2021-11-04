namespace Endava.DotNetCommunity.Common.APIModels
{
    public class CreateUserRequestModel
    {
        public string FirstName;

        public string LastName;

        public string Email;

        public int Number1;

        public int Number2;

        public string Operation;

        public CreateUserRequestModel(string firstName, string lastName, 
            string email, int number1, int number2, string operation)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Number1 = number1;
            Number2 = number2;
            Operation = operation;
        }
    }
}
