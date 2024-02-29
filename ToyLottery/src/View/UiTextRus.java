package View;

import View.Interfaces.iUiText;

/**
 * Класс для текста интерефейса
 */
public class UiTextRus implements iUiText {

    // Перемнные для текстового оформления

    private String[] mainMenu;
    private String chooseOption;
    private String chooseType;
    private String[] prizeTypes;
    private String toyName;
    private String participants;
    private String pause;
    private String prizeCount;
    private String toysCount;
    private String toysHeader;
    private String resultsHeader;
    private String prizesHeader;
    private String inputError;

    public UiTextRus() {

        mainMenu = new String[] { "Загрузить список игрушек для розыгрыша из файла",
                "Посмотреть список игрушек для розыгрыша",
                "Добавить игрушку",
                "Разыграть игрушки",
                "Посмотреть результаты розыгрыша / список призов для выдачи",
                "Выдать призы",
                "Выход" };

        chooseOption = "Выберете пункт меню";
        chooseType = "Выберите тип приза";
        prizeTypes = new String[] { "Обычный", "Бронзовый", "Серебряный", "Золотой", "Платиновый" };
        toyName = "Введите название игрушки";
        participants = "Введите количество участников";
        pause = "Нажмите ENTER для продолжения";
        prizeCount = "Введите количество призов для выдачи";
        toysCount = "Введите количество игрушек для розырыша";
        toysHeader = "Разыгрываемые игрушки";
        resultsHeader = "Призы к выдаче";
        prizesHeader = "Выданные призы";
        inputError = "Ошибка ввода";
    }

    // Геттеры переменных текста UI

    public String[] mainMenu() {
        return mainMenu;
    }

    public String chooseOption() {
        return chooseOption;
    }

    public String chooseType() {
        return chooseType;
    }

    public String[] prizeTypes() {
        return prizeTypes;
    }

    public String toyName() {
        return toyName;
    }

    public String participants() {
        return participants;
    }

    public String pause() {
        return pause;
    }

    public String prizeCount() {
        return prizeCount;
    }

    public String toysCount() {
        return toysCount;
    }

    public String toysHeader() {
        return toysHeader;
    }

    public String resultsHeader() {
        return resultsHeader;
    }

    public String prizesHeader() {
        return prizesHeader;
    }

    public String inputError() {
        return inputError;
    }
}
