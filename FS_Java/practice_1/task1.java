package FS_Java.practice_1;

import java.util.Scanner;

public class task1 {

    static Scanner in = new Scanner(System.in);
    public static void main(String[] args) {
        int count = get_integer("Введите число:");
        System.out.println(String.format("Сумма чисел от 1 до %1$s равна %2$s", count, sum_to(count)));
        System.out.println(String.format("Факториал %1$s равен %2$s", count, factorial(count)));
    }


  static int get_integer(String message) {
        String temp = "";
        boolean isInt = false;
        while (!isInt) {
            System.out.println(message);;
            temp = in.nextLine();
            try {
                int res = Integer.parseInt(temp);
                isInt = true;
            } catch (NumberFormatException e) {
                isInt = false;
            }
        }
        return Integer.parseInt(temp);
    }

    static int sum_to(int count) {
        return (int) ((1 + count) / 2.0 * count);
    }

    static int factorial(int count) {
        int result = 1;
        for (int i = 1; i <= count; i++) {
            result *= i;
        }
        return result;
    }
}


