using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;
using System.Diagnostics;
using AnimalLibrary.Species.Reptiles;

namespace AnimalLibrary.Factories
{
    /// <summary>
    /// This class generates reptiles.
    /// </summary>
    public class ReptileFactory
    {
        public static Reptile CreateReptile(ReptileSpecies Species)
        {
            Reptile animalObj = null;//Animaltype unknown at this time.

            //Lets determine users choice of animal.
            switch (Species)
            {
                case ReptileSpecies.Alligator:
                    animalObj = new Alligator();
                    break;
                case ReptileSpecies.Cobra:
                    animalObj = new Cobra();
                    break;
                case ReptileSpecies.Komodo:
                    animalObj = new Komodo();
                    break;

                default:
                    Debug.Assert(false, "Not implemented");
                    break;
            }

            //Set animal category
            animalObj.Category = CategoryType.Reptile;

            return animalObj;//Return created instance of object.
        }
    }
}
