namespace GameOfLife
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class FileWorker : IFileWorker
    {
        private IConsoleFacade facade;
        private ITexts texts;

        public FileWorker()
        {
            facade = new ConsoleFacade();
            texts = new Texts();
        }

        public void Save(Field field)
        {
            var path = Configurations.PATH;
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, field);
            }
            catch (SerializationException e)
            {
                facade.Exception(texts.SerializationException(), e.Message);
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
            var path = Configurations.PATH;

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                field = (Field)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                facade.Exception(texts.DeserializationException(), e.Message);
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
