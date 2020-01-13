namespace GameOfLife.Interfaces
{
    internal interface ISeedField : IField
    {
        Field SeedField(Field field);
    }
}
