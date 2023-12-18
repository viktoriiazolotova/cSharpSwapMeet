using Xunit;
using System;

namespace cSharpSwapMeet.Tests
{
    public class DecorTests
    {

        //does not work yet
        // [Fact]
        // public void ConstructorWithoutItemId_ShouldAutoGenerateItemId()
        // {
        //     // Arrange & Act

        //     Decor decor1 = new Decor();
        //     Decor decor2 = new Decor();
        //     Decor decor3 = new Decor();

        //     // Assert

        //     Assert.Equal(1, decor1.ItemID);
        //     Assert.Equal(2, decor2.ItemID);
        //     Assert.Equal(3, decor3.ItemID);
        // }

        [Fact]
        public void ConstructorWithExplicitItemId_ShouldUseSpecifiedItemId()
        {
            // Arrange & Act
            Decor decor = new Decor(itemId: 42, condition: 2.5);

            // Assert
            Assert.Equal(42, decor.ItemID);
            Assert.Equal(2.5, decor.Condition);
        }

        [Fact]
        public void ConstructorWithoutCondition_ShouldDefaultToZeroCondition()
        {
            // Arrange & Act
            Decor decor1 = new Decor();

            // Assert
            Assert.Equal(0.0, decor1.Condition);
        }

        [Fact]
        public void ConstructorWithCondition_ShouldUseSpecifiedCondition()
        {
            // Arrange & Act
            double specifiedCondition = 3.7;
            Decor decor2 = new Decor(condition: specifiedCondition);

            // Assert
            Assert.Equal(specifiedCondition, decor2.Condition);
            //Console.WriteLine(decor2.ItemID);
        }
    }
}
