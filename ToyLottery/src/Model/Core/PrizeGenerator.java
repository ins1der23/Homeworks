package Model.Core;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.PriorityQueue;
import java.util.Random;

import Model.Core.Toys.Toy;
import Model.Service.NotEnoughException;

/**
 * Класс для розыгрыша игрушек
 */
public class PrizeGenerator implements iModel {

    /**
     * Список разыгрываемых игрушек
     */
    private List<Toy> gambledToys;

    /**
     * Список результатов розыгрыша
     */
    private PriorityQueue<Toy> gambleResult;

    /**
     * Число участников розыгрыша
     */
    private int participants;

    /**
     * Список выданных призов
     */
    private List<Toy> prizeGiven;

    public PrizeGenerator() {
        this.gambledToys = new LinkedList<Toy>();
        this.gambleResult = new PriorityQueue<Toy>();
        this.prizeGiven = new ArrayList<Toy>();
    }

    /**
     * Геттер списка разыгрываемых игрушек
     * 
     * @return список игрушек для розыгрыша
     */
    public List<Toy> getGambledToys() {
        return gambledToys;
    }

    /**
     * Сеттер списка разыгрываемых игрушек
     * 
     * @param toysPlayed список игрушек для розыгрыша
     */
    public void setGambledToys(List<Toy> toysPlayed) {

        this.gambledToys = toysPlayed;
    }

    /**
     * Геттер списка с результатами розыгрыша
     * 
     * @return список с результатами розыгрыша
     */
    public PriorityQueue<Toy> getGambleResult() {
        return gambleResult;
    }

    /**
     * Сеттер числа участников розыгрыша
     */
    public void setParticipants(int participants) {
        this.participants = participants;
    }

    /**
     * Метод розыгрыша призов с проверкой соответствия
     * количества участников количеству возможных призов
     */
    public void gamble() {
        if (this.participants > gambledToys.size())
            throw new NotEnoughException();
        for (int index = 0; index < this.participants; index++) {
            generatePrize();
        }
    }

    /**
     * Метод получения приза согласно его шансу на выпадения из списка для розыгрыша
     * Добавляет игрушку в список призов и удаляет ее из списка для розыгрыша.
     * Если игрушка не выпала, добавляет пустую игрушку в список призов
     */
    private void generatePrize() {

        Random random = new Random();
        int happyNumber;
        happyNumber = random.nextInt(1, 101);
        List<Toy> finalists = new ArrayList<>();
        for (Toy toy : gambledToys) {
            if (happyNumber <= toy.getChance()) {
                finalists.add(toy);
            }
        }
        if (finalists.isEmpty()) {
            gambleResult.add(new Toy());
            return;
        }
        happyNumber = random.nextInt(1, finalists.size() + 1);
        Toy prize = finalists.get(happyNumber - 1);
        gambleResult.add(prize);
        gambledToys.remove(prize);
    }

    /**
     * Добавление игрушки в список для розыгрыша
     * 
     * @param toy Игрушка для добавления
     * @param count Количество игрушек  
     */
    public void addToys(Toy toy, int count) {
        for (int i = 0; i < count; i++) {
            gambledToys.add(toy);
        }
    }

    /**
     * Получение массива с результатами лоттерии из списка результатов
     * Можно задать количество призов к получению
     * 
     * @param count количество призов к получению
     * @return массив с заданным количеством результатов лоттерии
     */
    public List<Toy> getPrizes(int count) {
        if (count > gambleResult.size())
            throw new NotEnoughException();
        for (int i = 0; i < count; i++) {
            getPrize();
        }
        return prizeGiven;
    }

    /**
     * Получение результата лоттерии из списка результатов
     * Удаляет результат из списка результатов и
     * добавляет игрушку в список выданных призов, если не Empty
     * 
     * @return Выигранную или Empty игрушку
     */
    private Toy getPrize() {
        Toy prize = gambleResult.poll();
        if (!prize.getName().equals("Empty"))
            prizeGiven.add(prize);
        return prize;
    }

    // /**
    //  * Получение результатов розыгрыша в виде String
    //  * 
    //  * @return результаты розыгрыша в виде String
    //  */
    // public String resultsToString() {
    //     StringBuilder results = new StringBuilder();
    //     int i = 1;
    //     for (Toy toy : gambleResult) {
    //         results.append(i).append('.').append(' ');
    //         results.append(toy);
    //         results.append('\n');
    //     }
    //     return results.toString();
    // }

    // /**
    // * Получение списка разыгрываемых игрушек в виде частотного словаря
    // *
    // * @return Частотный словарь разыгрываемых игрушек
    // */
    // public HashMap<String, Integer> gambledToysDict() {
    // HashMap<String, Integer> output = new HashMap<>();
    // String toyType = "";
    // for (Toy toy : gambledToys) {
    // int count = 0;
    // for (int i = 0; i < gambledToys.size(); i++) {
    // if (gambledToys.get(i).equals(toy))
    // ++count;
    // }
    // toyType = toy.getClass().toString();
    // String[] temp = toyType.split("\\.");
    // toyType = temp[temp.length - 1];
    // output.put(toyType + ';' + toy.getName() + ';' + toy.getChance(), count);
    // }
    // return output;
    // }

}
