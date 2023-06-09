# Employee Monthly Pay Slip

A console application to generate employee monthly pay slips based on the provided input data.

Assumptions:
1. The input data will be in a CSV format with the following fields: first name, last name, annual salary, super rate, pay period. Each row will represent the details of one employee.
2. The super rate will be a percentage with a maximum value of 50%.
3. The pay period will be a calendar month, represented by the name of the month (e.g. "September").
4. The output will also be in CSV format, with the following fields: name, pay period, gross income, income tax, net income, super.
5. The tax rates are static and will not change during the runtime of the application.

## Prerequisites

- Visual Studio Community 2013 or later
- .NET Framework 4.5.2 Developer Pack

## Getting Started

1. **Install .NET Framework 4.5.2 Developer Pack**\
   Download and install the .NET Framework 4.5.2 Developer Pack from the Microsoft website:\
   [Download .NET Framework 4.5.2 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net452-developer-pack-offline-installer)

2. **Clone or download the project**\
   Clone the GitHub repository or download the project files from the provided link.

3. **Open the solution in Visual Studio**\
   Open the solution (.sln) file in Visual Studio.

4. **Build the solution**\
   Build the solution by pressing `Ctrl + Shift + B` or by going to `Build > Build Solution`.

5. **Set the startup project**\
   Set the Smartly project as the startup project if it's not already set.\
   Right-click on the Smartly project in the Solution Explorer and click on `Set as StartUp Project`.

6. **Run the application**\
   Run the application by pressing `F5` or by going to `Debug > Start Debugging`.\
   The console application should now run and process the input.csv file, generating the output.csv file in the "Data" folder.

7. **Check the output**\
   After the application finishes processing the payslips, you can find the result in the "Data\output.csv" file.

**Note:** Make sure to include the input.csv file in the "Data" folder with the correct format before running the application.