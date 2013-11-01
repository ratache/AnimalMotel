using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary.Species.Mammals
{
    [Serializable]
    public abstract class Mammal:Animal
    {
        public bool isFurry { get; set; }
        public bool isPredator { get; set; }

        public override string GetAnimalBasicDataString()
        {
            return (name + "\t" + Age.ToString() + "\t" + Gender.ToString());
        }
    }
}
