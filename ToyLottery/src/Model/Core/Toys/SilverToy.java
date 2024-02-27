package Model.Core.Toys;
/**
 * Класс, описывающий серебряный приз
 */
public class SilverToy extends Toy {

    /**
     * Базовый шанс на выпадение
     */
    private static int defaultChance = 30;

    public SilverToy(String name) {
        super(name);
        this.chance = defaultChance;
    }

    public SilverToy(String name, int chance) {
        super(name, chance);
        if (chance < 0)
            this.chance = defaultChance;
        else
            this.chance = chance;
    }
}
