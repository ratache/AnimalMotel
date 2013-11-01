using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary.Species.Marine
{
    [Serializable]
    public abstract class MarineAnimal:Animal//Marine animals abstract class
    {
        public bool isFish{get;set;}//Is it a fish?
        public bool isOceanic { get; set; }//Swims in ocean?

        public override string GetAnimalBasicDataString()
        {
            return (name + "\t" + Age.ToString() + "\t" + Gender.ToString());
        }
    }
}
