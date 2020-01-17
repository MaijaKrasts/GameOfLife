using System.Collections.Generic;

namespace GameOfLife.Interfaces
{
    public interface IFileWorker
    {
        void Save(Field field);

        Field Load();
        
        void SaveMultiple(List<Field> fieldList);
    }
}
