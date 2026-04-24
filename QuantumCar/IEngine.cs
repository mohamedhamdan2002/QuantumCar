public interface IEngine
{
    public int Speed { get; }
    void UpdatedCarSpeed(int carSpeed);
    void Increase();
    void Decrease();
}
