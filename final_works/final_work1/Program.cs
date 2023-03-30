using static Infrastructure;

string invite = "Введите размер массива от 1 до 10";
int size = invite.BoundInput(1,10);
int someArray = size.CreateStringArray
                    .FillStringArray;