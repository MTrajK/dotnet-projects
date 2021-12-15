namespace DotNet.UnitTesting.Demo6.Comparator
{
    public class Comparation
    {
        public bool LessOrEqual(int a, int b)
        {
            // return a < b; // first version, the second test will fail
            return a <= b; // second version, after refactoring
        }
    }
}
