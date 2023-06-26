package FS_Java.practice_1;

import java.util.Scanner;

public class task3 {
    static Scanner in = new Scanner(System.in);
    public static void main(String[] args) {

        double first = get_integer("Введите первое число:");
        char action = get_action("Введите арифметическое действие: ");
        double second = get_integer("Введите второе число:");
        System.out.println(String.format("%1$s %2$s %3$s = %4$s", first, action, second, calc(first, action, second)));
        in.close();

    }

    static double get_integer(String message) {
        String temp = "";
        boolean isInt = false;
        while (!isInt) {
            System.out.println(message);;
            temp = in.nextLine();
            try {
                double res = Double.parseDouble(temp);
                isInt = true;
            } catch (NumberFormatException e) {
                isInt = false;
            }
        }
        return Double.parseDouble(temp);
    }

    static char get_action(String message) {
        char temp;
        String actions = "+-*/";
        while (true) {
            System.out.println(message);
            temp = in.nextLine().charAt(0);
            if (actions.contains(String.valueOf(temp))) {
                return temp;
            }
        }
    }

    static double calc(double first, char action, double second) {
        char plus = '+';
        char minus = '-';
        char mult = '*';
        char div = '/';
        if (action == plus) {
            return first + second;
        } else if (action == minus) {
            return first - second;
        } else if (action == mult) {
            return first * second;
        } else if (action == div) {
            if (second == 0) {
                System.out.println("На ноль делить нельзя");
                return 0;
            }
            return first / second;
        } else
            return 0;
    }

}
