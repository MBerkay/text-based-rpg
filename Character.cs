using System;

namespace TextBasedRpg
{
    public abstract class Character
    {
        private string _name;
        private int _currentHitPoint;
        private int _maxHitPoint;
        private int _attackPoint;
        private int _defensePoint;
        private int _currentStamina;
        private int _maxStamina;
        private int _specialAttackCost;

        public int CurrentStamina
        {
            get { return _currentStamina; }
            set { _currentStamina = value; }
        }

        public string Name
        {
            get => _name;
            set { _name = value; }
        }

        public int MaxStamina
        {
            get { return _maxStamina; }
            set { _maxStamina = value; }
        }

        public int DefensePoint
        {
            get { return _defensePoint; }
            set { _defensePoint = value; }
        }

        public int MaxHitPoint
        {
            get { return _maxHitPoint; }
            set { _maxHitPoint = value; }
        }

        public int AttackPoint
        {
            get { return _attackPoint; }
            set { _attackPoint = value; }
        }

        public int SpecialAttackCost
        {
            get { return _specialAttackCost; }
            set { _specialAttackCost = value; }
        }
        
        public bool CanPerformSpecialAttack => _currentStamina > SpecialAttackCost; //TODO Ask Method vs Property 

        /// Doesn't consume stamina
        public void PerformBasicAttackOn(Character enemy)
        {
            int calculatedDmg = AttackPoint + Dice.Roll(6) - enemy.DefensePoint;
            enemy.TakeDamage(calculatedDmg);
        }
        
        /*public virtual void PerformSpecialAttackOn(Character enemy)
        {
        }*/


        public virtual void TakeDamage(int damage)
        {
            _currentHitPoint -= damage;
            if (_currentHitPoint < 0)
            {
                
            }
            Console.WriteLine("Damage taken " + damage);
        }

        public void Heal(int point)
        {
           _currentHitPoint = Math.Min(_currentHitPoint + point, _maxHitPoint);
        }
        
        
        public event EventHandler<string> OnActionPerformed;
        public event EventHandler OnKilled;
        
        private void OnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }

        private void RaiseActionPerformedEvent(object sender, string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
        
    }
}