using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class DeadBottle : ArtifactRealization
    {
        double mana_amount;
        public double Mana_amount
        {
            get { return mana_amount; }
            set { mana_amount = value; }
        }
        public DeadBottle(double artifact_power, double mana_amount) : base(artifact_power, false)
        {
            Mana_amount = mana_amount;
        }
        override
        public void use(Magician magician)
        {
            double manaBefore = magician.Mana;
            double manaAfter = manaBefore + Mana_amount;
            double manaDifference = manaAfter - manaBefore;
            magician.Mana = manaAfter;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n Было восстановлено {manaDifference} маны, использовав бутылку с мертвой водой.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public class SmallDeadBottle : DeadBottle
    {
        public SmallDeadBottle() : base(0, 10)
        {

        }
    }

    public class MediumDeadBottle : DeadBottle
    {
        public MediumDeadBottle() : base(0, 25)
        {

        }
    }

    public class BigDeadBottle : DeadBottle
    {
        public BigDeadBottle() : base(0, 50)
        {

        }
    }
}
