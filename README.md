
# Snipe-IT UI Tests

This project contains UI automation tests for the Snipe-IT web application using Playwright for .NET and NUnit as the test framework.

## Prerequisites

Before running the tests locally, make sure the following dependencies are installed:

### Local Prerequisites

1. **Install .NET 8.0 SDK**  
   Download and install the .NET SDK from [here](https://dotnet.microsoft.com/download).

2. **Install Visual Studio 2022**  
   Ensure you have Visual Studio 2022 installed with the following workloads:
   - ASP.NET and web development
   
   You can download Visual Studio from [here](https://visualstudio.microsoft.com/).

3. **Install Playwright Browsers**  
   To install the Playwright browsers, run the following command in the project directory:
   ```bash
   dotnet build
   .\bin\Debug\net8.0\playwright.ps1 install --with-deps
   ```
   
   NOTE: You might have to use the following command first to allow running scripts in PowerShell:
   ```bash
   Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
   ````

## Running Tests Locally in Visual Studio

### Step 1: Open the Solution

Open the project in Visual Studio by double-clicking the `.sln` file.

### Step 2: Build the Project

In Visual Studio, click on `Build > Build Solution` (or press `Ctrl+Shift+B`).

### Step 3: Run the Tests

1. Open the `Test Explorer` window (`Test > Test Explorer`).
2. Click on `Run All` to run all the tests in the project. (NB: If the form's content or structure changes, you'll need to modify the selectors and field filling actions in your test to reflect the new form.)

Tests will execute, and results will be displayed in the `Test Explorer`.

## Run the Tests interactively

1. Open the terminal and navigate to the project directory.
2. Run the following command to enable headed mode:
   ```bash
   $env:HEADED="1"
   ```
3. Run the following command to execute the tests:
   ```bash
   dotnet test
   ```

## Run the Tests with settings from .runsettings file

1. Open the terminal and navigate to the project directory.
2. Run the following command to run the test using the settings from the .runsettings file:
   ```bash
   dotnet test --settings:.runsettings
   ```
