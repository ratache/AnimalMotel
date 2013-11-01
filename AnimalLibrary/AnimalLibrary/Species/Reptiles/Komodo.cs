using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Reptiles;

[Serializable()]
public class Komodo : Reptile
{
    public Komodo()
    {
        isPoisonous = false;
    }


    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        string strout = (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        if (isPoisonous)
        {
            strout += string.Format("This animal is poisonous.");
        }
        else
            strout += "This animal is not poisonous.";

        return strout;
    }
    #endregion

}

