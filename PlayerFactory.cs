using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TextBasedRpg
{
    public enum PlayerClass
    {
        Warrior,
        Mage,
        //Thief,
        //Ranger
    }

    public static class PlayerFactory
    {
        private const string PlayerClassesFile = "./GameData/Classes.json";
        private static readonly Dictionary<PlayerClass, Player> PlayerClasses;

        static PlayerFactory()
        {
            if (File.Exists(PlayerClassesFile))
            {
                string json = File.ReadAllText(PlayerClassesFile);

                PlayerClasses =
                    JsonConvert.DeserializeObject<Dictionary<PlayerClass, Player>>(json); //Ask PlayerData
            }
        }

        public static IPlayerClass CreatePlayer(PlayerClass playerClass, string name)
        {
            Player player;
            switch (playerClass)
            {
                case PlayerClass.Warrior:
                    player = PlayerClasses[PlayerClass.Warrior];
                    return new Warrior // Ask if constructor would be better
                    {
                        Name = name,
                        CurrentHitPoint = player.MaxHitPoint,
                        MaxHitPoint = player.MaxHitPoint,
                        AttackPoint = player.AttackPoint,
                        DefensePoint = player.DefensePoint,
                        CurrentStamina = player.MaxStamina,
                        MaxStamina = player.MaxStamina,
                        SpecialAttackCost = player.SpecialAttackCost,
                        Level = 1,
                        Exp = 0
                    };
                case PlayerClass.Mage:
                    player = PlayerClasses[PlayerClass.Mage];
                    return new Warrior
                    {
                        Name = name,
                        CurrentHitPoint = player.MaxHitPoint,
                        MaxHitPoint = player.MaxHitPoint,
                        AttackPoint = player.AttackPoint,
                        DefensePoint = player.DefensePoint,
                        CurrentStamina = player.MaxStamina,
                        MaxStamina = player.MaxStamina,
                        SpecialAttackCost = player.SpecialAttackCost,
                        Level = 1,
                        Exp = 0
                    };
            }

            return null;
        }
    }
}