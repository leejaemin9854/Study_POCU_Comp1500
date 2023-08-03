﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Health { get; set; }
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
            amount = (int)ConstancyCalculation((double)amount, ElementType, otherMonster.ElementType);
            amount = amount < 1 ? 1 : amount;


            otherMonster.TakeDamage(amount);
        }

        static double ConstancyCalculation(double deal, EElementType atkElement, EElementType shtElement)
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
                else if (shtElement == EElementType.Wind)
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

        private List<Monster> monsters;

        public Arena(string arenaName, uint capacity)
        {
            ArenaName = arenaName;
            Capacity = capacity;

            monsters = new List<Monster>((int)capacity);
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



                monsters.Add(new Monster(name, elementType, health, attackStat, defense));

                MonsterCount++;
                if (MonsterCount >= Capacity)
                {
                    break;
                }

            }


        }

        public void GoToNextTurn()
        {
            if (monsters.Count < 2)
            {
                return;
            }


            List<int> removeList = new List<int>(monsters.Count);


            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].Health <= 0)
                {
                    removeList.Add(i);
                    continue;
                }
                monsters[i].Attack(monsters[(int)((i + 1) % monsters.Count)]);

            }

            for (int i = 0; i < removeList.Count; i++)
            {
                monsters.RemoveAt(removeList[i]);
            }

            MonsterCount -= (uint)removeList.Count;
        }


        public Monster GetHealthiestOrNull()
        {
            if (monsters.Count == 0)
            {
                return null;
            }

            Monster result = monsters[0];

            for (int i = 1; i < monsters.Count; i++)
            {
                if (result.Health < monsters[i].Health)
                {
                    result = monsters[i];
                }
            }

            return result;
        }

    }
}
