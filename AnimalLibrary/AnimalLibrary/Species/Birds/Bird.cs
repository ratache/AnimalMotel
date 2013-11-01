using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary.Species.Birds
{
    [Serializable]
    public class Bird:Animal
    {
        /// <summary>
        /// Is the bird a wild animal?
        /// </summary>
        public bool isPredator;
        public bool canFly;
        public bool isTagged { get; set; }

        #region "Implementation of abstract methods"
        public override string GetAnimalSpecificData()
        {
            string strout = "This is " + name + ".\n";
            strout += name + " is a " + Gender.ToString() + "\nand " + Age.ToString() + " years old.\n";
            string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
            strout += (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

            if (isTagged)
            {
                strout += string.Format("This bird is tagged.\n");
            }
            else
                strout += string.Format("This bird is not tagged.\n");

            strout += (isPredator ? "This animal is a predator.\n" : "This animal is not a predator.\n");
            strout += (canFly ? "This animal can fly.\n" : "This animal cannot fly.\n");
            return strout;
        }

        public override string GetAnimalBasicDataString()
        {
            return (name + "\t" + Age.ToString() + "\t" + Gender.ToString());
        }
        #endregion
    }
}
