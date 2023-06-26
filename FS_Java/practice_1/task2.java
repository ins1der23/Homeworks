package FS_Java.practice_1;

public class task2 {
    public static void main(String[] args) {
        int num_to = 1000;
        System.out.println(simple_nums(num_to));
    }

    static boolean simple_num_check(int to_check) {
        int temp = 0;
        for (int i = 2; i < to_check; i++) {
            temp = to_check % i;
            if (temp == 0) return false;
        }
            return true;
    }

    static String simple_nums(int num_to){
        String res  = "";
        for (int i = 0; i <= num_to; i++) {
            if (simple_num_check(i)){
                res += i + " ";
            } 
        }
        return res;
    }
}

