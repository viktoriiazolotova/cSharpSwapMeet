using System;
using Xunit;
using cSharpSwapMeet;

namespace cSharpSwapMeetTests
{
    public class VendorTests
    {
        [Fact]
        public void AddItem_ShouldAddItemToInventoryAndReturnTrue()
        {
            // Arrange
            var vendor = new Vendor("Jonh Doe");
            var item1 = new Clothing(1);
            var item2 = new Clothing(2);

            // Act
            bool result = vendor.AddItem(item1);

            // Assert
            Assert.True(result);
            Assert.Contains(item1, vendor.Inventory);
            Assert.DoesNotContain(item2, vendor.Inventory);
        }
        [Fact]
        public void CheckItemAvailability_ShouldReturnTrueForAvailableItem()
        {
            // Arrange
            var vendor = new Vendor("Jonh Doe");
            var item1 = new Decor(3);
            vendor.AddItem(item1);

            // Act
            bool result = vendor.CheckItemAvailability(item1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckItemAvailability_ShouldReturnFalseForNotAvailableItem()
        {
            // Arrange
            var vendor = new Vendor("Jonh Doe");
            var item1 = new Decor(4);

            // Act
            bool result = vendor.CheckItemAvailability(item1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveItem_ShouldRemoveItemFromInventoryAndReturnTrue()
        {
            // Arrange
            var vendor = new Vendor("Jonh Doe");
            var item1 = new Decor(1);
            vendor.AddItem(item1);


            // Act
            var result = vendor.RemoveItem(item1);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(item1, vendor.Inventory);
        }

        [Fact]
        public void RemoveItem_ShouldNotRemoveItemFromInventoryAndReturnFalse()
        {
            // Arrange
            var vendor = new Vendor("Jonh Doe");
            var item1 = new Decor(1);

            // Act
            var result = vendor.RemoveItem(item1);

            // Assert
            Assert.False(result);
            Assert.DoesNotContain(item1, vendor.Inventory);
        }

        [Fact]
        public void GetItemsByCategory_ShouldReturnCorrectItems()
        {
            // Arrange
            var vendor = new Vendor("Jonh Doe");
            var item1 = new Decor(1);
            var item2 = new Clothing(4);
            var item3 = new Clothing(5);

            vendor.AddItem(item1);
            vendor.AddItem(item2);
            vendor.AddItem(item3);

            // Act
            var result = vendor.GetItemsByCategory("Clothing");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(item2, result);
            Assert.Contains(item3, result);
            Assert.DoesNotContain(item1, result);
        }

        [Fact]
        public void SwapItems_ShouldSwapItemsBetweenVendorsSuccessfully()
        {
            // Arrange
            var vendor1 = new Vendor("Vendor1");
            var vendor2 = new Vendor("Vendor2");
            var item1 = new Decor(1);
            var item2 = new Clothing(2);
            vendor1.AddItem(item1);
            vendor2.AddItem(item2);

            // Act
            var result = vendor1.SwapItems(vendor2, item1, item2);

            // Assert
            Assert.Equal("You successfully swapped items", result);
            Assert.Contains(item2, vendor1.Inventory);
            Assert.Contains(item1, vendor2.Inventory);
            Assert.DoesNotContain(item1, vendor1.Inventory);
            Assert.DoesNotContain(item2, vendor2.Inventory);
        }

        [Fact]
        public void SwapItems_ShouldSwapItemsBetweenVendorsUnsuccessfully()
        {
            // Arrange
            var vendor1 = new Vendor("Vendor1");
            var vendor2 = new Vendor("Vendor2");
            var item1 = new Decor(1);
            var item2 = new Clothing(2);
            vendor1.AddItem(item1);

            // Act
            var result = vendor1.SwapItems(vendor2, item1, item2);

            // Assert
            Assert.Equal("Swapping items was unsuccessful, please check inventory", result);
            Assert.Contains(item1, vendor1.Inventory);
            Assert.DoesNotContain(item2, vendor1.Inventory);
            Assert.DoesNotContain(item1, vendor2.Inventory);
        }

        [Fact]
        public void SwapFirstItems_ShouldSwapFirstItemsBetweenVendorsSuccessfully()
        {
            // Arrange
            var vendor1 = new Vendor("Vendor1");
            var vendor2 = new Vendor("Vendor2");
            var item1 = new Decor(1);
            var item2 = new Clothing(2);
            var item3 = new Clothing(3);
            var item4 = new Electronics(4);
            vendor1.AddItem(item1);
            vendor1.AddItem(item2);
            vendor2.AddItem(item3);
            vendor2.AddItem(item4);

            // Act
            var result = vendor1.SwapFirstItems(vendor2);

            // Assert
            Assert.Equal("You successfully swapped items", result);
            Assert.Contains(item3, vendor1.Inventory);
            Assert.Contains(item2, vendor1.Inventory);
            Assert.Contains(item1, vendor2.Inventory);
            Assert.Contains(item4, vendor2.Inventory);
            Assert.DoesNotContain(item1, vendor1.Inventory);
            Assert.DoesNotContain(item3, vendor2.Inventory);
        }

        [Fact]
        public void SwapFirstItems_ShouldSwapFirstItemsBetweenVendorsUnsuccessfully()
        {
            // Arrange
            var vendor1 = new Vendor("Vendor1");
            var vendor2 = new Vendor("Vendor2");
            var item1 = new Decor(1);
            var item2 = new Clothing(2);

            vendor1.AddItem(item1);
            vendor1.AddItem(item2);


            // Act
            var result = vendor1.SwapFirstItems(vendor2);

            // Assert
            Assert.Equal("Swapping items was unsuccessful, one of the vendor does not have inventory", result);
            Assert.Contains(item1, vendor1.Inventory);
            Assert.Contains(item2, vendor1.Inventory);

            Assert.DoesNotContain(item1, vendor2.Inventory);
            Assert.DoesNotContain(item2, vendor2.Inventory);
        }


    }
}
