using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Birds;

[Serializable()]
public class Crow : Bird
{
    public Crow()
    {
        isPredator = false;
        canFly = true;
        ExtraAnimalInfo = "The crow is black and grey.\n";
    }
}
