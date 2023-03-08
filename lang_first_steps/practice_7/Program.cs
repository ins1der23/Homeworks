Console.WriteLine(Shared.Task("Мы можем решить три задачи"));
Console.WriteLine ("1. Заполнить массив случайными вещественными числами.");
Console.WriteLine ("2. Найти элемент в массиве.");
Console.WriteLine ("3. Посчитать среднее арифметическое столбцов массива.");
int choice = Shared.GetInteger("Введите номер задачи");
choice = Shared.BoundInput(choice, "Введите число от одного до трех", 1, 3);

if (choice == 1) Client.RunFillMatrix();
else if (choice == 2) Client.RunElementPosition();
else Client.RunMeanColumn();
