//Programming using .NET advanced course
//Code Example : Bee.vb
//Farid Naisan May 2011, rev June 2012 (minor changes)

//You may copy and use this code in your project. You may also amend the code 
//and bring changes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Species.Insects;


/// <summary>
/// This class inherits the Insect class, and then it defines
/// properties and methods that are particular to the Bee species
/// </summary>
[Serializable()]
public class Bee : Insect
{
    //Fields particular to Bees
    //liters or any other unit
    private int m_amountOfHoneyPerMonth;

    private bool m_isHoneyBee;
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Bee()
    {
    }

    /// <summary>
    /// Gets or sets the amount of honey this bee
    /// can produce (or has produced) per month
    /// </summary>
    public int amountOfHoneyProducedInAMonth
    {
        get { return this.m_amountOfHoneyPerMonth; }
        set { this.m_amountOfHoneyPerMonth = value; }
    }
    /// <summary>
    /// Put your documentation here
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public bool IsHoneyBee
    {
        get { return m_isHoneyBee; }
        set { m_isHoneyBee = value; }
    }


    #region "Implementation of abstract methods"

    public override string GetAnimalSpecificData()
    {
        string strInfo = ExtraAnimalInfo;  //Call to porperty in base class (Animal.vb)
        string strout = "This is " + name + "\n";
        strout += (string.IsNullOrEmpty(strInfo) ? string.Empty : strInfo);

        if (IsHoneyBee)
        {
            strout += string.Format("\nProduces {0} liters of honey", m_amountOfHoneyPerMonth);
        }
        //strout += Environment.NewLine + SetStinkAndInvasiveData();
        strout += (IsPoisonous ? "This bee type is poisonous." : "This bee type is not poisonous.");
        strout += SetStinkAndInvasiveData();
        return strout;
    }

    //A VG (ECT A and B) part
    /// <summary>
    /// Implementation of abstract method defined in base class
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public override string SetStinkAndInvasiveData()
    {
        string strOut = "\nNot stinky but it can be invasive when bothered!";
        return strOut;
    }


    #endregion

}
