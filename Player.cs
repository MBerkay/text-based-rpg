using System;

namespace TextBasedRpg
{
    public class Player : Character
    {
        private int _level;
        private int _exp;

        public int Exp
        {
            get { return _exp; }
            set
            {
                _exp = value;
                LevelCheck();
            }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public void AddExp(int points)
        {
            Exp += points;
        }

        private void LevelCheck()
        {
            if (Exp > Math.Pow(Level, 2) * 10)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            Console.WriteLine("You're leveled up");
        }
    }
}