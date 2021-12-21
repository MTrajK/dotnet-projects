/// <remarks>
/// This class Generates prime numbers up to a user specified
/// maximum. The algorithm used is the Sieve of Eratosthenes.
/// <p>
/// Eratosthenes of Cyrne, b. c. 276 BC, Cyrne, Libya --
/// d. c. 193, Alexandria. The first man to calculate the 
/// circumference of the Earth. Also known for working on
/// calendars with leap years and ran the library at Alexandria.
/// </p>
/// The Algorithm is quite simple. Given an array of integers
/// starting at 2. Cross out all multiples of 2. Find the next
/// uncrossed integer, and cross out all of its multiples.
/// Repeat until you have passed the square root of the maximum
/// value.
///
/// Written by Robert C. Martin on 9 Dec 1999 in Java
/// Translated to C# by Micah Martin on 12 Jan 2005.
/// </remarks>

using System;

namespace DotNet.CleanCode.Functions.Old
{
    /// <summary>
    /// author: RObert. C Martin
    /// </summary>
    public class GeneratePrimes
    {
        /// <summary>
        /// Generates an array of prime number.
        /// </summary>
        /// <param name="maxValue">The generation limit.</param>
        /// <returns>Returns list with primes.</returns>
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue >= 2) // the only valid case
            {
                // declarations
                int s = maxValue + 1; // size of array
                bool[] f = new bool[s];
                int i;

                // initialize array to true.
                for (i = 0; i < s; i++)
                    f[i] = true;

                // get rid of known non-primes
                f[0] = f[1] = false;

                // sieve
                int j;
                for (i = 2; i < Math.Sqrt(s) + 1; i++)
                {
                    if (f[i]) // if i is uncrossed, cross its multiples.
                    {
                        for (j = 2 * i; j < s; j += i)
                            f[j] = false; // multiple is not prime
                    }
                }

                // how many primes are there?
                int count = 0;
                for (i = 0; i < s; i++)
                {
                    if (f[i])
                        count++; // bump count.
                }

                int[] primes = new int[count];

                // move the primes into the result
                for (i = 0, j = 0; i < s; i++)
                {
                    if (f[i]) // if prime
                        primes[j++] = i;
                }

                return primes; // return the primes
            }
            else // maxValue < 2
                return new int[0]; // return null array if bad input
        }
    }
}
