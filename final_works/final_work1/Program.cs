using static Infrastructure;
using static StringsFromArray;

int upBound = 10;
string invite = $"Введите размер массива от 1 до {upBound}";
int size = invite.BoundInput(1, upBound);
string[] wordsArray = size.CreateStringArray()
                            .FillStringArray();
string[] outArray = wordsArray.GetWords();
Console.WriteLine(outArray.ArrayToString(','));










