package Model.Core.Toys;

/**
 * Класс, описывающий игрушку
 */
public class Toy implements Comparable<Toy> {

    protected static int idCount = 0;
    private static int defaultChance = 80;
    
    protected int id;
    protected String name;
    protected Integer chance;
    

    public Toy() {
        this.id = 0;
        this.name = "Empty";
        this.chance = 100;
    }

    public Toy(String name) {
        this.id = ++idCount;
        this.name = name;
        this.chance = defaultChance;
    }

    public Toy(String name, int chance) {
        this.id = ++idCount;
        this.name = name;
        if (chance < 0)
            this.chance = defaultChance;
        else
            this.chance = chance;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getChance() {
        return chance;
    }

    public void setChance(Integer chance) {
        if (chance < 0 || chance > 100) {
            System.err.println("Wrong data");
            return;
        }
        this.chance = chance;
    }

    @Override
    public int compareTo(Toy o) {
        return this.getChance() - o.getChance();
    }

    public String shortString() {
        String toyType = getClass().toString();
        String[] temp = toyType.split("\\.");
        toyType = temp[temp.length - 1];
        return toyType + ';' + getName() + ';' + getChance();
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
        // TODO Auto-generated method stub
        return super.hashCode();
    }

}