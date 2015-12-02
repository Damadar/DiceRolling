using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dice
{
    public class Dice
    {
        Random rand = new Random();

        private int IntMinimumSides = 1;

        private int IntMaxSideAddition = 1;

        private int intMultipleDiceValues = 3;

        private int intTotalSides = 0;

        private int intAmountOfDice = 1;

        private int intResult = 2;

        public Dice()
        {

        }

        /// <summary>
        /// This allows you to roll 1 die with a certain number of sides.
        /// </summary>
        /// <param name="intSides">The number of sides the die should have.</param>
        /// <returns>Returns a random roll of the die.</returns>
        public int Roll(int intSides)
        {
            return rand.Next(IntMinimumSides, intSides + IntMaxSideAddition);
        }

        /// <summary>
        /// This allows you to roll multiple dice of the same type.
        /// </summary>
        /// <param name="intSides">The number of sides the die should have.</param>
        /// <param name="intDice">The number of dice you are going to roll.</param>
        /// <param name="intModifier">A modifier that can be added to the die rolls.</param>
        /// <returns>An integer with the combined die rolls.</returns>
        public int Roll(int intSides, int intDice, int intModifier = 0)
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
