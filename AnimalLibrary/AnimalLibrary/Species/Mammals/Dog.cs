using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Mammals;

[Serializable()]
public class Dog : Mammal
{
    public Dog()
    {
        isFurry = true;
        isPredator = false;
        ExtraAnimalInfo = "This animal is mans best friend.\n";
    }

    /// <summary>
    /// Is the dog a trained guard dog?
    /// </summary>
    public bool guardDog { get; set; }

    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strout = "This is " + name + "\nat the age of " + Age.ToString() + "\n";
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        strout = (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        if (guardDog)
        {
            strout += string.Format("This is a trained guarddog.");
        }
        else
            strout += "This dog is not trained.";

        strout += (isFurry ? "This animal is furry." : "This animal is not furry.");
        return strout;
    }
    #endregion

}
