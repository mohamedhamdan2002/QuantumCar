public class HybridEngine : IEngine
{
    private IEngine _activeEngine;
    private List<Engine> _supportedEngines = [ new ElectricEngine(), new GasEngine() ];

    public HybridEngine()
    {
        _activeEngine = _supportedEngines[0];
    }
    public int Speed => _activeEngine.Speed;

    public void Decrease()
    {
        _activeEngine.Decrease();
    }

    public void Increase()
    {
        _activeEngine.Increase();
    }

    public void UpdatedCarSpeed(int carSpeed)
    {
        _activeEngine = carSpeed > 50 ? _supportedEngines[1] : _supportedEngines[0];
        Console.WriteLine($"active Engine Used: {_activeEngine.ToString()}");
    }

    public override string ToString()
    {
        return nameof(HybridEngine);
    }
}
