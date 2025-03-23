namespace Tutorial3;



public abstract class Container
{
    private static int _counter = 1;

    public double CargoWeight { get; set; }
    
    public readonly double Height;
    public readonly double TareWeight;
    public readonly double Depth;
    public readonly string SerialNumber;
    public readonly double MaxPayload;
    
    public Container(double height, 
            double tareWeight, double depth, 
            string type,double maxPayload)
    {
        _counter++;
        
        CargoWeight = 0;
        Height = height;
        Depth = depth;
        SerialNumber = $"KON-{type}-{_counter}";
        TareWeight = tareWeight;
        MaxPayload = maxPayload;
    }

    public virtual void Clear()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double mass)
    {
        if (CargoWeight + mass > MaxPayload)
        {
            throw new OverfillException("Error");
        }

        CargoWeight += mass;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Container Info: Cargo Weight = {CargoWeight}, Height = {Height}, " +
                          $"Tare Weight = {TareWeight}, Depth = {Depth}, " +
                          $"Serial Number = {SerialNumber}, Maximum Payload = {MaxPayload}");
    }
}