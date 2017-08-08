using MatrixTranspose.Services.Interfaces;

namespace MatrixTranspose.Services
{
    public class MatrixHelper : IMatrixHeper
    {
        private const int MaxMatrixSize = 10;
        private const int MinMatrixSize = 2;
        private const int MaxCellValue = 10000;

        private readonly IRandomWrapper _randomWrapper;
        public MatrixHelper(IRandomWrapper randomWrapper)
        {
            _randomWrapper = randomWrapper;
        }

        public string[][] Rotate(string[][] martix)
        {
            var size = martix.Length;
            for (var i = 0; i < size / 2; i++)
            {
                for (var j = i; j < size - i - 1; j++)
                {
                    var tmp = martix[i][j];
                    martix[i][j] = martix[size - j - 1][i];
                    martix[size - j - 1][i] = martix[size - i - 1][size - j - 1];
                    martix[size - i - 1][size - j - 1] = martix[j][size - i - 1];
                    martix[j][size - i - 1] = tmp;
                }
            }

            return martix;
        }

        public string[][] GenerateRandom()
        {
            var size = _randomWrapper.Next(MinMatrixSize, MaxMatrixSize);
            var matrix = new string[size][];
            for (var i = 0; i < size; i++)
            {
                matrix[i] = new string[size];
                for (var j = 0; j < size; j++)
                {
                    matrix[i][j] = _randomWrapper.Next(MaxCellValue).ToString();
                }
            }

            return matrix;
        }
    }
}
