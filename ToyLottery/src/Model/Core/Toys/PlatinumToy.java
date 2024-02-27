package Model.Core.Toys;

public class PlatinumToy extends Toy {

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
