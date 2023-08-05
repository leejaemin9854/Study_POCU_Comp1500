using System.Collections.Generic;
using System.IO;

namespace Assignment4
{
    public enum EElementType
    {
        Fire,
        Water,
        Wind,
        Earth
    };


    public class Monster
    {
        public string Name { get; private set; }
        public EElementType ElementType { get; private set; }
        public int Health { get; private set; }
        public int AttackStat { get; private set; }
        public int DefenseStat { get; private set; }



        public Monster(string name, EElementType elementType, int health, int attack, int defense)
        {
            Name = name;
            ElementType = elementType;
            Health = health;
            AttackStat = attack;
            DefenseStat = defense;

        }

        public void TakeDamage(int amount)
        {
            if (amount > Health)
            {
                Health = 0;
            }
            else
            {
                Health -= amount;
            }

        }

        public void Attack(Monster otherMonster)
        {
            int amount = AttackStat - otherMonster.DefenseStat;
            amount = (int)CalculateConstancy((double)amount, ElementType, otherMonster.ElementType);
            amount = amount < 1 ? 1 : amount;


            otherMonster.TakeDamage(amount);
        }

        static double CalculateConstancy(double deal, EElementType atkElement, EElementType shtElement)
        {
            double result = deal;

            if (atkElement == EElementType.Fire)
            {
                if (shtElement == EElementType.Wind)
                {
                    result *= 1.5f;
                }
                else if (shtElement != EElementType.Fire)
                {
                    result *= 0.5f;
                }
            }
            else if (atkElement == EElementType.Water)
            {
                if (shtElement == EElementType.Fire)
                {
                    result *= 1.5f;
                }
                else if (shtElement == EElementType.Wind)
                {
                    result *= 0.5f;
                }
            }
            else if (atkElement == EElementType.Wind)
            {
                if (shtElement == EElementType.Fire)
                {
                    result *= 0.5f;
                }
                else if (shtElement != EElementType.Wind)
                {
                    result *= 1.5f;
                }

            }
            else
            {
                if (shtElement == EElementType.Fire)
                {
                    result *= 1.5f;
                }
                else if (shtElement == EElementType.Wind)
                {
                    result *= 0.5f;
                }
            }



            return result;
        }




    }



    public class Arena
    {
        public uint Capacity { get; private set; }
        public string ArenaName { get; private set; }
        public uint Turn { get; private set; }
        public uint MonsterCount { get; private set; }

        public List<Monster> MonsterList;

        public Arena(string arenaName, uint capacity)
        {
            ArenaName = arenaName;
            Capacity = capacity;

            MonsterList = new List<Monster>((int)capacity);
            MonsterCount = 0;
            Turn = 0;
        }


        public void LoadMonsters(string filePath)
        {

            if (MonsterCount >= Capacity || !File.Exists(filePath))
            {
                return;
            }


            StreamReader sr = new StreamReader(filePath);



            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                string[] data = line.Split(',');

                //New Monster--
                string name = data[0];
                EElementType elementType = EElementType.Fire;

                if (data[1] == "Water")
                {
                    elementType = EElementType.Water;
                }
                else if (data[1] == "Wind")
                {
                    elementType = EElementType.Wind;
                }
                else if (data[1] == "Earth")
                {
                    elementType = EElementType.Earth;
                }

                int health = int.Parse(data[2]);
                int attackStat = int.Parse(data[3]);
                int defense = int.Parse(data[4]);



                MonsterList.Add(new Monster(name, elementType, health, attackStat, defense));

                MonsterCount++;
                if (MonsterCount >= Capacity)
                {
                    break;
                }

            }


        }

        public void GoToNextTurn()
        {
            if (MonsterList.Count < 2)
            {
                MonsterCount = (uint)MonsterList.Count;
                return;
            }

            
            
            for (int i = 0; i < MonsterList.Count; i++)
            {
                if (MonsterList[i].Health <= 0)
                {
                    continue;
                }
                MonsterList[i].Attack(MonsterList[(int)((i + 1) % MonsterList.Count)]);

            }


            for (int i = 0; i < MonsterList.Count; i++)
            {
                if (MonsterList[i].Health <= 0)
                {
                    MonsterList.RemoveAt(i);
                }

            }



            MonsterCount = (uint)MonsterList.Count;

            Turn += 1;

        }


        public Monster GetHealthiestOrNull()
        {
            if (MonsterList.Count == 0)
            {
                return null;
            }

            Monster result = MonsterList[0];

            for (int i = 1; i < MonsterList.Count; i++)
            {
                if (result.Health < MonsterList[i].Health)
                {
                    result = MonsterList[i];
                }
            }

            return result;
        }

    }
}
