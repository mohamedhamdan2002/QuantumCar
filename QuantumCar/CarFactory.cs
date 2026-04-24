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
