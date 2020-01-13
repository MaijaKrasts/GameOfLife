namespace GameOfLife.Interfaces
{
    public interface IField
    {
        void GenerateFieldAndRun(Field field);

        Field GenerateField(Field field);
    }
}
