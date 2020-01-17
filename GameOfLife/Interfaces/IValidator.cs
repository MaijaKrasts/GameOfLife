namespace GameOfLife.Interfaces
{
    public interface IValidator
    {
        bool ValidateInt(string input);

        bool ValidateString(string input);

        bool ValidateQuestion(string input);
    }
}
