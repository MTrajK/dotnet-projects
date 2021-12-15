namespace DotNet.UnitTestingFrameworks.Common.APIModels
{
    public class GetUserResponseModel
    {
        public string FirstName;

        public string LastName;

        public string Email;

        public int Number1;

        public int Number2;

        public string Operation;

        public int Result;

        public GetUserResponseModel(string firstName, string lastName, 
            string email, int number1, int number2, string operation, int result)
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
