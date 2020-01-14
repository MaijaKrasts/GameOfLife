namespace GameOfLife.Interfaces
{
    public interface IFieldAlterations
    {
        Field GenerateField(Field field);
        Field SeedField(Field field);
    }
}
