import Controller.MainControl;
import Model.Core.PrizeGenerator;
import Model.Core.iModel;
import Model.Service.FileWork;
import Model.Service.iStorage;
import View.ConsoleView;
import View.UiTextRus;
import View.Interfaces.iUiText;
import View.Interfaces.iView;


public class App {
    public static void main(String[] args) throws Exception {

        // /**
        // * Переменная для работы с записью
        // */
        // private iStorage store;


        iModel generator = new PrizeGenerator();
        iUiText uiText = new UiTextRus();
        iView view = new ConsoleView(uiText);
        iStorage storage = new FileWork();



        MainControl controller = new MainControl(view, generator, storage);
        controller.run();




        




    }
}
