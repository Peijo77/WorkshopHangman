using System;

class HangmanGame
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain)
        {
            PlayHangman();
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }
    }

    static void PlayHangman()
    {
        string[] words = { "WATERMELON", "AUSTRALIA", "CUCUMBER", "BASEBALL", "SCHIMPANS", "SCREWDRIVER", "BIRCH", "MOUNTAIN", "MADAGASKAR", "LASAGNE" };
        string[] categories = { "FRUIT", "COUNTRY", "VEGETABLE", "SPORT", "ANIMAL", "TOOL", "TREE", "NATURE", "ISLAND", "FOOD" }; // Assign categories to the words above

        Random random = new Random();
        int index = random.Next(0, words.Length);
        string wordToGuess = words[index].ToUpper();
        string category = categories[index];

        char[] guessedWord = new char[wordToGuess.Length];
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedWord[i] = '_';
        }

        int attempts = 10;
        bool wordGuessed = false;

        Console.WriteLine("WELCOME TO HANGMAN!");
        Console.WriteLine();
        Console.WriteLine("Guess the word by suggesting letters.");
        Console.WriteLine("You have 10 attempts.");
        Console.WriteLine();
        Console.WriteLine("Category: " + category); // Display the category of the word
        

        while (attempts > 0 && !wordGuessed)
        {
            Console.WriteLine("\nWord: " + string.Join(" ", guessedWord));
            Console.WriteLine("Attempts left: " + attempts);
            Console.Write("Enter a letter or guess the whole word: ");
            string guess = Console.ReadLine().ToUpper();

            if (guess.Length == 1) // Guessing a letter
            {
                char letter = guess[0];
                if (wordToGuess.Contains(letter))
                {
                    Console.WriteLine("Correct guess!");
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == letter)
                            guessedWord[i] = letter;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect guess!");
                    attempts--;
                }
            }
            else // Guessing the whole word
            {
                if (guess == wordToGuess)
                {
                    Console.WriteLine("Congratulations! You've guessed the word!");
                    wordGuessed = true;
                }
                else
                {
                    Console.WriteLine("Incorrect guess!");
                    attempts--;
                }
            }

            if (string.Join("", guessedWord) == wordToGuess)
            {
                Console.WriteLine("Congratulations! You've guessed the word!");
                wordGuessed = true;
            }
        }

        if (!wordGuessed)
        {
            Console.WriteLine("\nSorry, you've run out of attempts. The word was: " + wordToGuess);
        }
    }
}

