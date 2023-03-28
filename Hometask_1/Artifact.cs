using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_1
{
    public interface Artifact
    {
        void use(Magician magician);
    }
    public abstract class ArtifactRealization : Artifact
    {
        double artifact_power;
        public double Artifact_power
        {
            get { return artifact_power; }
            set { artifact_power = value; }
        }
        bool renewability;
        public bool Renewability
        {
            get { return renewability; }
            set { renewability = value; }
        }
        public ArtifactRealization(double artifact_power, bool renewability)
        {
            Artifact_power = artifact_power;
            Renewability = renewability;
        }
        public abstract void use(Magician magician);
    }
}
