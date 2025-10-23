class TemperatureChangedEventArgs:EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }
    public double Difference { get; }

    public TemperatureChangedEventArgs(double OldTemperature, double NewTemperature)
    {
        this.OldTemperature = OldTemperature;
        this.NewTemperature = NewTemperature;
        this.Difference = NewTemperature - OldTemperature;
    }
}
class Temperature
{
    public event EventHandler<TemperatureChangedEventArgs> OntemperatureChanged = delegate { };
    public double OldTemperature { get; set; }
    public double CurrentTemperature { get; set; }

    public void SetTemtepature(double NewTemperature)
    {
        if (this.CurrentTemperature != NewTemperature)
        {
            this.OldTemperature = CurrentTemperature;
            this.CurrentTemperature = NewTemperature;
            RaiseEventOnTempurartureChanged();
        }
    }
    private void RaiseEventOnTempurartureChanged()
    {
        this.OntemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(this.OldTemperature, this.CurrentTemperature));
    }
}

class Display
{
    public void Subscribe(Temperature temperature)
    {
          temperature.OntemperatureChanged += this.HandleTempuratureChanged;
    }
    public void HandleTempuratureChanged(object? sender , TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"====================================================");
        Console.WriteLine($"____________________Temperature_____________________");
        Console.WriteLine($"====================================================");
        Console.WriteLine($"Old Tempurature = {e.OldTemperature}°C");
        Console.WriteLine($"New Tempurature = {e.NewTemperature}°C");
        Console.WriteLine($"Difference      = {e.Difference}°C");
        Console.WriteLine($"====================================================\n");
    }
}


class Program
{
    static void Main()
    {
        Temperature temperature1 = new Temperature();
        Display display1 = new Display();
        display1.Subscribe(temperature1);
        temperature1.SetTemtepature(50);
        temperature1.SetTemtepature(-120);

        Console.ReadLine();
    }
}

