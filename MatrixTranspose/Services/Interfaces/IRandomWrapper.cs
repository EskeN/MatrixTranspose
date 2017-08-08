namespace MatrixTranspose.Services.Interfaces
{
    public interface IRandomWrapper
    {
        int Next(int max);
        int Next(int min, int max);
    }
}
