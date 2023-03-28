using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public class VasiliskEye : ArtifactRealization
    {
        public VasiliskEye(double artifact_power) : base(artifact_power, false)
        {

        }
        override
        public void use(Magician magician)
        {
            if(magician.State != State.Dead)
            {
                magician.State = State.Paralyzed;
            }
            else
            {
                Console.WriteLine("\n Герой находится в состоянии 'мертв' из-за чего невозможно использовать артифакт 'глаз Василиска'.");
            }
        }
    }
}
