using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;
using AnimalLibrary.Species.Birds;
using System.Diagnostics;

namespace AnimalLibrary.Factories
{
    /// <summary>
    /// This class generates birds.
    /// </summary>
    public class BirdFactory
    {
        public static Bird CreateBird(BirdSpecies Species)
        {
            Bird animalObj = null;//Birdtype unknown at this time.


            //Lets determine users choice of animal.
            switch (Species)
            { 
                case BirdSpecies.Crow:
                    animalObj = new Crow();
                    break;
                case BirdSpecies.Eagle:
                    animalObj = new Eagle();
                    break;
                case BirdSpecies.Penguin:
                    animalObj = new Penguin();
                    break;

                default:
                    Debug.Assert(false, "Not implemented");
                    break;
            }

            //Set animal category
            animalObj.Category = CategoryType.Bird;

            return animalObj;//Return created instance of object.
        }
    }
}
