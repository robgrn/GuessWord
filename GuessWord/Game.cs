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

    public void ShowGuessColours()
    {
        Console.Clear();
        ConsoleColor fgColour = Console.ForegroundColor;

        foreach (Guess guess in Guesses)
        {
            for (int i = 0; i < guess.State.Length; i++)
            {
                Console.ForegroundColor = stateColour(guess.State[i]);
                Console.Write("+---+ ");
            }
            Console.WriteLine();

            for (int i = 0; i < guess.State.Length; i++)
            {
                Console.ForegroundColor = stateColour(guess.State[i]);
                Console.Write($"| {guess.Word[i]} | ");
            }
            Console.WriteLine();

            for (int i = 0; i < guess.State.Length; i++)
            {
                Console.ForegroundColor = stateColour(guess.State[i]);
                Console.Write("+---+ ");
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = fgColour;
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

    private ConsoleColor stateColour(LetterState state)
    {
        ConsoleColor colour;

        if (state == LetterState.ABSENT)
            colour = ConsoleColor.DarkGray;
        else if (state == LetterState.PRESENT)
            colour = ConsoleColor.Yellow;
        else if (state == LetterState.CORRECT)
            colour = ConsoleColor.Green;
        else
            colour = Console.ForegroundColor;

        return colour;
    }

    public static void Main(string[] args)
    {
        Game game = new Game(WordList.RandomWord());
        bool won = false;
        
        Console.Clear();
        Console.WriteLine("Guess the 5 letter word in 6 guesses.");

        while (game.GuessesLeft > 0 && !won)
        {
            Console.Write("> ");
            string? guessWord = Console.ReadLine();
            while (guessWord == null || guessWord.Length != 5 || !WordList.IsWord(guessWord.ToUpper()))
            {
                Console.WriteLine("Guess must be a valid 5 letter word. Try again.");
                Console.Write("> ");
                guessWord = Console.ReadLine();
            }

            guessWord = guessWord.ToUpper();
            game.GuessesLeft--;
            Guess guess = game.MakeGuess(guessWord);
            won = game.IsGuessCorrect(guess);
            game.ShowGuessColours();
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
