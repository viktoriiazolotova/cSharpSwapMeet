using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace cSharpSwapMeet.Tests
{
    public class FileManagerTests
    {
        [Fact]
        public void ReadVendorsFromFile_SuccessfullyReadsVendors()
        {
            // Arrange
            var filePath = "test_inventory.txt";
            CreateTestFile(filePath);

            // Act
            var vendors = FileManager.ReadVendorsFromFile(filePath);

            // Assert
            Assert.NotNull(vendors);
            Assert.NotEmpty(vendors);
            Assert.Equal(2, vendors.Count);

            // Vendor1 assertions
            Assert.Equal("Vendor1", vendors[0].VendorName);
            Assert.Equal(3, vendors[0].Inventory.Count);
            Assert.Equal(1, vendors[0].Inventory[0].ItemID);
            Assert.Equal("Decor", vendors[0].Inventory[0].Category);
            Assert.Equal(2.5, vendors[0].Inventory[0].Condition);

            // Vendor2 assertions
            Assert.Equal("Vendor2", vendors[1].VendorName);
            Assert.Equal(2, vendors[1].Inventory.Count);
            Assert.Equal(4, vendors[1].Inventory[0].ItemID);
            Assert.Equal("Electronics", vendors[1].Inventory[0].Category);
            Assert.Equal(3.0, vendors[1].Inventory[0].Condition);
            Assert.Equal(5, vendors[1].Inventory[1].ItemID);
            Assert.Equal("Decor", vendors[1].Inventory[1].Category);
            Assert.Equal(2.0, vendors[1].Inventory[1].Condition);


            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void ReadVendorsFromFile_HandlesEmptyFile()
        {
            // Arrange
            var filePath = "empty_inventory.txt";
            File.WriteAllText(filePath, "");

            // Act
            var vendors = FileManager.ReadVendorsFromFile(filePath);

            // Assert
            Assert.NotNull(vendors);
            Assert.Empty(vendors);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void ReadVendorsFromFile_HandlesFileNotFound()
        {
            // Arrange
            var filePath = "nonexistent_inventory.txt";

            // Act
            var vendors = FileManager.ReadVendorsFromFile(filePath);

            // Assert
            Assert.NotNull(vendors);
            Assert.Empty(vendors);
        }

        private void CreateTestFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Vendor1|1|Decor|2.5|2|Electronics|4.0|3|Clothing|7.0");
                writer.WriteLine("Vendor2|4|Electronics|3.0|5|Decor|2.0");
            }
        }
    }
}
