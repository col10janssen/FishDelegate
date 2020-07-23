using System;

public interface IFish
{
    Egg Lay();

    //Remove spawn interface is it's not necessary
}

public class Egg
{
    //Assign the delegate to the private variable so it can be called in hatch instead of assignign the result of the delgate and then returning that
    private Func<IFish> SpawnFish;
    private bool Hatched = false;

    public Egg(Func<IFish> fishToHatch)
    {
        SpawnFish = fishToHatch;
    }

    public IFish Hatch()
    {
        //if Hatched throw an Egg Hatched Exception
        if (Hatched)
            throw new EggHatchedException("Egg has already hatched and cannot produce more IFish");

        Hatched = true;
        Console.WriteLine("A baby fish was has hatched!");
        return SpawnFish();
    }
}

//Create a specific egg hatch exception
public class EggHatchedException : Exception
{
    public EggHatchedException(string message): base(message)
    {
    }
}

public class Tuna : IFish
{
    public Egg Lay()
    {
        //Turn the functionality being passed in into a lambda instead since New Tuna() returns an IFish result. 
        return new Egg(() => new Tuna());
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var fish = new Tuna();
            var egg = fish.Lay();
            var smallFish = egg.Hatch();

            var anotherSmallFish = egg.Hatch();
        }
        catch(EggHatchedException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}