using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public enum State
    {
        Healthy,
        Weakened,
        Ill,
        Poisoned,
        Paralyzed,
        Dead
    };
    public enum Race
    {
        Human,
        Dwarf,
        Elf,
        Orc,
        Goblin,
    };
    public class Hero : IComparable
    {
        Random random = new Random();
        protected int id;
        protected static int next_id = 1;
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == null)
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Имя персонажа нельзя изменить");
                }
            }
        }
        protected bool talkabilitynow;
        protected bool moveabilitynow;
        public bool TalkAbilityNow
        {
            get { return talkabilitynow; }
            set { talkabilitynow = value; }
        }
        public bool MoveAbilityNow
        {
            get { return moveabilitynow; }
            set { moveabilitynow = value; }
        }

        State state;
        Race race;
        public Race Race
        {
            get { return race; }
            set
            {
                if(race == null)
                {
                    race = value;
                }
                else
                {
                }
            }
        }
        public State State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }
        string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                if (sex == null)
                {
                    sex = value;
                }
                else
                {
                    throw new Exception("Пол персонажа нельзя изменить");
                }
            }
        }
        protected int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        double healthnow;
        public double HealthNow
        {
            get { return healthnow; }
            set
            {
                if(value >= MaxHealth)
                {
                    maxhealth = MaxHealth;
                }
                if(value < 0)
                {
                    throw new Exception("Некорректное значение здоровья в данный момент");
                }
                else
                {
                    healthnow = value;
                }
            }
        }
        double maxhealth;
        public double MaxHealth
        {
            get { return maxhealth; }
            set
            {
                if (value >= 0)
                {
                    maxhealth = value;
                }
                else
                {
                    throw new Exception("Некорректное значение максимального количества здоровья");
                }
            }
        }

        protected double experience;
        public double Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public Hero(string name, State state, bool talkabilitynow, bool moveabilitynow, Race race, string sex, int age, double healthnow, double maxhealth, double experience)
        {
            id = next_id++;
            Name = name;
            State = state;
            TalkAbilityNow = talkabilitynow;
            MoveAbilityNow = moveabilitynow;
            Race = race;
            Sex = sex;
            Age = age;
            HealthNow = healthnow;
            MaxHealth = maxhealth;
            Experience = experience;
        }

        public Hero()
        {

        }

        public int CompareTo(object obj)
        {
            if(obj is Hero hero)
            {
                return hero.Experience.CompareTo(Experience);
            }
            else
            {
                throw new Exception("Некорректное значение аргумента");
            }
        }
        public static void CheckState(Hero hero)
        {
            if(((hero.MaxHealth / hero.HealthNow) * 100) < 10 && ((hero.HealthNow / hero.MaxHealth)  * 100) >= 1)
            {
                hero.State = State.Weakened;
            }
            else if((hero.HealthNow / hero.MaxHealth) * 100 >= 10)
            {
                hero.State = State.Healthy;
            }
            else if(hero.HealthNow <= 0)
            {
                hero.State = State.Dead;
            }
        }
        public override string ToString()
        {
             return $"\n Состояние героя: {State}\n Возможность разговаривать: {TalkAbilityNow}\n" +
                $" Возможность двигаться: {MoveAbilityNow}\n Раса: {Race}\n Пол {Sex}\n Возраст: {Age}\n {Console.ForegroundColor = ConsoleColor.Green}Здоровье: {HealthNow}" +
                $"\n Максимальное здоровье: {MaxHealth}\n {Console.ForegroundColor = ConsoleColor.DarkMagenta}Уровень: {Experience}{Console.ForegroundColor = ConsoleColor.White}";
        }
        public virtual void FastPrint()
        { 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n Состояние героя: {State}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Здоровье: {HealthNow}\n Максимальное здоровье: {MaxHealth}");
            Console.ForegroundColor = ConsoleColor.White;
        }
            public bool Attack()
            {
            double healthdamage = 0;
            double monster_health = 1000;
            double damage = 0;
            int count = 0;
            bool check = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n Здоровье чудовища: {monster_health}");
            while (monster_health >= 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Нажмите Enter, чтобы ударить чудовище, иначе вы будете убиты: ");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    damage = random.Next(2, 5) + count * 2;
                    healthdamage += damage;
                    monster_health -= damage;
                    HealthNow -= random.Next(2,4);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Вы нанесли чудовищу {damage} урона\n");
                    if(monster_health <= 0)
                    {
                        monster_health = 0;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" Здоровье чудовища: {monster_health}\n");
                        Console.WriteLine($" Ваше здоровье: {HealthNow}\n");
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" Здоровье чудовища: {monster_health}\n");
                        Console.WriteLine($" Ваше здоровье: {HealthNow}\n");
                        count++;
                        check = true;
                    }
                }
                else
                {
                    check = false;
                    break;
                }
            }
            if(check == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n Вы убили чудовище и нанесли ему {healthdamage} урона");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n Вы не смогли перебороть чудовище, Game over.");
            }
            return check;
        }
    }

}
