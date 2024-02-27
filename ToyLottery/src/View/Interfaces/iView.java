package View.Interfaces;

import java.util.List;
import java.util.PriorityQueue;

import Model.Core.Toys.Toy;

public interface iView {

    void showStrings(String[] someArray);

    void showToys(String header, List<Toy> someList);

    void showToys(String header, PriorityQueue<Toy> someList);

    void showMessage(String someString);

    void showError(String someString);

    String getCommand();

    Toy getToy();

    int getParticipants();

    int getPrizeCount();

}
