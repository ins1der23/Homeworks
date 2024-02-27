package Model.Service;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import Model.Core.Toys.BronzeToy;
import Model.Core.Toys.GoldToy;
import Model.Core.Toys.PlatinumToy;
import Model.Core.Toys.SilverToy;
import Model.Core.Toys.Toy;

public class FileWork implements iStorage {

    private String toysFile;
    private String toysFileOld;
    private String gambleResult;
    private String prizeGiven;

    public FileWork() {
        toysFile = "gambledToys.csv";
        toysFileOld = "gambledToys.csv";
        gambleResult = "gambleResult.csv";
        prizeGiven = "prizeGiven.csv";
    }

    public String getToysFile() {
        return toysFile;
    }

    public void setToysFile(String toysFile) {
        this.toysFile = toysFile;
    }

    public String getToysFileOld() {
        return toysFileOld;
    }

    public void setToysFileOld(String toysFileOld) {
        this.toysFileOld = toysFileOld;
    }

    public String getGambleResult() {
        return gambleResult;
    }

    public void setGambleResult(String gambleResult) {
        this.gambleResult = gambleResult;
    }

    public String getPrizeGiven() {
        return prizeGiven;
    }

    public void setPrizeGiven(String prizeGiven) {
        this.prizeGiven = prizeGiven;
    }

    @Override
    public List<Toy> getToys() {
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
                    case "Platinum":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new PlatinumToy(name, chance);
                        }
                        break;
                    case "Gold":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new GoldToy(name, chance);
                        }
                        break;
                    case "Silver":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new SilverToy(name, chance);
                        }
                        break;
                    case "Bronze":
                        for (int i = 0; i < toyCount; i++) {
                            toy = new BronzeToy(name, chance);
                        }
                        break;
                    default:
                        for (int i = 0; i < toyCount; i++) {
                            toy = new Toy(name, chance);
                        }
                        break;
                }
                toys.add(toy);
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return toys;
    }

    @Override
    public void saveToys(List<Toy> toys) {
        HashMap<String, Integer> toysDict = toysToDict(toys);

        try (FileWriter fw = new FileWriter(toysFile, false)) {
            for (Map.Entry<String, Integer> entry : toysDict.entrySet()) {

                fw.write(entry.getKey());
                fw.append(';');
                fw.append(entry.getValue().toString());
                fw.append("\n");
            }
            fw.flush();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    /**
     * Получение списка разыгрываемых игрушек в виде частотного словаря
     * для последующей записи в файл
     * 
     * @return Частотный словарь разыгрываемых игрушек
     */

    private HashMap<String, Integer> toysToDict(List<Toy> toys) {
        HashMap<String, Integer> output = new HashMap<>();
        for (Toy toy : toys) {
            int count = 0;
            for (int i = 0; i < toys.size(); i++) {
                if (toys.get(i).equals(toy))
                    ++count;
            }
            output.put(toy.shortString(), count);
        }
        return output;
    }

    @Override
    public void saveResults(List<Toy> results) {
        // TODO Auto-generated method stub
        throw new UnsupportedOperationException("Unimplemented method 'saveResults'");
    }

}
