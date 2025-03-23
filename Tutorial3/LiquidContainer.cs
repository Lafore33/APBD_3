namespace Tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardousCargoStored { get; set; }

    public LiquidContainer(double height,
        double tareWeight, double depth,
        double maxPayload, bool isHazardous) : base(height, tareWeight, depth, "L", maxPayload)
    {
        IsHazardousCargoStored = isHazardous;
    }

    public void Notify()
    {
        Console.WriteLine($"Hazard in container: {SerialNumber}");
    }
    public override void Load(double mass)
    {
        var lim = IsHazardousCargoStored ? MaxPayload / 2 : MaxPayload * 0.9;
        if (mass > lim)
        {
            Notify();
            throw new OverfillException("Error");
        }
        base.Load(mass);

    }

}