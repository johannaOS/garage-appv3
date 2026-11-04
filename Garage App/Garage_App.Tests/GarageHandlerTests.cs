using Garage_App.GarageHandling;
namespace Garage_App.Tests
{
    public class GarageHandlerTests
    {
        [Fact]
        public void CreateNewGarage_ValidInput_GarageHasNameAndSpaces()
        {
            //Arrange
            IGarageHandler handler = new GarageHandler();
            string name = "Norra";
            int spaces = 10;

            //Act
            handler.CreateNewGarage(name, spaces);

            //Assert
            Assert.Equal(name, handler.Garages[0].Name);
            Assert.Equal(spaces, handler.Garages[0].Spaces);
        }
        [Fact]
        public void CreateNewGarage_ZeroSpaces_ArgumentExceptionThrown()
        {
            // Arrange
            IGarageHandler handler = new GarageHandler();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                handler.CreateNewGarage("Norra", 0));
        }
        [Fact]
        public void CreateNewGarage_EmptyName_ArgumentExceptionThrown()
        {
            //Arrange
            IGarageHandler handler = new GarageHandler();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => handler.CreateNewGarage("", 4));
        }
        [Fact]
        public void CreateNewGarage_NegativeSpaces_ArgumentExceptionThrown()
        {
            //Arrange
            IGarageHandler handler = new GarageHandler();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => handler.CreateNewGarage("Norra", -9));
        }


    }
}
