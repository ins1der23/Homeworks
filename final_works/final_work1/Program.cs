using static Infrastructure;
using static StringsFromArray;
using static Testing;
using System.Diagnostics;


// string invite = "Введите размер массива от 1 до 10";
// int sizeIn = invite.BoundInput(1, 10);
// string[] wordsArray = sizeIn.CreateStringArray()
//                             .FillStringArray();
int sizeIn = 10000000;
string[] wordsArray = sizeIn.GetRandomWordArray();
// Console.WriteLine(wordsArray.ArrayToString(','));
Stopwatch sw = new Stopwatch();
sw.Start();
string[] outArray = wordsArray.GetWords();
// Console.WriteLine(outArray.ArrayToString(','));
sw.Stop();
Console.WriteLine($"Getwords: => {sw.ElapsedMilliseconds}");
sw.Reset();
sw.Start();
string[] outArrayBad = wordsArray.GetWordsBad();
// Console.WriteLine(outArrayBad.ArrayToString(','));
sw.Stop();
Console.WriteLine($"GetwordsBad: => {sw.ElapsedMilliseconds}");








