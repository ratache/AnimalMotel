using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//added
using System.Drawing;
using System.Windows.Media.Imaging;
//custom
using AnimalLibrary;
using AnimalLibrary.Factories;
using AnimalLibrary.Serialization;
using PictrureLibrary;
//static dlls = bitmapConverter for converting bitmap to bitmapsource

namespace a3APU
{
    class AnimalHandler
    {           
        //Animals list
        List<Animal> apuResidents = new List<Animal>();
        //AnimalHandler objects
        AnimalImage anImage = new AnimalImage();
        Animal animalis;

        string dataPath;
        
        private CategoryType getSpecCategory(int index)
        {
            CategoryType outCat = (CategoryType)index;
            return outCat;
        }

        /// <summary>
        /// Returns the class type as string
        /// </summary>
        /// <param name="ani">Animal object</param>
        /// <returns>Animal object type string</returns>
        private string getSpeciesStr(Animal ani)
        {
            string outCat = ani.ToString();
            return outCat;
        }

        /// <summary>
        /// Call this to get the categories of the animal library.
        /// </summary>
        /// <returns>Animal categories list</returns>
        public List<string> getListCategories()
        {
            return Enum.GetNames(typeof(CategoryType)).ToList();
        }

        /// <summary>
        /// Call this to get the species depending on the selected category.
        /// </summary>
        /// <param name="animalCategory"></param>
        /// <returns>A list of strings with species</returns>
        public List<string> getListSpecies(int animalCategory)
        {
            if (animalCategory == 0)
                return Enum.GetNames(typeof(BirdSpecies)).ToList();
            else if (animalCategory == 1)
                return Enum.GetNames(typeof(InsectSpecies)).ToList();
            else if (animalCategory == 2)
                return Enum.GetNames(typeof(MammalSpecies)).ToList();
            else if (animalCategory == 3)
                return Enum.GetNames(typeof(MarineSpecies)).ToList();
            else
                return Enum.GetNames(typeof(ReptileSpecies)).ToList();
        }

        /// <summary>
        /// Returns the gender values.
        /// </summary>
        /// <returns>A list with gender strings</returns>
        public List<string> getListGender()
        {
            return Enum.GetNames(typeof(GenderType)).ToList(); 
        }

        public void createAnimal(int speciesIndex, string named, int age, int categoryIndex, int genderIndex)
        {
            animalis = castAnimal(speciesIndex, (CategoryType)categoryIndex);
            animalis.name = named;
            animalis.Age = age;
            animalis.Category = (CategoryType)categoryIndex;
            animalis.Gender = (GenderType)genderIndex;
            animalis.Species = getSpeciesStr(animalis);
            apuResidents.Add(animalis);
        }

        public void createAnimalatIndex(int listindex, int speciesIndex, string named, int age, int categoryIndex, int genderIndex)
        {
            apuResidents.RemoveAt(listindex);
            animalis = castAnimal(speciesIndex, (CategoryType)categoryIndex);
            animalis.name = named;
            animalis.Age = age;
            animalis.Category = (CategoryType)categoryIndex;
            animalis.Gender = (GenderType)genderIndex;
            animalis.Species = getSpeciesStr(animalis);
            apuResidents.Insert(listindex,animalis);
        }

        private Animal castAnimal(int speciesIndex, CategoryType type)
        {
            //Checking which object to create:
            if (type == CategoryType.Bird)
            {
                BirdSpecies speciestype = (BirdSpecies)speciesIndex;
                animalis = BirdFactory.CreateBird(speciestype);
            }
            else if (type == CategoryType.Insect)
            {
                InsectSpecies insectSpec = (InsectSpecies)speciesIndex;
                animalis = InsectFactory.CreateInsect(insectSpec);
            }
            else if (type == CategoryType.Mammal)
            {
                MammalSpecies mammalSpec = (MammalSpecies)speciesIndex;
                animalis = MammalFactory.CreateMammal(mammalSpec);
            }
            else if (type == CategoryType.Marine)
            {
                MarineSpecies marineSpec = (MarineSpecies)speciesIndex;
                animalis = MarineFactory.CreateMarine(marineSpec);
            }
            else if (type == CategoryType.Reptile)
            {
                ReptileSpecies reptileSpec = (ReptileSpecies)speciesIndex;
                animalis = ReptileFactory.CreateReptile(reptileSpec);
            }

            return animalis;
        }

        public Animal getSpecificAnimal(int index)
        {
                return apuResidents[index];
        }

        public int getNumberofAnimals()
        {
            if (apuResidents.Count > 0)
                return apuResidents.Count;
            else
                return 0;
        }

        public List<Animal> getAnimalsList()
        {
            return apuResidents;
        }

        #region Assembly dependent methods
        /// <summary>
        /// Uses the picturelibrary.dll to fetch a picture for
        /// the equivalent animal category. Since this is a WPF
        /// application the image must be converted into a bitmapsource
        /// to be compatible with GUI. This is done with the bitmap converter.
        /// </summary>
        /// <param name="picStr"></param>
        /// <returns></returns>
        public BitmapSource fetchCatPic(string picStr)
        {
            Bitmap img = new Bitmap(anImage.GetImageForCategory(picStr));
            BitmapSource bImage = BitmapConverter.CreateBitmapSourceFromBitmap(img);
            return bImage;
        }

        public bool OpenData(string path)
        {
            dataPath = path;
            apuResidents = Serialization<List<Animal>>.OpenData(dataPath);
            if (getNumberofAnimals() > 0)
                return true;
            else
                return false;
        }

        public bool SaveData()
        {
            if (dataPath != null && getNumberofAnimals()>0)
            {
                if (Serialization<List<Animal>>.SaveData(ref apuResidents, dataPath))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool SaveDataAs(string path)
        {
            dataPath = path;

            if (Serialization<List<Animal>>.SaveData(ref apuResidents, dataPath))
                return true;
            else
                return false;
        }

        #endregion
    }
}
