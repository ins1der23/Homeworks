package Model.Core.Toys;

/**
 * Класс, описывающий золотой приз
 */
public class BronzeToy extends Toy {

    /**
     * Базовый шанс на выпадение
     */
    private static int defaultChance = 40;

    public BronzeToy(String name) {
        super(name);
        this.chance = defaultChance;
    }

    public BronzeToy(String name, int chance) {
        super(name, chance);
        if (chance < 0)
            this.chance = defaultChance;
        else
            this.chance = chance;
    }
}
