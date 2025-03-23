namespace Tutorial3;

public class ContainerShip
{
    public int MaxNumber { get; set; }
    
    public List<Container> Containers;
    public double MaxSpeed { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(int maxNumber, double maxSpeed, double maxWeight)
    
    {
        MaxNumber = maxNumber;
        MaxSpeed = maxSpeed;
        MaxWeight = maxWeight;
        Containers = [];

    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count == MaxNumber) return;
        if (Containers.Sum(a => a.CargoWeight + a.TareWeight) + container.CargoWeight + container.TareWeight > MaxWeight * 1000) return;
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        if (Containers.Count > MaxNumber - containers.Count) return;
        if (Containers.Sum(a => a.CargoWeight + a.TareWeight) + containers.Sum(a => a.CargoWeight + a.TareWeight) > MaxWeight * 1000) return;
        Containers.AddRange(containers);
    }

    public  void RemoveContainer(string number)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == number);
        if (container == null) return;
        Containers.Remove(container);
    }
    
    public void ReplaceContainer(string number, Container newContainer)
    { 
        var container = Containers.FirstOrDefault(c => c.SerialNumber == number);
        if (container  == null) return;
        Containers.Remove(container);
        LoadContainer(newContainer);

    }

    public void TransferContainer(string number, ContainerShip newShip)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == number);
        if (container == null) return;
        Containers.Remove(container);
        newShip.LoadContainer(container);

    }
    
    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Info: Max Speed = {MaxSpeed}, Max Weight = {MaxWeight}, Max Number = {MaxNumber}");
        Containers.ForEach(c => c.GetInfo());
    }

}