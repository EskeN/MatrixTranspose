using System.IO;

namespace MatrixTranspose.Services.Interfaces
{
    public interface IFileParser
    {
        string[][] Parse(Stream file);
        string Unparse(string[][] matrix);
    }
}
