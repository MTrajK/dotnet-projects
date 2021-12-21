namespace DotNet.ProgrammingPrinciples.DRY.New
{
    public static class FruitValidation
    {
        private static string[] _validFruits = new string[] { "banana", "apple", "peach" };

        public static bool IsValidFruit(string fruit)
        {
            foreach (var validFruit in _validFruits)
                if (CompareFruits(validFruit, fruit))
                    return true;

            return false;
        }

        private static bool CompareFruits(string fruitA, string fruitB)
        {
            return fruitA.ToLower() == fruitB.ToLower();
        }
    }
}
