using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hometask_1
{
    interface Magic
    {
        void AddHealthForAllMana(Magician magician, Magician magician_acted);
        void AddNeededHealth(Magician magician, Magician magician_acted, double power);
        void AddNeededHealthToYourself(Magician magician, double power);
        void StateHeal(Magician magician, Magician magician_acted);
        void Antidote(Magician magician, Magician magician_acted);
        void Revive(Magician magician, Magician magician_acted);
        void Armor(Magician magician, Magician magician_acted);
        void ArmorFortime(Magician magician, Magician magician_acted, int seconds);
        void ArmorTimeForYourself(Magician magician, int seconds);
        void Alive(Magician magician, Magician magician_acted);
    }
    public class Spell : Magic
    {
        public Spell()
        {
            Min_mana_amount = 0;
        }
        Random random = new Random();
        double min_mana_amount;
        public double Min_mana_amount
        {
            get { return min_mana_amount; }
            set { min_mana_amount = value; }
        }
        string verbal_component;
        public string Verbal_component
        {
            get { return verbal_component; }
            set { verbal_component = value; }
        }

        string motor_component;
        public string Motor_component
        {
            get { return motor_component; }
            set { motor_component = value; }
        }
        public void AddHealthForAllMana(Magician magician, Magician magician_acted)// на всю ману
        {
            double difference = 0;
            double mana_need = 0;
            double mana_to_health = 0;
            if (magician_acted.Mana >= 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string HealText1 = "\n Нажмите Enter, чтобы исцелить союзника: ";
                char[] CHealText = HealText1.ToCharArray();
                for (int i = 0; i < CHealText.Length; i++)
                {
                    Console.Write(CHealText[i]);
                    Thread.Sleep(50);
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    difference = magician.MaxHealth - magician.HealthNow;
                    mana_need = difference * 2;
                    if (magician_acted.Mana >= mana_need)
                    {
                        magician.HealthNow = magician.MaxHealth;
                        magician_acted.Mana -= mana_need;
                    }
                    else
                    {
                        magician.HealthNow += magician_acted.Mana / 2;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\n Вы восстановили {difference} здоровья вашему союзнику");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("\n Вам не хватает маны для восстановления здоровья союзника");
            }
        }
        public void AddNeededHealth(Magician magician, Magician magician_acted, double power)
        {
            double mana_need = 0;
            double mana_to_health = 0;
            if (magician_acted.Mana >= 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string HealText1 = "\n Нажмите Enter, чтобы исцелить союзника: ";
                char[] CHealText = HealText1.ToCharArray();
                for (int i = 0; i < CHealText.Length; i++)
                {
                    Console.Write(CHealText[i]);
                    Thread.Sleep(50);
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    mana_need = power * 2;
                    if (magician_acted.Mana >= mana_need)
                    {
                        magician.HealthNow = magician.MaxHealth;
                        magician_acted.Mana -= mana_need;
                    }
                    else
                    {
                        magician.HealthNow += magician_acted.Mana / 2;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\n Вы восстановили {power} здоровья вашему союзнику");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("\n Вам не хватает маны для восстановления здоровья союзника");
            }
        }
        public void AddNeededHealthToYourself(Magician magician, double power)
        {
            double mana_need = 0;
            double mana_to_health = 0;
            if (magician.Mana >= 2)
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
                    mana_need = power * 2;
                    if (magician.Mana >= mana_need)
                    {
                        magician.HealthNow = magician.MaxHealth;
                        magician.Mana -= mana_need;
                    }
                    else
                    {
                        magician.HealthNow += magician.Mana / 2;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\n Вы восстановили {power} здоровья.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("\n Вам не хватает маны для восстановления здоровья союзника");
            }
        }
        public void StateHeal(Magician magician, Magician magician_acted)
        {
            Min_mana_amount = 20;
            if (magician.State == State.Ill)
            {
                if (magician_acted.Mana >= Min_mana_amount)
                {
                    Magician.CheckState(magician);
                    magician_acted.Mana -= Min_mana_amount;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Verbal_component = $"\n 'Жизнь за жизнь!' - сказал " + magician_acted.Name;
                    Console.WriteLine($"{Verbal_component}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Недостаточно маны для выполнения заклинания.");
                }
            }
            else
            {
                Console.WriteLine("Герой не находится в состоянии 'болен' для выполнения данного заклинания.");
            }
        }
        public void Antidote(Magician magician, Magician magician_acted)
        {
            Min_mana_amount = 30;
            if (magician.State == State.Poisoned)
            {
                if(magician_acted.Mana >= Min_mana_amount)
                {
                    Magician.CheckState(magician);
                    magician_acted.Mana -= Min_mana_amount;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Verbal_component = $"\n 'Антидот экспректрум' - сказал" + magician_acted.Name;
                    Console.WriteLine($"{Verbal_component}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Недостаточно маны для выполнения заклинания.");
                }
            }
            else
            {
                Console.WriteLine("Герой не находится в состоянии 'отравлен' для выполнения данного заклинания.");
            }
        }
        public void Revive(Magician magician, Magician magician_acted)
        {
            Min_mana_amount = 150;
            if (magician.State == State.Dead)
            {
                if (magician_acted.Mana >= Min_mana_amount)
                {
                    Magician.CheckState(magician);
                    magician_acted.Mana -= Min_mana_amount;
                    magician.HealthNow = 1;
                    magician.TalkAbilityNow = true;
                    magician.MoveAbilityNow = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Verbal_component = $"\n 'Восстань из мертвых!' - сказал " + magician_acted.Name;
                    Console.WriteLine($"{Verbal_component}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Недостаточно маны для выполнения заклинания.");
                }
            }
            else
            {
                Console.WriteLine("Герой не находится в состоянии 'мертв' для выполнения данного заклинания.");
            }
        }
        public void Armor(Magician magician, Magician magician_acted)// на всю ману
        {
            Min_mana_amount = 50;
            int counter = 0;
            if (magician_acted.Mana >= Min_mana_amount)
            {
                magician_acted.Mana -= 50;
                while (magician_acted.Mana >= Min_mana_amount)
                {
                    magician.HealthNow = magician.MaxHealth;
                    magician_acted.Mana -= Min_mana_amount;
                    counter += 1;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Motor_component = "\n Произошел взмах руки ";
                Console.WriteLine($"{Verbal_component}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Броня была наложена на " + counter + " секунды.");
            }
            else
            {
                Console.WriteLine("Недостаточно маны для выполнения заклинания.");
            }
        }
        public void ArmorFortime(Magician magician, Magician magician_acted, int seconds)// на нужное время либо на сколько есть маны
        {
            Min_mana_amount = 50;
            double mana_needed = Min_mana_amount * seconds;
            int counter = 0;
            if (magician_acted.Mana >= mana_needed)
            {
                magician_acted.Mana -= mana_needed;
                counter += seconds;
                Console.ForegroundColor = ConsoleColor.Green;
                Motor_component = "\n Произошел взмах руки ";
                Console.WriteLine($"{Verbal_component}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Броня была наложена на " + counter + " секунды.");
            }
            else if (magician_acted.Mana >= Min_mana_amount)
            {
                while (magician_acted.Mana >= Min_mana_amount)
                {
                    magician.HealthNow = magician.MaxHealth;
                    magician_acted.Mana -= Min_mana_amount;
                    counter += 1;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Motor_component = "\n Произошел взмах руки ";
                Console.WriteLine($"{Verbal_component}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Броня была наложена на " + counter + " секунды.");
            }
            else
            {
                Console.WriteLine("Недостаточно маны для выполнения заклинания.");
            }
        }
        public void ArmorTimeForYourself(Magician magician, int seconds)// на нужное время либо на сколько есть маны на себя
        {
            Min_mana_amount = 50;
            double mana_needed = Min_mana_amount * seconds;
            int counter = 0;
            if (magician.Mana >= mana_needed)
            {
                magician.Mana -= mana_needed;
                counter += seconds;
                Console.ForegroundColor = ConsoleColor.Green;
                Motor_component = "\n Произошел взмах руки ";
                Console.WriteLine($"{Verbal_component}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Броня была наложена на " + counter + " секунды.");
            }
            else if (magician.Mana >= Min_mana_amount)
            {
                while (magician.Mana >= Min_mana_amount)
                {
                    magician.HealthNow = magician.MaxHealth;
                    magician.Mana -= Min_mana_amount;
                    counter += 1;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Motor_component = "\n Произошел взмах руки ";
                Console.WriteLine($"{Verbal_component}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Броня была наложена на " + counter + " секунды.");
            }
            else
            {
                Console.WriteLine("Недостаточно маны для выполнения заклинания.");
            }
        }
        public void Alive(Magician magician, Magician magician_acted)
        {
            Min_mana_amount = 85;
            int st = random.Next(2);
            if (magician.State == State.Paralyzed)
            {
                if (magician_acted.Mana >= Min_mana_amount)
                {
                    Magician.CheckState(magician);
                    magician_acted.Mana -= Min_mana_amount;
                    magician.HealthNow = 1;
                    magician.TalkAbilityNow = true;
                    magician.MoveAbilityNow = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Motor_component = "\n Маг скрестил две руки над головой ";
                    Console.WriteLine($"{Verbal_component}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Недостаточно маны для выполнения заклинания.");
                }
            }
            else
            {
                Console.WriteLine("Герой не находится в состоянии 'парализован' для выполнения данного заклинания.");
            }
        }
    }
}
