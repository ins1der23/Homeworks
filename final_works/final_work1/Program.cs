using static Infrastructure;
using static StringsFromArray;
using static Testing;
using System.Diagnostics;


// string invite = "Введите размер массива от 1 до 10";
// int sizeIn = invite.BoundInput(1, 10);
// string[] wordsArray = sizeIn.CreateStringArray()
//                             .FillStringArray();
int sizeIn = 10;
string[] wordsArray = sizeIn.GetRandomWordArray();
Console.WriteLine(wordsArray.ArrayToString(','));
Stopwatch sw = new Stopwatch();
sw.Start();
string[] outArray = wordsArray.GetWords(10);
Console.WriteLine(outArray.ArrayToString(','));

string[] outArrayBad = wordsArray.GetWordsBad();
Console.WriteLine(outArrayBad.ArrayToString(','));








