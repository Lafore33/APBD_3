using Tutorial3;

class Program
{
    private static void Main()
    {
        var ship1 = new ContainerShip(4, 10, 500000.0);
        var ship2 = new ContainerShip(20, 10, 30.0);

        var liquidContainer = new LiquidContainer(100, 999, 200, 26000, false);
        var liquidHContainer = new LiquidContainer(100, 999, 200, 26000, true);
        var gasContainer = new GasContainer(100, 999, 200, 26000, 10);
        var refrigeratedBananas = new RefrigeratedContainer(100, 999, 200, 26000, "Cheese", 15.0);
        var extraContainer = new GasContainer(100, 999, 200, 26000, 10);

        try
        {
            liquidContainer.Load(24000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        liquidHContainer.Load(12000);
        gasContainer.Load(20000);
        refrigeratedBananas.Load(20000);
        
        Console.WriteLine("---");
        liquidContainer.GetInfo();
        liquidHContainer.GetInfo();
        gasContainer.GetInfo();
        refrigeratedBananas.GetInfo();

        Console.WriteLine("---");
        ship1.LoadContainer(liquidContainer);
        ship1.PrintShipInfo();
        ship1.LoadContainers([liquidHContainer, gasContainer, refrigeratedBananas]);
        ship1.PrintShipInfo();
        
        Console.WriteLine("---");
        ship1.LoadContainer(extraContainer);
        ship1.PrintShipInfo();
            
        Console.WriteLine("---");
        ship1.RemoveContainer(gasContainer.SerialNumber);
        ship1.PrintShipInfo();
        
        Console.WriteLine("---");
        gasContainer.Clear(); // Should leave 1000 kg (5% of 20000)
        gasContainer.GetInfo();
        
        Console.WriteLine("---");
        ship1.ReplaceContainer(liquidHContainer.SerialNumber, gasContainer);
        ship1.PrintShipInfo();
        
        Console.WriteLine("---");
        ship1.TransferContainer(gasContainer.SerialNumber, ship2);
        ship1.PrintShipInfo();
        ship2.PrintShipInfo();
        
        Console.WriteLine("---");
        liquidContainer.GetInfo();
        liquidHContainer.GetInfo();
        gasContainer.GetInfo();
        refrigeratedBananas.GetInfo();
        
        Console.WriteLine("---");
        ship1.PrintShipInfo();
        ship2.PrintShipInfo();

    }
}