namespace GameOfLife.Interfaces
{
    public interface ISeedField : IField
    {
        Field SeedField(Field field);
    }
}
