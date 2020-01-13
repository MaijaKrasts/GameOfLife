namespace GameOfLife.Interfaces
{
    internal interface IGameSetup
    {
        Field GetUserInput();

        Field VertifyInput(string inputHeight, string inputWidth, Field field);

        bool ValidateInt(string input);
    }
}
