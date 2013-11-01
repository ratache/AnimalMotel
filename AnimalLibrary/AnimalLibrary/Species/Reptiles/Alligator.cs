using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Reptiles;

[Serializable()]
public class Alligator : Reptile
{
    public Alligator()
    {
        isPoisonous = false;
        ExtraAnimalInfo = "This animal isn't poisonous \nbut still very dangerous.";
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

