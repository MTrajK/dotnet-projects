using System;

namespace DotNet.CleanCode.MeaningfulNames
{
    public class MeaningfulName
    {
        public void UseIntentionRevealingNames()
        {
            int d; // elapsed time in days
            int c; // days since creation
            int m; // days since modification

            // Why not names like these?
            int elapsedTimeInDays;
            int daysSinceCreation;
            int daysSinceModification;
        }

        public void UsePronounceableNames()
        {
            // Try pronounce these
            DateTime genymdhms;
            DateTime modymdhms;

            // Better, right?
            DateTime generationTimestamp;
            DateTime modificationTimeStamp;
        }

        public void AvoidDisinformation()
        {
            // What is the difference between these two?
            string XYZControllerForEfficientHandlingOfStrings;
            string XYZControllerForEfficientStorageOfStrings;

            // O != 0 and l != 1
            int l = 1;
            int Ol = 01;

            int a = l;
            if (0 == l)
                a = Ol;
            else
                l = 01;
        }

        public void AvoidNoiseWords()
        {
            // Oh it is string, I didn't know that...
            string nameString;
            int moneyAmount;
            Customer customerObject;
            Account accountData;

            // Better, right?
            string name;
            int money;
            Customer customer;
            Account account;
        }

        private class Customer { }

        private class Account { }
    }
}
