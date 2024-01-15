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
10. Exit: Exits the program.

After executing an action, press Enter to continue and return to the main menu.

## Features

- User-friendly console interface for easy navigation.
- Browse and search for available items.
- List items for sale and set desired prices.
- Make purchases and complete transactions.
- Negotiate and initiate trades with other users.
- Track your inventory and transactions.
- Secure authentication and user account management.

## Requirements

- .NET SDK

## Getting Started

To run the Swap Meet application, follow these steps:

1. Clone the repository to your local machine.
2. Open the project in your preferred C# development environment.
3. Build the project to compile the code.
4. Run the application.

## How to Run

```bash
dotnet run
```

## Contributing
Contributions are welcome! If you encounter any issues or have suggestions for improvements, please let us know.

## Enhancement Considerations
Test the GetVendorWithInventory method.
Test methods in the ServiceManager file.
Test the saveInventoryToFile method in the FileManager.
Test the ServiceManager (e.g., CreateVendorFromUserInput).
Improve code readability and maintainability.
Add error handling and input validation.
