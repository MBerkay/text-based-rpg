using System;

namespace TextBasedRpg
{
    public class Mage : Player, IPlayerClass
    {
        /// Fireball, Add Passive to enemy
        // TODO add passive system
        public void PerformSpecialAttackOn(Character enemy)
        {
            if (CanPerformSpecialAttack)
            {
                CurrentStamina -= 2;
                int calculatedDmg = (int)(AttackPoint * 1.5 + Dice.Roll(6) - enemy.DefensePoint);
                enemy.TakeDamage(calculatedDmg);
            }
            else
            {
                Console.WriteLine("Can't have enough stamina");
            }
        }
    }
}