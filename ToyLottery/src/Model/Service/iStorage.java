package Model.Service;

import java.io.IOException;
import java.util.List;
import java.util.PriorityQueue;

import Model.Core.Toys.Toy;
/**
 * Интерфейс для работы с хранилищем данных
 */
public interface iStorage {

    /**
     * Метод получения списка призов
     * @return список призов
     * @throws Exception
     */
    List<Toy> getToys() throws Exception;

    /**
     * Метод бэкапа файла призов
     * @param toys Список призов для бэкапа
     * @throws IOException
     */
    void backupToys(List<Toy> toys) throws IOException;

    /**
     * Метод обновления файла призов
     * @param toys Список призов для записи в файл
     * @throws IOException
     */
    void updateToys(List<Toy> toys) throws IOException;


    /**
     * Метод обновления файла с результатами розыгрыша
     * @param toys Список призов для записи в файл
     * @throws IOException
     */
    void updateResults(PriorityQueue<Toy> results) throws IOException;


    /**
     * Метод обновления файла с выданными призами
     * @param toys Список призов для записи в файл
     * @throws IOException
     */
    void savePrizes(List<Toy> toys) throws IOException;

}
