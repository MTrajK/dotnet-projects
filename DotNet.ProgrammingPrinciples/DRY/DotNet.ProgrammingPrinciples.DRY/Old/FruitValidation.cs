namespace DotNet.ProgrammingPrinciples.DRY.Old
{
    public static class FruitValidation
    {
        public static bool IsValidFruit(string fruit)
        {
            if (fruit.ToLower() == "banana")
                return true;

            if (fruit.ToLower() == "apple")
                return true;

            if (fruit.ToLower() == "peach")
                return true;

            return false;
        }
    }
}
