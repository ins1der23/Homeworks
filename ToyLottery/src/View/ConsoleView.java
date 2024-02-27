package View;

import java.util.List;
import java.util.PriorityQueue;
import java.util.Scanner;
import Model.Core.Toys.BronzeToy;
import Model.Core.Toys.GoldToy;
import Model.Core.Toys.PlatinumToy;
import Model.Core.Toys.SilverToy;
import Model.Core.Toys.Toy;
import View.Interfaces.iUiText;
import View.Interfaces.iView;

public class ConsoleView implements iView {

    /**
     * Переменная для ввода с клавиатуры
     */
    Scanner scanner;

    /**
     * Переменная для текста UI
     */
    iUiText uiText;

    /**
     * Конструктор view, устанавливающий тект интерфейса и кодовую страницу для
     * ввода с клавиатуры
     * 
     * @param uiText Текст интерфейса
     */
    public ConsoleView(iUiText uiText) {
        scanner = new Scanner(System.in, "CP866");
        this.uiText = uiText;
    }

    /**
     * Очистка консоли
     */
    private static void clearConsole() {
        System.out.print("\033[H\033[2J");
    }

    /**
     * Вывод строки в консоль
     * 
     * @param someString строка для вывода
     */
    private void showMessage(String someString) {
        System.out.println(someString);
    }

    /**
     * Получение int с клавиатуры в заданном диапазоне
     * 
     * @param invite строка-приглашение к вводу числа
     * @param min    нижняя граница вводимого числа
     * @param max    верхняя граница вводимого числа
     * @return введенное число
     */
    private int getInteger(String invite, int min, int max) {
        int output = 0;
        boolean flag = true;
        do {
            showMessage(invite + ":");
            String temp = scanner.nextLine();
            if (temp.equals(new String()))
                temp = "0";
            try {
                output = Integer.parseInt(temp);
                flag = false;
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }
        } while (flag || min > output || max < output);
        return output;
    }

    /**
     * получение String с клавиатуры
     * 
     * @param invite строка-приглашение к вводу
     * @return ввдеенную строку
     */
    private String getString(String invite) {
        showMessage(invite);
        String output = scanner.nextLine();
        return output;
    }

    /**
     * Метод для вывода в конcоль String[]
     * 
     * @param someArray String[] для вывода
     */
    private void showStrings(String[] someArray) {
        int i = 1;
        for (String string : someArray) {
            System.out.println(i + ". " + string);
            i++;
        }
    }

    /**
     * Нажмите Enter для продолжения
     */
    private void pressEnter() {
        System.out.println("------------------------------------");
        showMessage(uiText.pause());
        scanner.nextLine();
        return;
    }

    /**
     * Метод для получения числового значения выбора варианта из отображаемого меню
     * 
     * @param menu   меню для обображения
     * @param invite строка-прилашение к выбору варианта
     * @param clear  переключатель очистки консоли
     * @return числовое значение выбора варианта
     */
    private int menuToChoice(String[] menu, String invite, Boolean clear) {
        if (clear)
            clearConsole();
        showStrings(menu);
        int size = menu.length;
        int choice = getInteger(invite, 1, size);
        return choice;
    }

    @Override
    public void showToys(String header, List<Toy> someList) {
        clearConsole();
        System.out.println(header);
        System.out.println("------------------------------------");
        int i = 1;
        for (Toy toy : someList) {
            if (toy.getName().equals("Empty"))
                System.out.println(i + ". " + "Не повезло!");
            else
                System.out.println(i + ". " + toy);
            i++;
        }
        pressEnter();
    }

    @Override
    public void showToys(String header, PriorityQueue<Toy> someList) {
        clearConsole();
        System.out.println(header);
        System.out.println("------------------------------------");
        int i = 1;
        for (Toy toy : someList) {
            if (toy.getName().equals("Empty"))
                System.out.println(i + ". " + "Не повезло!");
            else
                System.out.println(i + ". " + toy);
            i++;
        }
        pressEnter();
    }

    @Override
    public void showError(String someString) {
        System.out.println(someString);
        pressEnter();
    }

    @Override
    public String getCommand() {
        while (true) {
            clearConsole();
            showStrings(uiText.mainMenu());
            int size = uiText.mainMenu().length;
            int choice = getInteger(uiText.chooseOption(), 1, size);
            switch (choice) {
                case 1:
                    return "LOAD";
                case 2:
                    return "SHOWTOYS";
                case 3:
                    return "ADD";
                case 4:
                    return "GAMBLE";
                case 5:
                    return "SHOWRESULT";
                case 6:
                    return "REWARD";
                case 7:
                    return "EXIT";
            }
        }
    }

    @Override
    public Toy getToy() {
        while (true) {
            clearConsole();
            showMessage(uiText.chooseType());
            clearConsole();
            int choice = menuToChoice(uiText.prizeTypes(), uiText.chooseOption(), false);
            String name = getString(uiText.toyName());
            switch (choice) {
                case 1:
                    return new Toy(name);
                case 2:
                    return new BronzeToy(name);
                case 3:
                    return new SilverToy(name);
                case 4:
                    return new GoldToy(name);
                case 5:
                    return new PlatinumToy(name);
            }

        }
    }

    @Override
    public int getParticipants() {
        clearConsole();
        return getInteger(uiText.participants(), 1, 1000000);
    }

    @Override
    public int getPrizeCount() {
        clearConsole();
        return getInteger(uiText.prizeCount(), 1, 1000000);
    }

    @Override
    public int getToysCount() {
        clearConsole();
        return getInteger(uiText.toysCount(), 1, 1000000);
    }

    @Override
    public iUiText getUiText() {
        return uiText;
    }
}
