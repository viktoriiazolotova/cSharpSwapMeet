// using NUnit.Framework;
// using cSharpSwapMeet; // Add the appropriate namespace for your Vendor class

// namespace cSharpSwapMeet.Tests
// {
//     [TestFixture]
//     public class VendorTests
//     {
//         [Test]
//         public void CheckItemAvailability_ShouldReturnTrueForAvailableItem()
//         {
//             // Arrange
//             var vendor = new Vendor("Test Vendor");
//             var vase = new Decor(1);
//             vendor.AddItem(vase);

//             // Act
//             var result = vendor.CheckItemAvailability(vase);

//             // Assert
//             // Assert.AreEqual(result, true);
//         }

//         [Test]
//         public void CheckItemAvailability_ShouldReturnFalseForUnavailableItem()
//         {
//             // Arrange
//             var vendor = new Vendor("Test Vendor");
//             var vase = new Decor(1);

//             // Act
//             var result = vendor.CheckItemAvailability(vase);

//             // Assert
//             // Assert.IsFalse(result);
//         }

//         [Test]
//         public void RemoveItem_ShouldRemoveItemAndReturnTrue()
//         {
//             // Arrange
//             var vendor = new Vendor("Test Vendor");
//             var vase = new Decor(1);
//             vendor.AddItem(vase);

//             // Act
//             var result = vendor.RemoveItem(vase);

//             // Assert
//             // Assert.IsTrue(result);
//             // Assert.IsFalse(vendor.CheckItemAvailability(vase)); // Ensure the item is no longer available
//         }

//         [Test]
//         public void RemoveItem_ShouldReturnFalseForNonexistentItem()
//         {
//             // Arrange
//             var vendor = new Vendor("Test Vendor");
//             var vase = new Decor(1);

//             // Act
//             var result = vendor.RemoveItem(vase);

//             // Assert
//             // Assert.IsFalse(result);
//         }

//         [Test]
//         public void GetItemsByCategory_ShouldReturnCorrectItems()
//         {
//             // Arrange
//             var vendor = new Vendor("Test Vendor");
//             var vase = new Decor(1);
//             var radio = new Electronics(5);
//             vendor.AddItem(vase);
//             vendor.AddItem(radio);

//             // Act
//             var result = vendor.GetItemsByCategory("Decor");

//             // Assert
//             // Assert.AreEqual(1, result.Count);
//             // Assert.Contains(vase, result);
//             // Assert.DoesNotContain(radio, result);
//         }
//     }
// }
