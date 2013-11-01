using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Mammals;

[Serializable()]
public class Cat:Mammal
{
    public Cat()
    {
        isPredator = true;
        isFurry = true;
        ExtraAnimalInfo = "Cats don't get along with dogs very well.\n";
    }

    /// <summary>
    /// Is the cat a indoor or outdoors cat
    /// </summary>
    public bool outdoorCat{ get; set; }

    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strout = "This is " + name + "\nat the age of "+ Age.ToString() +"\n";
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        strout = (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        if (outdoorCat)
        {
            strout += string.Format("This cat is an outdoor cat.\n");
        }
        else
            strout += "This cat is an indoor cat.\n";

        strout += (isFurry ? "This animal is furry.\n" : "This animal is not furry.\n");
        return strout;
    }
    #endregion

}
