package Model.Service;

import java.io.IOException;
import java.util.List;
import java.util.PriorityQueue;

import Model.Core.Toys.Toy;

public interface iStorage {

    List<Toy> getToys() throws Exception;

    void backupToys(List<Toy> toys) throws IOException;

    void updateToys(List<Toy> toys) throws IOException;

    void saveResults(PriorityQueue<Toy> results) throws IOException;

    void savePrizes(List<Toy> toys) throws IOException;

}
