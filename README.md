# SwapMeet 🔄

Swap Meet is a console-based application developed in C# and .NET. The program allows users to manage vendors and their inventories. It provides various functionalities such as adding vendors, editing vendor information, managing inventory items, checking item availability, and swapping items between vendors.

## Usage

Upon running the application, you will be presented with a menu of options. Enter a number corresponding to the desired action and press Enter to proceed. The available options are:

1. List all vendors and their inventory.
2. Add a new vendor and their inventory.
3. Edit a vendor name.
4. Get inventory listing for the specific vendor.
5. Add an item to the vendor's inventory.
6. Remove an item from the vendor's inventory.
7. Get all items by category for the specific vendor.
8. Check item availability in vendor inventory.
9. Swap specific items between vendors.
10. Exits the program.

After executing an action, press Enter to continue and return to the main menu.

## Features

1. Vendor Manager
2. Inventory Manager
3. File Manager
4. Service Manager
5. Menu Manager

## Requirements

1. .NET SDK

## Getting Started

To run the Swap Meet application, follow these steps:

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/viktoriiazolotova/cSharpSwapMeet.git
   ```
3. Open the project in your preferred C# development environment
4. Go to the **root** directory, then to **src** folder.
5. Build the project to compile the code:
   ```bash
   dotnet build
   ```
6. Run the application:
    ```bash
    dotnet run
    ```
7. To run tests: Go to **test** folder, then **ModelsTests** folder:
    ```bash
    dotnet test
    ```

## Enhancement Considerations
1. Improve code readability and maintainability.
2. Improve code testability:
 - Test the saveInventoryToFile method in the FileManager.
 - Test methods in the ServiceManager file.
 - Test methods in the MenuManager file.

## Contributing
Contributions are welcome! If you encounter any issues or have suggestions for improvements, please let us know.


