namespace GameOfLife.Interfaces
{
    public interface IFile
    {
        Field ReadInformation(Field field);

        void SaveInformation(string inputHeight, string inputWidth);
    }
}
