package Model.Service;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.PriorityQueue;
import Model.Core.Toys.BronzeToy;
import Model.Core.Toys.GoldToy;
import Model.Core.Toys.PlatinumToy;
import Model.Core.Toys.SilverToy;
import Model.Core.Toys.Toy;

/**
 * Класс для работы с файлами
 */
public class FileWork implements iStorage {

    /**
     * Имя файла с разыгрываемыми игрушками
     */
    private String toysFile;

    /**
     * Имя файла для бэкапа файла с разыгрываемыми игрушками
     */
    private String toysFileOld;

    /**
     * Имя файла с результатами розыгрыша
     */
    private String gambleResult;

    /**
     * Имя файла с выданнами призами
     */
    private String prizeGiven;

    /**
     * Конструтор, усанвливающий начальные значения
     */
    public FileWork() {
        toysFile = "gambledToys.csv";
        toysFileOld = "gambledToysOld.csv";
        gambleResult = "gambleResult.csv";
        prizeGiven = "prizeGiven.csv";
    }

    // Геттеры имен файлов

    public String getToysFile() {
        return toysFile;
    }

    public String getToysFileOld() {
        return toysFileOld;
    }

    public String getGambleResult() {
        return gambleResult;
    }

    public String getPrizeGiven() {
        return prizeGiven;
    }

    /**
     * Метод сохранения в файл словаря с параметрами и количеством призов
     * @param toysDict Словарь с параметрами и количеством призов
     * @param filename Имя файла для запсиси
     * @throws IOException
     */
    private void saveToFile(HashMap<String, Integer> toysDict, String filename) throws IOException {
        try (FileWriter fw = new FileWriter(filename, false)) {
            for (Map.Entry<String, Integer> entry : toysDict.entrySet()) {
                fw.write(entry.getKey());
                fw.append(';');
                fw.append(entry.getValue().toString());
                fw.append("\n");
            }
            fw.flush();
        } catch (IOException e) {
            throw e;
        }
    }

    /**
     * Получение частотного словаря призов из List<Toy>
     * для последующей записи в файл
     * @param toys список призов
     * @return Частотный словарь разыгрываемых игрушек
     */

    private HashMap<String, Integer> toysToDict(List<Toy> toys) {
        HashMap<String, Integer> output = new HashMap<>();
        for (Toy toy : toys) {
            int count = Collections.frequency(toys, toy);
            output.put(toy.shortString(), count);
            output.put(toy.shortString(), count);
        }
        return output;
    }

    /**
     * Получение частотного словаря призов из PriorityQueue<Toy>
     * для последующей записи в файл
     * @param toys список призов
     * @return Частотный словарь разыгрываемых игрушек
     */

    private HashMap<String, Integer> toysToDict(PriorityQueue<Toy> toys) {
        HashMap<String, Integer> output = new HashMap<>();
        for (Toy toy : toys) {
            int count = Collections.frequency(toys, toy);
            output.put(toy.shortString(), count);
        }
        return output;
    }

    /**
     * Метод для чтения из файла списка разыгрываемых игрушек
     */
    @Override
    public List<Toy> getToys() throws Exception {
        List<Toy> toys = new LinkedList<Toy>();
        String line;
        File file = new File(toysFile);
        Toy toy = new Toy();
        try (BufferedReader bufferreader = new BufferedReader(new FileReader(file))) {
            while ((line = bufferreader.readLine()) != null) {
                String[] param = line.split(";");
                String name = param[1];
                int chance = -1;
                if (!param[2].equals(""))
                    chance = Integer.parseInt(param[2]);
                int toyCount = Integer.parseInt(param[3]);
                switch (param[0]) {
                    case "PlatinumToy":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new PlatinumToy(name, chance);
                            toys.add(toy);
                        }
                        break;
                    case "GoldToy":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new GoldToy(name, chance);
                            toys.add(toy);
                        }
                        break;
                    case "SilverToy":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new SilverToy(name, chance);
                            toys.add(toy);
                        }
                        break;
                    case "BronzeToy":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new BronzeToy(name, chance);
                            toys.add(toy);
                        }
                        break;
                    default:
                        for (int i = 0; i < toyCount; i++) {
                            toy = new Toy(name, chance);
                            toys.add(toy);
                        }
                        break;
                }
            }
        } catch (Exception e) {
            throw e;
        }
        return toys;
    }

    @Override
    public void updateResults(PriorityQueue<Toy> toys) throws IOException {
        HashMap<String, Integer> toysDict = toysToDict(toys);
        saveToFile(toysDict, gambleResult);
    }

    @Override
    public void backupToys(List<Toy> toys) throws IOException {
        HashMap<String, Integer> toysDict = toysToDict(toys);
        saveToFile(toysDict, toysFileOld);
    }

    @Override
    public void updateToys(List<Toy> toys) throws IOException {
        HashMap<String, Integer> toysDict = toysToDict(toys);
        saveToFile(toysDict, toysFile);
    }

    @Override
    public void savePrizes(List<Toy> toys) throws IOException {
        HashMap<String, Integer> toysDict = toysToDict(toys);
        saveToFile(toysDict, prizeGiven);
    }

}
