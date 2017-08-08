using System;
using MatrixTranspose.Services.Interfaces;

namespace MatrixTranspose.Services
{
    public class RandomWrapper : IRandomWrapper
    {
        private readonly Random _random = new Random();

        public int Next(int max)
        {
            return _random.Next(max);
        }

        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
