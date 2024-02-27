package Controller;

import java.util.List;
import java.util.PriorityQueue;

import Model.Core.iModel;
import Model.Core.Toys.BronzeToy;
import Model.Core.Toys.GoldToy;
import Model.Core.Toys.PlatinumToy;
import Model.Core.Toys.SilverToy;
import Model.Core.Toys.Toy;
import Model.Service.NotEnoughException;
import Model.Service.iStorage;
import View.Interfaces.iView;

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
                    // Toy toy1 = new BronzeToy("Мячик");
                    // Toy toy2 = new BronzeToy("Мячик");
                    // Toy toy3 = new BronzeToy("Мячик");
                    // Toy toy4 = new SilverToy("Зайчик");
                    // Toy toy5 = new SilverToy("Зайчик");
                    // Toy toy6 = new SilverToy("Зайчик");
                    // Toy toy7 = new GoldToy("Трансформер");
                    // Toy toy8 = new GoldToy("Трансформер");
                    // Toy toy9 = new PlatinumToy("Ролики");
                    // Toy toy10 = new PlatinumToy("Ролики");
                    // Toy toy11 = new Toy("Жвачка");
                    // Toy toy12 = new Toy("Жвачка");
                    // Toy toy13 = new Toy("Жвачка");
                    // Toy toy14 = new Toy("Жвачка");
                    // model.addToy(toy1);
                    // model.addToy(toy2);
                    // model.addToy(toy3);
                    // model.addToy(toy4);
                    // model.addToy(toy5);
                    // model.addToy(toy6);
                    // model.addToy(toy7);
                    // model.addToy(toy8);
                    // model.addToy(toy9);
                    // model.addToy(toy10);
                    // model.addToy(toy11);
                    // model.addToy(toy12);
                    // model.addToy(toy13);
                    // model.addToy(toy14);
                    // storage.saveToys(model.getGambledToys());
                    List<Toy> toysPlayed = storage.getToys();
                    model.setGambledToys(toysPlayed);
                    break;
                case "SHOWTOYS":
                    List<Toy> toys = model.getGambledToys();
                    view.showToys("Разыгрываемые игрушки", toys);
                    break;
                case "ADD":
                    Toy toy = view.getToy();
                    model.addToy(toy);
                    break;
                case "GAMBLE":
                    int participants = view.getParticipants();
                    model.setParticipants(participants);
                    try {
                        model.gamble();
                    } catch (NotEnoughException e) {
                        view.showError(e.getMessage());
                    }
                    try {
                        storage.saveToys(model.getGambledToys());
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
                        Toy[] prizes = model.getPrizes(prizeCount);
                        view.showToys("Выданные призы", prizes);
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
