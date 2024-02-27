package Model.Core;

import java.util.List;
import java.util.PriorityQueue;

import Model.Core.Toys.Toy;

public interface iModel {

    List<Toy> getGambledToys();

    void setGambledToys(List<Toy> toysPlayed);

    PriorityQueue<Toy> getGambleResult();

    void gamble();

    void addToy(Toy toy);

    void setParticipants(int participants);
    
    List<Toy> getPrizes(int count);

}
