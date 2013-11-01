using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Birds;

[Serializable()]
public class Penguin : Bird
{
    public Penguin()
    {
        isPredator = true;
        canFly = false;
    }
    
}
