package View.Interfaces;

import java.util.List;
import java.util.PriorityQueue;

import Model.Core.Toys.Toy;

/**
 * Интрфейс для UI
 */
public interface iView {

    /**
     * Метод для отображения List<Toy>
     * 
     * @param header   Заголовок
     * @param someList Список призов
     */
    void showToys(String header, List<Toy> someList);

    /**
     * Метод для отображения PriorityQueue<Toy>
     * 
     * @param header   Заголовок
     * @param someList Список призов
     */
    void showToys(String header, PriorityQueue<Toy> someList);

    /**
     * Метод для отображения ошибки
     * 
     * @param someString Текст ошибки
     */
    void showError(String someString);

    /**
     * Метод получения команды от пользовтаеля
     * 
     * @return Строку команды
     */
    String getCommand();

    /**
     * Метод получения разыгрываемой игрушки от пользовтеля
     * 
     * @return Разыгрываемая игрушка, введенная пользователем
     */
    Toy getToy();

    /**
     * Метод получения числа участников от пользователя
     * 
     * @return Число участников, введенное пользователем
     */
    int getParticipants();

    /**
     * Метод получения числа призов от пользователя
     * 
     * @return Число призов, введенное пользователем
     */
    int getPrizeCount();

    /**
     * Метод получения числа разыгрываемых игрушек от пользователя
     * 
     * @return Число разыгрываемых игрушек, введенное пользователем
     */
    int getToysCount();

    /**
     * Метод для доступа к классу текста интерфейса
     * 
     * @return Класс текста интерфейса
     */
    iUiText getUiText();

    }
