package Model.Core.Toys;

/**
 * Класс, описывающий золотой приз
 */
public class GoldToy extends Toy {

    /**
     * Базовый шанс на выпадение
     */
    private static int defaultChance = 20;

    public GoldToy(String name) {
        super(name);
        this.chance = defaultChance;
    }

    public GoldToy(String name, int chance) {
        super(name, chance);
        if (chance < 0)
            this.chance = defaultChance;
        else
            this.chance = chance;
    }

}
