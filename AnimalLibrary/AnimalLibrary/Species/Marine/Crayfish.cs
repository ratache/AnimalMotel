using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Marine;

[Serializable()]
public class Crayfish:MarineAnimal
{
    public Crayfish()
    {
        isFish = false;//Is a fish?
        isOceanic = true;//Swims in saltwater?
        ExtraAnimalInfo = "This animal has a exoskeleton.";
    }

    public bool edible { get; set; }

    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        string strout = (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        if (isFish)
        {
            strout += string.Format("\nThis is a fish.");
        }
        else
            strout += "\nThis is not a fish";

        strout += (isOceanic ? "\nSwims in saltwater." : "\nSwims in freshwater.");
        return strout;
    }
    #endregion  
}

