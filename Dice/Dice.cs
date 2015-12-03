using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dice
{
    public class Dice
    {
        /// <summary>
        /// Implementation of the Random class.
        /// </summary>
        Random rand = new Random();
        /// <summary>
        /// The minimum number of sides a die can have.
        /// </summary>
        private int IntMinimumSides = 1;
        /// <summary>
        /// Add 1 to everyone roll to ensure we get a full value.
        /// </summary>
        private int IntMaxSideAddition = 1;
        /// <summary>
        /// The number of spaces in the multidimensional array for returns.
        /// </summary>
        private int intMultipleDiceValues = 3;
        /// <summary>
        /// Total number of sides on the dice.
        /// </summary>
        private int intTotalSides = 0;
        /// <summary>
        /// Number of dice rolled.
        /// </summary>
        private int intAmountOfDice = 1;
        /// <summary>
        /// Die result in the array.
        /// </summary>
        private int intResult = 2;

        /// <summary>
        /// A class used for rolling dice. Could be useful for any random number generation. 
        /// Implements the Random class from C#, so it is not useful for anything cryptographic in nature.
        /// </summary>
        public Dice()
        {

        }

        /// <summary>
        /// This allows you to roll multiple dice of the same type.
        /// </summary>
        /// <param name="intSides">The number of sides the die should have.</param>
        /// <param name="intDice">The number of dice you are going to roll.</param>
        /// <param name="intModifier">A modifier that can be added to the die rolls.</param>
        /// <returns>An integer with the combined die rolls.</returns>
        public int Roll(int intSides, int intDice = 1, int intModifier = 0)
        {
            int intRoll = intModifier;

            for(int i = 0; i < intDice; i++)
            {
                intRoll += rand.Next(IntMinimumSides, intSides + IntMaxSideAddition);
            }

            return intRoll;
        }

        /// <summary>
        /// This allows you to roll multiple dice of the same type and view each individual roll
        /// </summary>
        /// <param name="intSides">The number of sides the die should have.</param>
        /// <param name="intDice">The number of dice you are going to roll.</param>
        /// <returns>An integer array that contains each roll of the dice.</returns>
        public int[] Roll(int intSides, int intDice)
        {
            int[] intRoll = new int[intDice];

            for (int i = 0; i < intDice; i++)
            {
                intRoll[i] = rand.Next(IntMinimumSides, intSides + IntMaxSideAddition);
            }

            return intRoll;
        }

        /// <summary>
        /// This allows you to roll multiple different dice and get the result back.
        /// </summary>
        /// <param name="intSides">The number of sides on the various different dice; each array index corresponds with the same number of dice in the intDice array of the same index position</param>
        /// <param name="intDice">The number of dice you are going to roll; each array index corresponds with the same number of sides in intSides array of the same index position</param>
        /// <returns>A rectangular array that returns the values of rolled dice in this pattern: # of Sides | # of Dice | Value of Dice Rolls</returns>
        public int[,] RollMultipleDifferentDice(int[] intSides, int[] intDice)
        {
            int[,] intRoll = new int[intSides.Length, intMultipleDiceValues];

            for(int i = 0; i < intDice.Length; i++)
            {
                intRoll[i, intTotalSides] = intSides[i];
                intRoll[i, intAmountOfDice] = intDice[i];

                for (int u = 0; u < intDice[i]; u++)
                {
                    intRoll[i, intResult] += rand.Next(IntMinimumSides, intSides[i] + IntMaxSideAddition);
                }
            }

            return intRoll;
        }
    }
}
