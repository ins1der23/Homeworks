using System;
public static class Testing
{
    public static char[] GetAlphbet()
    {
        string symbols = "?!%()qwertyuiopasdfghjklzxcvbnm";
        return symbols.ToCharArray();
    }
    public static string WordMaker()
    {
        char[] alphabet = GetAlphbet();
        int alphabetSize = alphabet.Length;
        int charIndex = 0;
        int wordSize = Random.Shared.Next(1, 10);
        char[] word = new char[wordSize] ;
        for (int i = 0; i < wordSize; i++)
        {
            charIndex = Random.Shared.Next(0, alphabetSize);
            word[i] = alphabet[charIndex];
        }
        return new string(word);
    }
    public static string[] GetRandomWordArray(this int size)
    {
        string[] wordArray = new string[size];
        for (int i = 0; i < size; i++)
        {
            wordArray[i] = WordMaker();
        }
        return wordArray;
    }
}