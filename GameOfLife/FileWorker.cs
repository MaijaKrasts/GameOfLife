namespace GameOfLife
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using GameOfLife.Interfaces;

    public class FileWorker : IFileWorker
    {
        private ConsoleFacade facade;

        public FileWorker()
        {
            facade = new ConsoleFacade();
        }

        public void Save(Field field)
        {
            var path = Configurations.PATH;
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, field);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public Field Load()
        {
            // Declare the hashtable reference.
            Field field = null;
            var path = Configurations.PATH;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                field = (Field)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return field;

        }

    }
}
