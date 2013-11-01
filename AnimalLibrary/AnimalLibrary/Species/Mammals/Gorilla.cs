using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Mammals;

[Serializable()]
public class Gorilla : Mammal
{
    public Gorilla()
    {
        isFurry = true;
        isPredator = false;
    }

    /// <summary>
    /// Is the cat a indoor or outdoors cat
    /// </summary>
    public bool wildGorilla { get; set; }

    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strout = "This is " + name + "\nat the age of " + Age.ToString() + "\n";
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        strout = (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        strout += (isFurry ? "This animal is furry.\n" : "This animal is not furry.\n");
        return strout;
    }
    #endregion

}
