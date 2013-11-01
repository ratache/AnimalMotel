using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Reptiles;

[Serializable()]
public class Cobra : Reptile
{
    public Cobra()
    {
        isPoisonous = true;
        ExtraAnimalInfo = "This animal is reverred in India.";
    }


    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        string strout = (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        if (isPoisonous)
        {
            strout += string.Format("\nThis animal is poisonous.");
        }
        else
            strout += "\nThis animal is not poisonous.";

        return strout;
    }
    #endregion

}

