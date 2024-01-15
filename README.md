# SwapMeet 🔄

Swap Meet is a console-based application developed in C# and .NET. The program allows users to manage vendors and their inventories. It provides various functionalities such as adding vendors, editing vendor information, managing inventory items, checking item availability, and swapping items between vendors.

## Usage

Upon running the application, you will be presented with a menu of options. Enter a number corresponding to the desired action and press Enter to proceed. The available options are:

<img width="525" alt="image" src="https://github.com/viktoriiazolotova/cSharpSwapMeet/assets/74393811/1c31829b-d5bb-4e92-96cf-ed8badd57e7b">


After executing an action, press Enter to continue and return to the main menu.

## Features
1. **Vendor Management:**
- Add, edit, and remove vendors.
- List vendors and their inventories.
- Get inventory listing for a specific vendor.
  
2. **Inventory Management:**
- Add and remove items from a vendor's inventory.
- Get all items by category for a specific vendor.
- Check item availability in a vendor's inventory.

3. **File Manager:**
- Save vendor and inventory data to a  txt file.
- Load vendor and inventory data from a txt file.

4. **Service Management:**
- Swap specific items between vendors.

5. **Menu Management:**
- Display a user-friendly menu with numbered options.
- Execute selected actions and return to the main menu.
  
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


