using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary.Species.Birds;

[Serializable()]
public class Eagle : Bird
{
    public Eagle()
    {
        isPredator = true;
        canFly = true;
    }
}
