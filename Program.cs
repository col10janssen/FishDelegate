using System;

public interface IFish
{
    Egg Lay();
}

public class Egg
{
    private IFish FishToHatch { get; set; }

    public Egg(Func<IFish> fishToHatch)
    {
        FishToHatch = fishToHatch();
    }

    public IFish Hatch()
    {
        return FishToHatch;
    }
}

public class Tuna : IFish
{
    public Egg Lay()
    {
        return new Egg(SpawnTuna);
    }

    private static IFish SpawnTuna()
    {
        return new Tuna();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var fish = new Tuna();
        var egg = fish.Lay();
        var smallFish = egg.Hatch();
    }
}