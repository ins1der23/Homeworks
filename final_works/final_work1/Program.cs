using static Infrastructure;
using static StringsFromArray;

string invite = "Введите размер массива от 1 до 10";
int sizeIn = invite.BoundInput(1, 10);
string[] wordsArray = sizeIn.CreateStringArray()
                            .FillStringArray();
Console.WriteLine(wordsArray.ArrayToString(','));
string[] outArray = wordsArray.GetWords();
Console.WriteLine(outArray.ArrayToString(','));








