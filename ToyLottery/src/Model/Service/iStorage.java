package Model.Service;

import java.util.List;

import Model.Core.Toys.Toy;

public interface iStorage {

    List<Toy> getToys();

    void saveToys(List<Toy> toys);

    void saveResults(List<Toy> results);



}
