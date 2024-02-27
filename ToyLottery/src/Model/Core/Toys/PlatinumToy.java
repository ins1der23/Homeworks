package Model.Core.Toys;

/**
 * Класс, описывающий платиновый приз
 */
public class PlatinumToy extends Toy {

    /**
     * Базовый шанс на выпадение
     */
    private static int defaultChance = 10;

    public PlatinumToy(String name) {
        super(name);
        this.chance = defaultChance;
    }

    public PlatinumToy(String name, int chance) {
        super(name, chance);
        if (chance < 0)
            this.chance = defaultChance;
        else
            this.chance = chance;
    }
}
