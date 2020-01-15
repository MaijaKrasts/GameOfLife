namespace GameOfLife.Interfaces
{
    public interface IValidatior
    {
        bool ValidateInt(string input);

        bool ValidateString(string input);

        bool ValidateQuestion(string input);
    }
}
