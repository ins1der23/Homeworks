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

    Scanner scanner;
    iUiText uiText;

    public ConsoleView(iUiText uiText) {
        scanner = new Scanner(System.in, "CP866");
        this.uiText = uiText;
    }

    // очистка консоли
    public static void clearConsole() {
        System.out.print("\033[H\033[2J");
    }

    // получение int с клавиатуры в заданном диапазоне
    public int getInteger(String invite, int min, int max) {
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

    // получение String с клавиатуры
    public String getString(String invite) {
        showMessage(invite);
        String output = scanner.nextLine();
        return output;
    }

    @Override
    public void showStrings(String[] someArray) {
        int i = 1;
        for (String string : someArray) {
            System.out.println(i + ". " + string);
            i++;
        }
    }

    @Override
    public void showToys(String header, List<Toy> someList) {
        clearConsole();
        System.out.println(header);
        System.out.println("------------------------------------");
        int i = 1;
        for (Toy toy : someList) {
            System.out.println(i + ". " + toy);
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
            System.out.println(i + ". " + toy);
        }
        pressEnter();
    }

    @Override
    public void showToys(String header, Toy[] someList) {
        clearConsole();
        System.out.println(header);
        System.out.println("------------------------------------");
        int i = 1;
        for (Toy toy : someList) {
            System.out.println(i + ". " + toy);
        }
        pressEnter();
    }

    @Override
    public void showMessage(String someString) {
        System.out.println(someString);
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

    // пауза
    private void pressEnter() {
        System.out.println("------------------------------------");
        showMessage(uiText.pause());
        scanner.nextLine();
        return;
    }

    private int menuToChoice(String[] menu, String invite, Boolean clear) {
        if (clear)
            clearConsole();
        showStrings(menu);
        int size = menu.length;
        int choice = getInteger(invite, 1, size);
        return choice;
    }

    @Override
    public Toy getToy() {
        while (true) {
            clearConsole();
            showMessage(uiText.chooseType());
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
        return getInteger(uiText.participants(), 1, 100);
    }

    @Override
    public int getPrizeCount() {
        return getInteger(uiText.prizeCount(), 1, 20);
    }
}
