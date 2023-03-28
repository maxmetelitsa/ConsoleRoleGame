using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class Decoction : ArtifactRealization
    {
        Random random = new Random();
        public Decoction(double artifact_power) : base(artifact_power, false)
        {

        }
        override
        public void use(Magician magician)
        {
            int st = random.Next(2);
            if (magician.State == State.Poisoned)
            {
                if (st == 0)
                {
                    magician.State = State.Weakened;
                }
                else
                {
                    magician.State = State.Healthy;
                }
            }
            else
            {
                Console.WriteLine("\n Герой не находится в состоянии 'отравлен' для выполнения данного заклинания.");
            }
        }
    }
}
