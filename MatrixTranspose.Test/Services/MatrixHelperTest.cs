using MatrixTranspose.Services;
using MatrixTranspose.Services.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace MatrixTranspose.Test.Services
{
    [TestFixture]
    class MatrixHelperTest
    {
        private IRandomWrapper _randomWrapper;
        private MatrixHelper _matrixHelper;

        [SetUp]
        public void Setup()
        {
            _randomWrapper = Substitute.For<IRandomWrapper>();
            _matrixHelper = new MatrixHelper(_randomWrapper);
        }

        [Test]
        public void Rotate()
        {
            var matrix = new [] {
                new[] { "25", "38", "12"},
                new[] { "1", "7", "76"},
                new[] { "21", "64", "54" }
            };

            var result = _matrixHelper.Rotate(matrix);

            var expectedResult = new[] {
                new[] { "21", "1", "25"},
                new[] { "64", "7", "38"},
                new[] { "54", "76", "12" }
            };

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GenerateRandom()
        {

            _randomWrapper.Next(Arg.Any<int>(), Arg.Any<int>()).Returns(3);
            _randomWrapper.Next(Arg.Any<int>()).Returns(3);

            var result = _matrixHelper.GenerateRandom();

            var expectedResult = new[] {
                new[] { "3", "3", "3"},
                new[] { "3", "3", "3"},
                new[] { "3", "3", "3" }
            };

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
