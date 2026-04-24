public abstract class Engine : IEngine
{
    public int Speed { get; private set; }
    private int _carSpeed = 0;
    protected Engine()
    {
       
    }
    
    public virtual void Increase()
    {
        Speed += 1;
    }
    public virtual void Decrease()
    {
        if (Speed > 0)
            Speed -= 1;
    }

    // this for simplicity event is perfect in this case 
    public void UpdatedCarSpeed(int carSpeed)
    {
        Console.WriteLine($"Car Speed Changed From {_carSpeed} to {carSpeed}");
        _carSpeed = carSpeed;
    }
}
