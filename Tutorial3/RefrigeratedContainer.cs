namespace Tutorial3;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    
    private static readonly Dictionary<string, double> ProductTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public readonly string TypeOfProduct;
    
    public readonly double Temperature;
    
    public RefrigeratedContainer(double height,
        double tareWeight, double depth,
        double maxPayload, string typeOfProduct, double temperature) : base(height, tareWeight, depth, "C", maxPayload)
    {
        if (!ProductTemperatures.ContainsKey(typeOfProduct) || ProductTemperatures[typeOfProduct] > temperature)
        {
            throw new ArgumentException("Invalid Arguments");
        }

        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
    }
    
    public void Notify()
    {
        Console.WriteLine($"Hazard in container: {SerialNumber}");
    }

}