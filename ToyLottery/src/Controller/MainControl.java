package Controller;

import java.util.List;
import java.util.PriorityQueue;
import Model.Core.iModel;
import Model.Core.Toys.Toy;
import Model.Service.iStorage;
import View.Interfaces.iView;

/**
 * Класс для основного контроллера
 */
public class MainControl {


    iView view;
    iModel model;
    iStorage storage;

    public MainControl(iView view, iModel model, iStorage storage) {
        this.view = view;
        this.model = model;
        this.storage = storage;
    }

    public void run() {
        while (true) {
            String command = view.getCommand();
            switch (command) {
                case "LOAD":
                    try {
                        List<Toy> toysPlayed = storage.getToys();
                        model.setGambledToys(toysPlayed);
                        storage.backupToys(toysPlayed);
                    } catch (Exception e) {
                        view.showError(e.getMessage());
                    }
                    break;
                case "SHOWTOYS":
                    List<Toy> toys = model.getGambledToys();
                    view.showToys("Разыгрываемые игрушки", toys);
                    break;
                case "ADD":
                    Toy toy = view.getToy();
                    int toysCount = view.getToysCount();
                    model.addToys(toy, toysCount);
                    try {
                        storage.updateToys(model.getGambledToys());
                    } catch (Exception e) {
                        view.showError(e.getMessage());
                    }
                    break;
                case "GAMBLE":
                    int participants = view.getParticipants();
                    model.setParticipants(participants);
                    try {
                        model.gamble();
                        storage.updateToys(model.getGambledToys());
                        storage.updateResults(model.getGambleResult());
                    } catch (Exception e) {
                        view.showError(e.getMessage());
                    }
                    break;
                case "SHOWRESULT":
                    PriorityQueue<Toy> gambleResults = model.getGambleResult();
                    view.showToys("Призы к выдаче", gambleResults);
                    break;
                case "REWARD":
                    int prizeCount = view.getPrizeCount();
                    try {
                        List<Toy> prizes = model.getPrizes(prizeCount);
                        view.showToys("Выданные призы", prizes);
                        storage.updateResults(model.getGambleResult());
                        storage.savePrizes(prizes);
                    } catch (Exception e) {
                        view.showError(e.getMessage());
                    }
                    break;
                case "EXIT":
                    return;
            }
        }
    }
}
