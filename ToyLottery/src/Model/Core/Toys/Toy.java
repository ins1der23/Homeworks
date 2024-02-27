package Model.Core.Toys;

/**
 * Класс, описывающий обычный приз
 */
public class Toy implements Comparable<Toy> {

    /**
     * Счетчик id для всех классов наследников
     */
    protected static int idCount = 0;
    
    /**
     * Базовый шанс на выпадение
     */
    private static int defaultChance = 80;

    /**
     * Id приза
     */
    protected int id;

    /**
     * Наименование приза
     */
    protected String name;

    /**
     * Шанс на выпадение
     */
    protected Integer chance;

    /**
     * Конструктор без параметров, создает пустой приз
     */
    public Toy() {
        this.id = 0;
        this.name = "Empty";
        this.chance = 100;
    }

    /**
     * Конструктор, в котором можно задать наименование приза,
     * устанавливает базовый шанс на выпадение
     * 
     * @param name Наименование приза
     */
    public Toy(String name) {
        this.id = ++idCount;
        this.name = name;
        this.chance = defaultChance;
    }

    /**
     * Конструктор, в котором можно задать наименование приза и шанс на выпадение
     * 
     * @param name   Наименование приза
     * @param chance Шанс на выпадение
     */
    public Toy(String name, int chance) {
        this.id = ++idCount;
        this.name = name;
        if (chance < 0)
            this.chance = defaultChance;
        else
            this.chance = chance;
    }

    /**
     * Геттер id
     * 
     * @return id
     */
    public int getId() {
        return id;
    }

    /**
     * Геттер name
     * 
     * @return Наименование приза
     */
    public String getName() {
        return name;
    }

    /**
     * Геттер chance
     * 
     * @return Шанс на выпадение
     */
    public int getChance() {
        return chance;
    }

    /**
     * Сеттер chance с проверкой значения
     * 
     * @param chance Шанс на выпадение
     */
    public void setChance(Integer chance) {
        if (chance < 0 || chance > 100) {
            System.err.println("Wrong data");
            return;
        }
        this.chance = chance;
    }

    /**
     * Метод получения строки с параметрами приза без id
     * 
     * @return строку с параметрами приза без id
     */
    public String shortString() {
        String toyType = getClass().toString();
        String[] temp = toyType.split("\\.");
        toyType = temp[temp.length - 1];
        return toyType + ';' + getName() + ';' + getChance();
    }

    @Override
    public int compareTo(Toy o) {
        return this.getChance() - o.getChance();
    }

    @Override
    public String toString() {
        return "Id:" + this.id + ";" + this.name + ";Chance:" + chance;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        Toy other = (Toy) obj;
        if (this.name.equals(other.name) &&
                this.chance.equals(other.chance))
            return true;
        return false;
    }

    @Override
    public int hashCode() {
        return name.hashCode() + chance;
    }

}