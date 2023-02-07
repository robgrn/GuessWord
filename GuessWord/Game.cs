namespace GuessWord;

public class Game
{
    private GameWord gameWord;
    
    public List<Guess> Guesses { get; }
    public int GuessesLeft { get; private set; }

    public Game(string newWord)
    {
        gameWord = new GameWord(newWord);
        Guesses = new List<Guess>();
        GuessesLeft = 6;
    }

    public Guess MakeGuess(string word)
    {
        LetterState[] guessState = new LetterState[word.Length];
        Dictionary<char, int> tempLetterCount = new Dictionary<char, int>(gameWord.UniqueLetterCount);

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == gameWord.Word[i])
            {
                guessState[i] = LetterState.CORRECT;
                if (tempLetterCount[word[i]] > 0)
                {
                    tempLetterCount[word[i]]--;
                }
                else
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if ((word[i] == word[j]) && (guessState[j] == LetterState.PRESENT))
                        {
                            guessState[j] = LetterState.ABSENT;
                            break;
                        }
                    }
                }
            }
            else if (tempLetterCount.ContainsKey(word[i]) && tempLetterCount[word[i]] > 0)
            {
                guessState[i] = LetterState.PRESENT;
                tempLetterCount[word[i]]--;
            }
            else
            {
                guessState[i] = LetterState.ABSENT;
            }
        }

        Guess guess = new Guess(word, guessState);
        Guesses.Add(guess);
        return guess;
    }

    public bool IsGuessCorrect(Guess guess)
    {
        foreach (LetterState state in guess.State)
        {
            if (state != LetterState.CORRECT)
                return false;
        }

        return true;
    }

    public void ShowGuessWord(Guess guess)
    {
        ConsoleColor savedForegroundColour = Console.ForegroundColor;
        for (int i = 0; i < guess.Word.Length; i++)
        {
            if (guess.State[i] == LetterState.ABSENT)
                Console.ForegroundColor = ConsoleColor.DarkGray;
            else if (guess.State[i] == LetterState.PRESENT)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (guess.State[i] == LetterState.CORRECT)
                Console.ForegroundColor = ConsoleColor.Green;
            
            Console.Write(guess.Word[i]);
        }
        Console.WriteLine();
        Console.ForegroundColor = savedForegroundColour;
    }

    public static void Main(string[] args)
    {
        Game game = new Game(WordList.RandomWord());
        bool won = false;

        while (game.GuessesLeft > 0 && !won)
        {
            Console.WriteLine("Make a 5 letter word guess:");
            string? guessWord = Console.ReadLine();
            while (guessWord == null || guessWord.Length != 5 || !WordList.Words.Contains(guessWord.ToUpper()))
            {
                Console.WriteLine("Guess must be a valid 5 letter word. Try again:");
                guessWord = Console.ReadLine();
            }

            guessWord = guessWord.ToUpper();
            game.GuessesLeft--;
            Guess guess = game.MakeGuess(guessWord);
            won = game.IsGuessCorrect(guess);
            game.ShowGuessWord(guess);
        }

        if (won)
        {
            Console.WriteLine("Well done! You won!");
        }
        else
        {
            Console.WriteLine("Sorry, you lost.");
            Console.WriteLine($"The word was: {game.gameWord.Word}");
        }
    }
}
