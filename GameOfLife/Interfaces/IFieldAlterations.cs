namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;

    public interface IFieldAlterations
    {
        Field GenerateField(Field field);

        Field SeedField(Field field);

        List<Field> GetFieldList();
    }
}
