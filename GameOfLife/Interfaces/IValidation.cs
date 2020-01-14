namespace GameOfLife.Interfaces
{
    public interface IValidation
    {
        Field VertifyInput(string inputHeight, string inputWidth);

        bool ValidateInt(string input);

        bool ValidateString(string input);

        bool ValidateQuestion(string input);
    }
}
