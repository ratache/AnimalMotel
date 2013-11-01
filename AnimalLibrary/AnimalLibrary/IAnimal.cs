using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Factories;

namespace AnimalLibrary
{
    /// <summary>
    /// Interface IAnimal containing som rules for the sub classes
    /// </summary>
    interface IAnimal
    {
        string name { get; set; }
        GenderType Gender { get; set; }//Gender enum
        int Age { get; set; }
        CategoryType Category { get; set; }//Animaltype enum

        //Methods
        string GetAnimalSpecificData();//Specific data for every species
        string GetAnimalBasicDataString();//Specific string for every animal object
    }
}
