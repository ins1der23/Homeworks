Console.WriteLine(Shared.Task("Мы можем решить три задачи"));
int choice = Shared.GetInteger("Введите номер задачи");
choice = Shared.BoundInput(choice, "У нас три задачи, введите число от одного до трех", 1, 3);

if (choice == 1) Client.RunFillMatrix();
else if (choice == 2) Client.RunElementPosition();
else Client.RunMeanColumn();
