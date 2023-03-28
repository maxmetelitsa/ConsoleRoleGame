using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class PoisonousSaliva : ArtifactRealization
    {
        public PoisonousSaliva(double artifact_power) : base(artifact_power, true)
        {
            
        }
        override
        public void use(Magician magician)
        {
            double healthBefore = magician.HealthNow;
            double healthAfter = healthBefore - Artifact_power;
            double healthDifference = healthBefore - healthAfter;
            magician.HealthNow = healthAfter;
            magician.State = State.Poisoned;
            Console.WriteLine($"\n Герой был отравлен, а также ему было нанесено {healthDifference} урона, использовав ядовитую слюну.");
        }
    }
}
