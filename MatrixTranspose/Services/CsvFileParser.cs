using System.IO;
using System.Text;
using CsvHelper;
using MatrixTranspose.Services.Interfaces;

namespace MatrixTranspose.Services
{
    public class CsvFileParser : IFileParser
    {
        public string[][] Parse(Stream file)
        {
            using (file)
            {
                var csvParser = new CsvParser(new StreamReader(file));
                var firstRecord = csvParser.Read();
                var matrix = new string[firstRecord.Length][];
                matrix[0] = firstRecord;

                for (var i = 1; i < firstRecord.Length; i++)
                {
                    var record = csvParser.Read();
                    matrix[i] = record;
                }

                return matrix;
            }
        }

        public string Unparse(string[][] matrix)
        {
            using (var file = new MemoryStream())
            {
                var writer = new StreamWriter(file);
                var csvWriter = new CsvWriter(writer);

                foreach (var row in matrix)
                {
                    foreach (var item in row)
                    {
                        csvWriter.WriteField(item);
                    }
                    csvWriter.NextRecord();
                }
                writer.Flush();

                return new string(Encoding.UTF8.GetChars(file.ToArray()));
            }
           
        }
    }
}
