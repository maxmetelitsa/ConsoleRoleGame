using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class Magician : Hero
    {
        Random random = new Random();
        double mana;
        double maxmana;
        public double Mana
        {
            get { return mana; }
            set
            {
                if (value >= Maxmana)
                {
                    mana = Maxmana;
                }
                if (value < 0)
                {
                    throw new Exception("Некорректное значение количества маны");
                }
                else
                {
                    mana = value;
                }
            }

        }
        public double Maxmana
        {
            get { return maxmana; }
            set
            {
                if (value >= 0)
                {
                    maxmana = value;
                }
                else
                {
                    throw new Exception("Некорректное значение максимального количества маны");
                }
            }

        }
        public override string ToString()
        {
            return base.ToString() + $"{Console.ForegroundColor = ConsoleColor.Blue} Мана: {Mana}\n Максимальная мана: {Maxmana} {Console.ForegroundColor = ConsoleColor.White}";
        }
        public override void FastPrint()
        {
            base.FastPrint();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" Мана: {Mana}\n Максимальная мана: {Maxmana}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public Magician(string name, State state, bool talkabilitynow, bool moveabilitynow, Race race, string sex, int age, double healthnow, double maxhealth, double experience, double mana, double maxmana) : base(name, state, talkabilitynow, moveabilitynow, race, sex, age, healthnow, maxhealth, experience)
        {
            Mana = mana;
            Maxmana = maxmana;
        }

        public Magician()
        {
        }
        public static void CheckState(Magician magician)
        {
            if ((magician.HealthNow < (magician.MaxHealth / 100.0)) && ((magician.HealthNow / magician.MaxHealth) * 100) >= 1)
            {
                magician.State = State.Weakened;
            }
            else if ((magician.HealthNow / magician.MaxHealth) * 100 >= 10)
            {
                magician.State = State.Healthy;
            }
            else if (magician.HealthNow <= 0)
            {
                magician.State = State.Dead;
            }
        }

        public void Heal()
        {
            double difference = 0;
            double mana_need = 0;
            double mana_to_health = 0;
            if (Mana >= 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string HealText1 = "\n Нажмите Enter, чтобы исцелить себя: ";
                char[] CHealText = HealText1.ToCharArray();
                for (int i = 0; i < CHealText.Length; i++)
                {
                    Console.Write(CHealText[i]);
                    Thread.Sleep(50);
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    difference = MaxHealth - HealthNow;
                    mana_need = difference * 2;
                    if (Mana >= mana_need)
                    {
                        HealthNow = MaxHealth;
                        Mana -= mana_need;
                    }
                    else
                    {
                        HealthNow += Mana / 2;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\n Вы восстановили {difference} здоровья");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("\n Вам не хватает маны для восстановления здоровья");
            }
        }
        public bool Attack()
        {
            double healthdamage = 0;
            double monster_health = 1000;
            double damage = 0;
            int count = 0;
            bool check = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n Здоровье чудовища: {monster_health}\n");
            if (Mana >= 150)
            {
                while (Mana >= 150 && check == true && monster_health >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n Нажмите Enter, чтобы ударить чудовище, иначе вы будете убиты: ");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Mana -= 10;
                        damage = random.Next(4,10) + count * 2;
                        healthdamage += damage;
                        monster_health -= damage;
                        HealthNow -= random.Next(2, 4);
                        if (monster_health <= 0)
                        {
                            monster_health = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n Вы нанесли чудовищу {damage} урона\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" Здоровье чудовища: {monster_health}\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($" Ваша мана: {Mana}\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" Ваше здоровье: {HealthNow}\n");
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n Вы нанесли чудовищу {damage} урона\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" Здоровье чудовища: {monster_health}\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($" Ваша мана: {Mana}\n");
                            Console.ForegroundColor = ConsoleColor.Green;
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
            }
            if (check == true)
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
