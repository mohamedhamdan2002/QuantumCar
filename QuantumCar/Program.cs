
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
