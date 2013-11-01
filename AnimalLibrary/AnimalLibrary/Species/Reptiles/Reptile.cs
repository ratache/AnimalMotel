using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary.Species.Reptiles
{
    [Serializable]
    public abstract class Reptile:Animal
    {
        public bool isPoisonous { get; set; }//Is this animal poisonous?
        
        public override string GetAnimalBasicDataString()
        {
            return (name + "\t" + Age.ToString() + "\t" + Gender.ToString());
        }
    }
}
