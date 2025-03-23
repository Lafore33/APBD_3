namespace Tutorial3;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set;  }

    public GasContainer(double height,
        double tareWeight, double depth,
        double maxPayload, double pressure) : base(height, tareWeight, depth, "G", maxPayload)

    {
        Pressure = pressure;
    }

    public override void Load(double mass)
    {
        if (mass > MaxPayload)
        {
            Notify();
            throw new OverfillException("Error");
        }
        base.Load(mass);
    }
    

    public override void Clear()
    {
        CargoWeight *= 0.05;
    }

    public void Notify()
    {
        Console.WriteLine($"Hazard in container: {SerialNumber}");
    }
}