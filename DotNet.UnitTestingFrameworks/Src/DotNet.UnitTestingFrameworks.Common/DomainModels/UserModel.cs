namespace DotNet.UnitTestingFrameworks.Common.DomainModels
{
    public class UserModel
    {
        public string FirstName;

        public string LastName;

        public string Email;

        public int Number1;

        public int Number2;

        public string Operation;

        public int Result;

        public UserModel(string firstName, string lastName, string email,
            int number1, int number2, string operation, int result)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Number1 = number1;
            Number2 = number2;
            Operation = operation;
            Result = result;
        }
    }
}
