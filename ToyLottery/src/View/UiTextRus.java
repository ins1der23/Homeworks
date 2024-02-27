package View;

import View.Interfaces.iUiText;

public class UiTextRus implements iUiText {
    private String[] mainMenu;

    public String[] mainMenu() {
        return mainMenu;
    }

    private String chooseOption;
    public String chooseOption() {
        return chooseOption;
    }

    private String chooseType;
    public String chooseType() {
        return chooseType;
    }

    private String[] prizeTypes;
    public String[] prizeTypes() {
        return prizeTypes;
    }

    private String toyName;
    public String toyName() {
        return toyName;
    };

    private String participants;
    public String participants() {
        return participants;
    }

    private String pause;
    public String pause() {
        return pause;
    }

    private String prizeCount;
    public String prizeCount(){
        return prizeCount;
    }

    public UiTextRus() {
        mainMenu = new String[] { "Загрузить список игрушек для розыгрыша из файла",
                "Посмотреть список игрушек для розыгрыша",
                "Добавить игрушку",
                "Разыграть игрушки",
                "Посмотрtть результаты розыгрыша / список призов для выдачи",
                "Выдать призы ",
                "Выход" };

        chooseOption = "Выберете пункт меню";
        chooseType = "Выберите тип приза";
        prizeTypes = new String[] { "Обычный", "Бронзовый", "Серебряный", "Золотой", "Платиновый" };
        toyName = "Введите название игрушки";
        participants = "Введите количество участников";
        pause = "Нажмите ENTER для продолжения";
        prizeCount = "Введите число призов для выдачи";
    }

}
