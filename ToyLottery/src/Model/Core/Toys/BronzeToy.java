package Model.Core.Toys;

public class BronzeToy extends Toy {

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
