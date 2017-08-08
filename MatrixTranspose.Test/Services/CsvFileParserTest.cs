using System;
using System.IO;
using MatrixTranspose.Services;
using MatrixTranspose.Services.Interfaces;
using NSubstitute.Core;
using NUnit.Framework;

namespace MatrixTranspose.Test.Services
{
    [TestFixture]
    class CsvFileParserTest
    {
        private IFileParser _fileParser;
        private string[][] _matrix;

        [SetUp]
        public void Setup()
        {
            _fileParser = new CsvFileParser();
            _matrix = new[] {
                new[] { "25", "38", "12"},
                new[] { "1", "7", "76"},
                new[] { "21", "64", "54" }
            };
        }

        [Test]
        public void Parse()
        {
            var file = CreateFile(_matrix);

            var result = _fileParser.Parse(file);

            Assert.That(result, Is.EqualTo(_matrix));
        }

        [Test]
        public void Unparse()
        {
            var result = _fileParser.Unparse(_matrix);

            var expectedResult = "";
            foreach (var row in _matrix)
            {
                expectedResult += row.Join(",");
                expectedResult += Environment.NewLine;
            }

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static Stream CreateFile(string[][] matrix)
        {
            var file = new MemoryStream();
            var writer = new StreamWriter(file);
            foreach (var row in matrix)
            {
                writer.Write(row.Join(","));
                writer.Write(Environment.NewLine);
            }

            writer.Flush();
            file.Position = 0;

            return file;
        }
    }
}
