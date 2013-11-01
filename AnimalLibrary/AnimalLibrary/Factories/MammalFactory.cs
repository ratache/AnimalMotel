using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;
using AnimalLibrary.Species.Mammals;
using System.Diagnostics;

namespace AnimalLibrary.Factories
{
    /// <summary>
    /// This class generates mammals.
    /// </summary>
    public class MammalFactory
    {
        public static Mammal CreateMammal(MammalSpecies Species)
        {
            Mammal animalObj = null;//Animaltype unknown at this time.

            //Lets determine users choice of animal.
            switch (Species)
            {
                case MammalSpecies.Cat:
                    animalObj = new Cat();
                    break;
                case MammalSpecies.Dog:
                    animalObj = new Dog();
                    break;
                case MammalSpecies.Gorilla:
                    animalObj = new Gorilla();
                    break;

                default:
                    Debug.Assert(false, "Not implemented");
                    break;
            }

            //Set animal category
            animalObj.Category = CategoryType.Mammal;

            return animalObj;//Return created instance of object.
        }
    }
}
