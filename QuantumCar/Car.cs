public class Car
{
    public int Speed { get; private set; }
    private IEngine _engine;
    public Car(IEngine engine)
    {
        _engine = engine;
    }
    public void SwitchCarEngine(IEngine engine)
    {
        _engine = engine;
    }

    public void Start()
    {
        Console.WriteLine("Car Started At Speed (0)");
        Speed = 0;
    }
    public void Stop()
    {
        if(Speed > 0)
        {
            //here we can use loop to brake the speed until zero and then stop the car
            Console.WriteLine("Please Brake the speed to (0 km/h).. to stop the car");
            return;
        }
        Console.WriteLine("Car Stopped..");

    }
    public void Accelerate()
    {
        if (Speed < 200)
        {
            Console.WriteLine($"Speed Accelerated form ({Speed} km/h) to ({Speed + 20} km/h)");
            Speed += 20;
            _engine.UpdatedCarSpeed(Speed);
        } else
        {
            Console.WriteLine($"Speed can't Accelerated than (200 km/h) ");
        }
    }
    public void Brake()
    {
        if (Speed == 0)
        {
            Console.WriteLine($"You can't Brake.. the Car Speed (0 km/h) You Can Accelerate or stop");
            return;
        }
        Console.WriteLine($"Speed Braked From ({Speed} km/h) to ({Speed - 20} km/h)");
        Speed -= 20;
        _engine.UpdatedCarSpeed(Speed);

    }

    public override string ToString()
    {
        return $"Car With Engine {_engine.ToString()}";
    }
}
