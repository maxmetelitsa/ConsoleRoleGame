using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class HealingBottle : ArtifactRealization
    {
        double heal_amount;
        public double Heal_amount
        {
            get { return heal_amount; }
            set { heal_amount = value; }
        }
        public HealingBottle(double artifact_power, bool renewability, double heal_amount) : base(artifact_power, renewability)
        {
            Heal_amount = heal_amount;
        }
        override
        public void use(Magician magician)
        {
            double healthBefore = magician.HealthNow;
            double healthAfter = healthBefore + Heal_amount;
            double healthDifference = healthAfter - healthBefore;
            magician.HealthNow = healthAfter;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n Было восстановлено {healthDifference} здоровья, использовав бутылку с живой водой.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public class SmallHealingBottle : HealingBottle
    {
        public SmallHealingBottle() : base(0, false, 10)
        {

        }
    }

    public class MediumHealingBottle : HealingBottle
    {
        public MediumHealingBottle() : base(0, false, 25)
        {

        }
    }

    public class BigHealingBottle : HealingBottle
    {
        public BigHealingBottle() : base(0, false, 50)
        {

        }
    }
}
