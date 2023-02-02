namespace GuessWord;

internal static class WordList
{
    private static readonly Random random = new Random();
    private static readonly HashSet<string> words = new HashSet<string> {
        "BUYER", "MUSIC", "WOMAN", "WORLD", "OWNER", "ACTOR", "CHEEK", "YOUTH", "MEDIA", "MOVIE",
        "ENTRY", "PAPER", "DEATH", "BONUS", "VIDEO", "BLOOD", "PIZZA", "POWER", "NIGHT", "GUEST",
        "QUEEN", "RATIO", "HOTEL", "PHOTO", "BASIS", "CHILD", "BREAD", "ERROR", "PIANO", "UNCLE",
        "UNION", "TOPIC", "SALAD", "TOOTH", "SCENE", "CHEST", "EVENT", "VIRUS", "SKILL", "RIVER",
        "DEPTH", "SHIRT", "APPLE", "DRAMA", "STORY", "MONTH", "STEAK", "THING", "HONEY", "PHONE",
        "AMPLE", "QUEST", "START", "SMELL", "FLOCK", "FEVER", "SHAFT", "ARENA", "BLIND", "CREEP",
        "GHOST", "HEAVY", "ACUTE", "SHOCK", "BUILD", "LAYER", "TOUCH", "JOINT", "ALOOF", "SWEEP",
        "FRUIT", "FLOOR", "WIDEN", "TOAST", "WHOLE", "ORBIT", "CHECK", "SMILE", "SHEET", "KNOCK",
        "GRACE", "LEVEL", "SPRAY", "POINT", "MOTIF", "ANGER", "WAIST", "DELAY", "ANKLE", "BRING",
        "PITCH", "THEME", "ISSUE", "SCORE", "ROUGH", "AWFUL", "TRUNK", "THEFT", "ANGEL", "BLADE",
        "GRASS", "FROGS", "BERRY", "MOULT", "THUMP", "SPOON", "CRUSH", "GLOVE", "RURAL", "FLAME",
        "FANCY", "AHEAD", "STUDY", "GAUDY", "HEAVE", "GRANT", "EMPTY", "PUFFY", "CROSS", "SLEEP",
        "RETCH", "SPOIL", "NAPPY", "CRAVE", "WRITE", "BROWN", "PAINT", "AWAKE", "DANCE", "TWIST",
        "BRICK", "NERVE", "ORGAN", "OTHER", "CHOKE", "WASTE", "SNARL", "READY", "YEARN", "ELECT",
        "CHARM", "NOISE", "GUILT", "ENTER", "DRILL", "REFER", "SMART", "SHEEP", "FLUSH", "STRIP",
        "SHORT", "ESSAY", "PROOF", "CRUDE", "NORTH", "GRAIN", "CRUEL", "WEAVE", "SHOUT", "PRICE",
        "WORRY", "SPEED", "DITCH", "DRIFT", "WHEAT", "CLEAR", "AMUSE", "DRESS", "HOBBY", "MOUSE",
        "TRACK", "THROW", "JUDGE", "HOVER", "FUNNY", "REBEL", "FLESH", "HORSE", "FLEET", "SWELL",
        "STUFF", "RADIO", "GRAVE", "ALLOW", "SHARE", "MEDAL", "SKATE", "GREET", "BLAST", "THUMB",
        "FRANK", "WATER", "BRINK", "TROOP", "CHIEF", "WRIST", "CRASH", "CREED", "SIGHT", "EVOKE",
        "PRINT", "SHAKE", "HONOR", "DRIVE", "SHARK", "WATCH", "AWARD", "LARGE", "REACH", "COWER",
        "GUESS", "ALARM", "PLUCK", "SWEET", "FAULT", "SNAIL", "TREAT", "ROUND", "FIBRE", "CRAFT",
        "CRACK", "HOUSE", "BIBLE", "BRAKE", "LOOSE", "WITCH", "STAFF", "SALON", "UPSET", "JEWEL",
        "TREND", "CABIN", "MINOR", "FAIRY", "LOBBY", "QUOTE", "FIELD", "BURST", "QUEUE", "DRAIN",
        "TRUCK", "FINAL", "SPELL", "LEMON", "CHEAP", "WAGON", "RIGHT", "CLEAN", "CROWN", "TENSE"
    };

    internal static string RandomWord() => words.ElementAt(random.Next(words.Count));
}
