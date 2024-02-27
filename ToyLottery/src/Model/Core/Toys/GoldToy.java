package Model.Core.Toys;


public class GoldToy extends Toy {

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
