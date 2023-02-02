using Xunit;

namespace GuessWord.Tests;

public class GuessTests
{
    [Fact]
    public void Letter_in_matching_position_is_correct()
    {
        Game game = new Game("abbbb");
        LetterState[] expected = new LetterState[] {
            LetterState.CORRECT, LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT
        };
        
        game.MakeGuess("azzzz");
        LetterState[] actual = game.Guesses[0].State;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Letter_is_only_present()
    {
        Game game = new Game("abbbb");
        LetterState[] expected = new LetterState[] {
            LetterState.ABSENT, LetterState.PRESENT, LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT
        };

        game.MakeGuess("zazzz");
        LetterState[] actual = game.Guesses[0].State;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void No_letters_are_present_or_correct()
    {
        Game game = new Game("bbbbb");
        LetterState[] expected = new LetterState[] {
            LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT
        };

        game.MakeGuess("zzzzz");
        LetterState[] actual = game.Guesses[0].State;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Too_many_duplicate_present_letters_are_absent()
    {
        Game game = new Game("abbbb");
        LetterState[] expected = new LetterState[] {
            LetterState.ABSENT, LetterState.PRESENT, LetterState.ABSENT, LetterState.ABSENT, LetterState.ABSENT
        };

        game.MakeGuess("zaazz");
        LetterState[] actual = game.Guesses[0].State;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Letter_in_matching_position_found_after_being_marked_present()
    {
        Game game = new Game("bbabb");
        LetterState[] expected = new LetterState[] {
            LetterState.ABSENT, LetterState.ABSENT, LetterState.CORRECT, LetterState.ABSENT, LetterState.ABSENT
        };

        game.MakeGuess("azazz");
        LetterState[] actual = game.Guesses[0].State;

        Assert.Equal(expected, actual);
    }
}
