//Programming using .NET advanced course
//Code Example : InsectFactory.cs
//Farid Naisan May 2011, Rev June 2012 (Minor changes)
 
//You may copy and use this code in your project. You may also amend the code 
//and bring changes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary;
using AnimalLibrary.Species.Insects;
using System.Diagnostics;

namespace AnimalLibrary.Factories
{
    /// <summary>
    /// This class has a set of methods for  creating different animals of the Insect category.
    /// Other categories of animals (Mammals, Birds, etc) can have its own class similar to this one.
    /// </summary>
  
    public class InsectFactory
    {
        /// <summary>
        /// Create an animal object of a species (Bee,Butterfly) of Insect cateogry.
        /// </summary>
        /// <param name="Species">Species: Bee, Butterfly, etc.</param>
        /// <returns>Object of the Species type.</returns>
        /// <remarks></remarks>
        public static Insect CreateInsect(InsectSpecies Species)
        {

            Insect animalObj = null;        //type not known at this time

            //type determined by late binding
            switch (Species)
            {
                case InsectSpecies.Bee:
                    animalObj = new Bee();           //Late binding
                    break; 
              //Continue with the rest
                case InsectSpecies.Butterfly:
                    animalObj = new Butterfly();    //Late binding
                    break;

                default:
                    Debug.Assert(false, "To be completed!");
                    break;
            }

            //Set the category
            animalObj.Category = CategoryType.Insect;

            return animalObj;     //return the created animal object.
        }

    }

}
