package FS_Java.practice_1;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class task4 {
    public static void main(String[] args) {
        String quest = "2? + 4? = 69";
        String[] splitted = quest.split(" ");
        int[] first_var = variants(splitted[0]);
        int[] second_var = variants(splitted[2]);
        int[] result_var = variants(splitted[4]);
        List<String> answers = answers(first_var, second_var, result_var);
        if(answers.isEmpty()) System.out.println("Решения нет");
        else System.out.println(answers.toString());
    }

    static boolean is_int(String some_string) {
        boolean is_int = true;
        try {
            int temp = Integer.parseInt(some_string);
            is_int = true;
        } catch (NumberFormatException e) {
            is_int = false;
        }
        return is_int;
    }

    static int get_quest_position(String quested_num) {
        int index = 0;
        if (!is_int(quested_num)) {
            for (int i = 0; i < quested_num.length(); i++) {
                if (!is_int(Character.toString(quested_num.charAt(i))))
                    index = i;
            }
        }
        return index;
    }

    static int[] variants(String quested) {
        int[] result = new int[10];
        if (!is_int(quested)) {
            int quested_pos = get_quest_position(quested);
            String[] temp = quested.split("");
            for (int i = 0; i < 10; i++) {
                temp[quested_pos] = Integer.toString(i);
                result[i] = Integer.parseInt(String.join("", temp));
            }
        } else {
            for (int i = 0; i < 10; i++) {
                result[i] = Integer.parseInt(quested);
            }
        }
        return result;
    }

    static List<String> answers(int[] first, int[] second, int[] result) {
        List<String> answers = new ArrayList<>();
        String temp = "";
        if (result[0] == result[9]) {
            for (int i = 0; i < result.length; i++) {
                for (int j = 0; j < result.length; j++) {
                    if (first[i] + second[j] == result[i]) {
                        temp = String.format("%1$s + %2$s = %3$s", first[i], second[j], result[i]);
                        answers.add(temp);
                    }
                }
            }
        }
        if (first[0] == first[9]) {
            for (int i = 0; i < result.length; i++) {
                for (int j = 0; j < result.length; j++) {
                    if (result[i] - second[j] == first[i]) {
                        temp = String.format("%1$s + %2$s = %3$s", first[i], second[j], result[i]);
                        answers.add(temp);
                    }
                }
            }
        }
        if (second[0] == second[9]) {
            for (int i = 0; i < result.length; i++) {
                for (int j = 0; j < result.length; j++) {
                    if (result[i] - first[j] == second[i]) {
                         temp = String.format("%1$s + %2$s = %3$s", first[j], second[i], result[i]);
                         answers.add(temp);
                    }
                }
            }
        }
        return answers;
    }
}
