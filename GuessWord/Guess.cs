namespace GuessWord;

public class Guess
{
    public string Word { get; }
    public LetterState[] State { get; }

    internal Guess(string word, LetterState[] state)
    {
        Word = word;
        State = state;
    }
}
