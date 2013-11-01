using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AnimalLibrary.Serialization
{
    public static class Serialization<T>
    {
        /// <summary>
        /// This class saves incoming data as a .dat file.
        /// Requirements for all incoming objects is the 
        /// [Serialization]-tag on the classinstances
        /// to be saved.
        /// </summary>
        /// <param name="genericInput"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool SaveData(ref T genericInput, string name)
        {
            T temp = genericInput;
            string fileName = name + ".dat";

            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, temp);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<Animal> OpenData(string file)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            List<Animal> retrievedData;

            using (Stream fStream = File.OpenRead(file))
            {
                retrievedData = (List<Animal>)binFormat.Deserialize(fStream);
            }

            return retrievedData;
        }
    }
}