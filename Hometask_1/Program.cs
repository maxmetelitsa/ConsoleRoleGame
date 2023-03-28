using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Hometask_1
{
    internal class Program
    {
        static void TextPrint(string Text, int sleep)
        {
            for (int i = 0; i < Text.Length; i++)
            {
                Console.Write(Text[i]);
                Thread.Sleep(sleep);
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"                                      _____         _        ____  _                      
                                     |  ___|_ _  __| | ___  / ___|| |__   __ _ _ __ _ __  
                                     | |_ / _` |/ _` |/ _ \ \___ \| '_ \ / _` | '__| '_ \ 
                                     |  _| (_| | (_| |  __/  ___) | | | | (_| | |  | |_) |
                                     |_|  \__,_|\__,_|\___| |____/|_| |_|\__,_|_|  | .__/ 
                                                                                   |_|   ");
            Console.WriteLine();
            string Text = "         Fade Sharp представляет собой моделирование событий, происходящих в определённом мире в определённое время.\n" +
                  "         Участник отыгрывает за выбрнного персонажа, руководствуясь при этом характеристиками своего героя и его роли\n         в рамках игровых реалий. Индивидуальные действия игрока составляют сюжет игры." +
                  " Действия игрока представляют \n         собой вольную импровизацию в рамках выбранных правил, а также определяют суть игры и её результат.\n" +
                  "                                                 Приятного времяпровождения!                                 " +
                  "\n\n\n\n\t\t\t\t\t       Нажмите Enter для начала истории";
            TextPrint(Text, 1);
            Thread.Sleep(200);
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                Console.Clear();
                string pre_text1 = "\n\n\n Здесь располагается игровая консоль через\n которую вы будете взаимодействовать с игрой.\n\n Для продолжения, нажмите Enter: \n";
                TextPrint(pre_text1, 30);
                bool start = false;
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    start = true;
                }
                else
                {
                    start = false;
                }
                Hero hero1 = new Hero("Арчи", State.Healthy, true, true, Race.Human, "мужской", 27, 1500, 1500, 18);
                Magician hero2 = new Magician("Кириган", State.Healthy, true, true, Race.Dwarf, "мужской", 23, 1200, 1200, 20, 1300, 1300);

                //teammates
                Magician teammate1 = new Magician("Эрнест", State.Poisoned, true, true, Race.Dwarf, "мужской", 32, 600, 1200, 23, 400, 950);
                Magician teammate2 = new Magician("Фрида", State.Dead, false, false, Race.Dwarf, "женский", 20, 0, 900, 15, 200, 700);
                Magician teammate3 = new Magician("Александр", State.Paralyzed, false, false, Race.Dwarf, "мужской", 25, 200, 1400, 22, 200, 1000);
                if (start == true)
                {
                    string pre_text2 = "\n Для взаимодействия с игровым миром, выберите героя: \n";
                    TextPrint(pre_text2, 30);
                    Console.WriteLine($"\t\t _______________________________________________________________________________");
                    Console.WriteLine($"\t\t|\t\t{hero1.Name}\t\t\t|\t\t{hero2.Name}\t\t\t|");
                    Console.WriteLine($"\t\t|Состояние: \t\t\t{hero1.State}\t|Состояние: \t\t\t{hero2.State}\t|");
                    Console.WriteLine($"\t\t|Возможность разговаривать: \t{hero1.TalkAbilityNow}\t|Возможность разговаривать: \t{hero2.TalkAbilityNow}\t|");
                    Console.WriteLine($"\t\t|Возможность двигаться: \t{hero1.MoveAbilityNow}\t|Возможность двигаться: \t{hero2.MoveAbilityNow}\t|");
                    Console.WriteLine($"\t\t|Раса: \t\t\t\t{hero1.Race}\t|Раса: \t\t\t\t{hero2.Race}\t|");
                    Console.WriteLine($"\t\t|Пол: \t\t\t\t{hero1.Sex}\t|Пол: \t\t\t\t{hero2.Sex}\t|");
                    Console.WriteLine($"\t\t|Возраст: \t\t\t{hero1.Age}\t|Возраст: \t\t\t{hero2.Age}\t|");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t\t|Здоровье: \t\t\t{hero1.HealthNow}\t|Здоровье: \t\t\t{hero2.HealthNow}\t|");
                    Console.WriteLine($"\t\t|Максимальное здоровье: \t{hero1.MaxHealth}\t|Максимальное здоровье: \t{hero2.MaxHealth}\t|");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\t\t|Уровень: \t\t\t{hero1.Experience}\t|Уровень: \t\t\t{hero2.Experience}\t|");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\t\t|\t\t\t\t\t|Мана: \t\t\t\t{hero2.Mana}\t|");
                    Console.WriteLine($"\t\t|\t\t\t\t\t|Максимальная мана: \t\t{hero2.Maxmana}\t|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t|_______________________________________|_______________________________________|\n");
                    Console.WriteLine($" Укажите номер подходящего вам героя ({hero1.Name} - 1, {hero2.Name} - 2): ");
                    int check = int.Parse(Console.ReadLine());
                    if (check == 1)
                    {
                        Console.Clear();
                        string Text2 = $"\n\nНекогда могущественная страна Коперфилд, родина носителей древней магии, переживает нелёгкие времена.\n Огромный каньон — Меод, кишащий чудовищами-эльфами, гоблинами, орками - разделил её на две части: Западную и Восточную.\n Пройти сквозь него практически невозможно, " +
                       $"воздух внутри окутан беспросветной мглой, а жуткие твари с острыми когтями и огромными зубами рвут человека на куски за секунды.\n {hero1.Name} вырос в детском приюте в доме князя Карамзина. " +
                       $"Сейчас он служит в Первой Армии: Красавец - следопыт, лучший в своём деле." +
                       $" Первая Армия готовила экспедицию, чтобы пройти через каньон и встретиться с Западной частью, в которой и принял участие {hero1.Name}." +
                       $" Наступило время экспедиции, Армия, сотоящая из лучников, воинов, нескольких магов и {hero1.Name} села на корабль, который поплыл по пескам сквозь каньон. " +
                       $"Ситуация была под контролем, но в один момент их заметила стая чудовищ и ринула в сторону корабля - Армии прийдется сразиться с ней. Жизнь или смерть - итог битвы.\n";
                        TextPrint(Text2, 1);
                        Thread.Sleep(1000);

                        string Text3 = "\n Вдруг из мглы на вас ринуло одно из чудовищ, вам предстоит сразиться с ним для спасения своей жизни.\n";
                        TextPrint(Text3, 40);
                        Thread.Sleep(200);
                        bool fight1 = hero1.Attack();
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(700);
                        if (fight1 == true)
                        {
                            string Text4 = "\n Да уж... Битва выдалась не из легких, но следопыт Арчи справился с чудовищем.\n Состояние Арчи на данный момент: ";
                            TextPrint(Text4, 40);
                            hero2.FastPrint();
                            Console.WriteLine("\n Продолжение следует...");
                        }
                        else
                        {
                            hero1.FastPrint();
                            Console.WriteLine("\n Продолжение следует...");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        string Text2 = $"Некогда могущественная страна Коперфилд, родина носителей древней магии, переживает нелёгкие времена.\n Огромный каньон — Меод, кишащий чудовищами-эльфами, гоблинами, орками - разделил её на две части: Западную и Восточную.\n Пройти сквозь него практически невозможно, " +
                      $"воздух внутри окутан беспросветной мглой, а жуткие твари с острыми когтями и огромными зубами рвут человека на куски за секунды.\n {hero2.Name} родился в дворце короля Дарклинга. Он один из потомков величайших магов, который защищает дворец." +
                       $"\n Во время экспедиции Первой Армии, генерал Кириган ждал корабль на другой стороне каньона, как в один миг темная материя каньона разошлась на две части и" +
                       $" из темноты появился корабль Первой Армии, преследуемый чудовищами - эльфами. ";
                        TextPrint(Text2, 1);
                        Thread.Sleep(1000);
                        string Text3 =  $"\n\n Времени на раздумье не было и генерал Кириган ринулся на помощь к кораблю, чтобы убить одного из чудовищей-эльфов.\n";
                        TextPrint(Text3, 40);
                        Thread.Sleep(200);
                        bool fight1 = hero2.Attack();
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                        if (fight1 == true)
                        {
                            SmallHealingBottle smallHealingBottle = new SmallHealingBottle();
                            MediumDeadBottle mediumDeadBottle = new MediumDeadBottle();
                            Spell spell = new Spell();

                            string Text4 = "\n Да уж... Битва выдалась не из легких, но генерал Кириган справился с чудовищем.\n\n Состояние Киригана на данный момент: ";
                            TextPrint(Text4, 40);
                            hero2.FastPrint();
                            Thread.Sleep(1000);

                            string Text5 = "\n Как оказалось, из чудовища выпали 2 артефакта: 'LiveWater' и 'ManaSavage'. Использовав первый артефакт 'LiveWater', Кириган восстановил часть своего здоровья: ";
                            TextPrint(Text5, 50);
                            smallHealingBottle.use(hero2);
                            hero2.FastPrint();
                            Thread.Sleep(1000);

                            string Text5_2 = "\n После чего Кириган использовал артефакт 'ManaSavage', восстановив часть своей маны: ";
                            TextPrint(Text5_2, 50);
                            mediumDeadBottle.use(hero2);
                            hero2.FastPrint();
                            Thread.Sleep(1000);

                            string Text6 = "\n Для восстановления полного здоровья, Кириган применил магическое заклинание для исцеления: ";
                            TextPrint(Text6, 40);
                            hero2.Heal();
                            hero2.FastPrint();
                            Thread.Sleep(1000);

                            string Text7 = "\n Увидев ранненых товарищей, Кириган сразу стал помогать им, используя недавно изученные им новые магические заклинания.\n Кириган подошел к первому товарищу Эрнесту и использовал заклинание 'Antidote', чтобы убрать отравление: ";
                            TextPrint(Text7, 50);
                            teammate1.FastPrint();
                            spell.Antidote(teammate1,hero2);
                            teammate1.FastPrint();
                            Thread.Sleep(1000);

                            string Text8 = "\n После помощи Эрнесту, Кириган подбежал к своей подруге Фриде, но подойдя ближе, он увидел сильный удар на ее теле, из-за чего она не дышала. Тогда Кириган применил одно из редчайших заклинаний 'Revive', чтобы возрадить ее из мертвых: ";
                            TextPrint(Text8, 40);
                            teammate2.FastPrint();
                            spell.Revive(teammate2, hero2);
                            teammate2.FastPrint();
                            Thread.Sleep(1000);

                            string Text9 = "\n Казалось, что заклинание не сработало и надежды уже не было, но через несколько минут к Фриде пришло дыхание, что значило только одно - заклинание сработало и она осталась жива.\n За это время Кириган успел помочь еще одному товарищу по имени Александр, применив заклинание 'Alive', чтобы вывести его из состояния парализованности после нападения одного из чудовищ: ";
                            TextPrint(Text9, 40);
                            teammate3.FastPrint();
                            spell.Alive(teammate3, hero2);
                            teammate3.FastPrint();
                            Console.WriteLine("\n Состояние Киригана: ");
                            hero2.FastPrint();
                            Console.WriteLine("\n Состояние Александра: ");
                            teammate3.FastPrint();
                            spell.AddNeededHealth(teammate3, hero2, 200);
                            teammate3.FastPrint();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            hero2.FastPrint();
                            Console.WriteLine("\n Продолжение следует...");
                        }
                    }
                }
            }
            else
            {

            }

            
        }
    }
}
