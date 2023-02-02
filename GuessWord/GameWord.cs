namespace GuessWord;

internal class GameWord
{
    public string Word { get; }
    public Dictionary<char, int> UniqueLetterCount { get; }

    internal GameWord(string word)
    {
        Word = word;
        UniqueLetterCount = new Dictionary<char, int>(word.Length);
        
        foreach (char letter in word)
        {
            if (UniqueLetterCount.ContainsKey(letter))
                UniqueLetterCount[letter]++;
            else
                UniqueLetterCount.Add(letter, 1);
        }
    }
}
