using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Marine;
using AnimalLibrary;
using System.Diagnostics;

namespace AnimalLibrary.Factories
{
    /// <summary>
    /// This class generates marine animals.
    /// </summary>
    public static class MarineFactory
    {
        public static MarineAnimal CreateMarine(MarineSpecies Species)
        {
            MarineAnimal animalObj = null;//Marine animal type not know yet.

            //Lets determine users choice of animal.
            switch (Species)
            {
                case MarineSpecies.Crayfish:
                    animalObj = new Crayfish();
                    break;
                case MarineSpecies.Salmon:
                    animalObj = new Salmon();
                    break;

                default:
                    Debug.Assert(false, "Not implemented");
                    break;
            }

            //Set animal category
            animalObj.Category = CategoryType.Marine;

            return animalObj;//Return created instance of object marine animal
        }
    }
}
