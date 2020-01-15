namespace GameOfLife.Interfaces
{
    public interface IInputs
    {
        Field GetUserInput();

        Field CreateInputField(string inputHeight, string inputWidth);
    }
}
