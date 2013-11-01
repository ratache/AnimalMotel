using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Factories;

namespace AnimalLibrary
{
    /// <summary>
    /// This class implements the animal interface IAnimal
    /// </summary>
    [Serializable]
    public abstract class Animal : IAnimal
    {
        public string name {get;set;}

        public int Age { get; set; }
        public string ExtraAnimalInfo { get; set; }
        
        public GenderType Gender { get; set; }
        public CategoryType Category { get; set; }
        public string Species { get; set; }

        public bool boolValue1 { get; set; }
        /*public bool boolValue2 { get; set; }
        public bool boolValue3 { get; set; }*/

        abstract public string GetAnimalSpecificData();
        abstract public string GetAnimalBasicDataString();
    }
}
