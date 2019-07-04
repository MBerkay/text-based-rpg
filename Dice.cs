using System;

namespace TextBasedRpg
{
    //Class of RNG Gods
    public static class Dice
    {
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static int Roll(int side)
        {
            return RandomNumber(1, side + 1);
        }

        public static int RollCheated(int side, int min, int max)
        {
            return 6;
        }
    }
}