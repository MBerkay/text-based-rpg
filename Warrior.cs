using System;

namespace TextBasedRpg
{
    public class Warrior : Player, IPlayerClass
    {
        /// Pierce, Armor does not have effect
        public void PerformSpecialAttackOn(Character enemy)
        {
            if (CanPerformSpecialAttack)
            {
                CurrentStamina -= 2;
                int calculatedDmg = AttackPoint + Dice.Roll(6);
                enemy.TakeDamage(calculatedDmg);
            }
            else
            {
                Console.WriteLine("Can't have enough stamina");
            }
        }
    }
}