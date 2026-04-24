
while (true)
{
    Console.Write("Enter [1] GasCar, [2] ElectirCar, [3] HybirdCar : ");
    if (Enum.TryParse(Console.ReadLine(), out EngineType type) &&
        Enum.IsDefined(typeof(EngineType), type))
    {
        Car? car = null;
        switch (type)
        {
            case EngineType.Gass:
                car = CarFactory.Create(EngineType.Gass);
                break;
            case EngineType.Electric:
                car = CarFactory.Create(EngineType.Electric);
                break;
            case EngineType.Hybrid:
                car = CarFactory.Create(EngineType.Hybrid);
                break;
            default:
                break;
        };
        Console.Clear();
        while(true)
        {
            int choice;
            Console.WriteLine(car?.ToString());
            System.Console.WriteLine("------------ Car Operation --------------");
            System.Console.WriteLine($" |-- [01] start");
            System.Console.WriteLine($" |-- [02] brake");
            System.Console.WriteLine($" |-- [03] accelerate");
            System.Console.WriteLine($" |-- [04] stop");
            System.Console.WriteLine($" |-- Any other Key to skip");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        car?.Start();
                        break;
                    case 2:
                        car?.Brake();
                        break;
                    case 3:
                        car?.Accelerate();
                        break;
                    case 4:
                        car?.Stop();
                        break;
                    default:
                        break;

                }
            }
        }

    }
    else
    {
        System.Console.WriteLine("Infalid choice !!! press and key to continue");
    }
    Console.ReadKey();
}

public static class CarFactory
{
    public static Car Create(EngineType engineType) 
    {
        return engineType switch
        {
            EngineType.Gass => new Car(new GasEngine()),
            EngineType.Electric => new Car(new ElectricEngine()),
            EngineType.Hybrid => new Car(new HybridEngine()),
            _ => throw new NotImplementedException()
        };
    }
    public static void SwitchCarEngine(Car car, Engine engine)
    {
        car.SwitchCarEngine(engine);
    }

} 
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

public interface IEngine
{
    public int Speed { get; }
    void UpdatedCarSpeed(int carSpeed);
    void Increase();
    void Decrease();
}

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

public class GasEngine : Engine
{
    public override string ToString()
    {
        return nameof(GasEngine);
    }
}

public class ElectricEngine : Engine
{
    public override string ToString()
    {
        return nameof(ElectricEngine);
    }
}

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

public enum EngineType 
{ 
    Gass = 1,
    Electric,
    Hybrid
}
