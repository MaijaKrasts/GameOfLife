namespace GameOfLife.Interfaces
{
    public interface IFileWorker
    {
        void Save(Field field);

        Field Load();
    }
}
