using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class LightningStaff : ArtifactRealization
    {
        double staff_power;
        public double Staff_power
        {
            get { return staff_power; }
            set { staff_power = value; }
        }
        public LightningStaff(double artifact_power, double staff_power) : base(artifact_power, true)
        {
            Staff_power = staff_power;
        }
        override
        public void use(Magician magician)
        {

        }
        public void useStaff(Magician magician, double damage_power)
        {
            double powerBefore = 0;
            double powerAfter = 0;
            double powerDifference = 0;
            if (Staff_power > 0)
            {
                if (damage_power > Staff_power)
                {
                    damage_power = Staff_power;
                    powerDifference = damage_power;
                }
                else
                {
                    powerBefore = Staff_power;
                    powerAfter = Staff_power - damage_power;
                    powerDifference = powerAfter - powerBefore;
                }
                magician.HealthNow -= damage_power;
                Staff_power -= damage_power;
                Console.WriteLine($"Было нанесено {powerDifference} урона, использовав посох 'Молния'.\n Мощность посоха: {Staff_power}");

            }
        }
    }
}
