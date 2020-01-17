namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class FileWorker : IFileWorker
    {
        private IConsoleFacade facade;
        private string file;

        public FileWorker()
        {
            facade = new ConsoleFacade();
            file = Configurations.FILE;
        }

        public void Save(Field field)
        { 
            FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, file), FileMode.Create, FileAccess.Write);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, field);
            }
            catch (SerializationException e)
            {
                facade.Exception(Texts.SerializationException, e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public Field Load()
        {
            Field field = null;
            var path = Path.Combine(Environment.CurrentDirectory, Configurations.FILE);

            FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, file), FileMode.Open, FileAccess.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                field = (Field)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                facade.Exception(Texts.DeserializationException, e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return field;

        }

        public void SaveMultiple(List<Field> fieldList)
        {
            var file = Configurations.FILE;
            FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, file), FileMode.Create, FileAccess.Write);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                foreach (var field in fieldList)
                {
                    formatter.Serialize(fs, field);
                }
            }
            catch (SerializationException e)
            {
                facade.Exception(Texts.SerializationException, e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

        }
    }
}
