//Programming using .NET advanced course
//Code Example : Insect.cs
//Farid Naisan May 2011, revised June 2012

//You may copy and use this code in your project. You may also amend the code 
//and bring changes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary;

namespace AnimalLibrary.Species.Insects
{
    /// <summary>
    /// This class inherits Animal class, and then it defines
    /// properties and methods that are particular to insects.
    /// The class is an abstract class and must be inherited.
    /// </summary>
    [Serializable]
   public abstract class Insect : Animal
    { 
	    //Is the insect poisonous
	    private bool m_ispoisonous;
	   
        /// <summary>
	    /// Default constructor
	    /// </summary>
	    public Insect()
	    {
	    }

	    //property related to m_ispoisonous
	    public bool IsPoisonous 
        {
		    get { return m_ispoisonous; }
		    set { m_ispoisonous = value; }
	    }
	    //A VG (ECT A and B) part
	    //An abstract method for insect sub classes
	    /// <summary>
	    /// For ll insects objects, info on their invasiveness and stinkynss
	    /// should be provided
	    /// </summary>
	    public abstract string SetStinkAndInvasiveData();

        public override string GetAnimalBasicDataString()
        {
            return (name + "\t" + Age.ToString() + "\t" + Gender.ToString());
        }

    }

}
