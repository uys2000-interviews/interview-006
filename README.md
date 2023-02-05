# Mehmet Uysal Razor + Blazor App

## Table of Content

- [Mehmet Uysal Razor + Blazor App](#mehmet-uysal-razor--blazor-app)
  - [Table of Content](#table-of-content)
  - [Prerequisites](#prerequisites)
  - [Setup](#setup)
    - [Setup With Bat files (Windows Only)](#setup-with-bat-files-windows-only)
    - [Setup With Visual Studio Code](#setup-with-visual-studio-code)
  - [Run](#run)
    - [Run With Bat files (Only Windows)](#run-with-bat-files-only-windows)
    - [Run With Visual Studio Code](#run-with-visual-studio-code)


## Prerequisites

- .NET Core SDK 7 or later

## Setup

Note: We recommend use this app in Windows. You should setup SSL-Dev certificate manually. Please check the link [link](https://aka.ms/dev-certs-trust).

### Setup With Bat files (Windows Only)

1. Clone the repository
2. Open project directory
3. Open `BuildApplication.dat` file 

### Setup With Visual Studio Code

1. Clone the repository
2. Open VS Code in project directory
3. Create Terminal
4. Run these codes

```bash
cd ClientApplication
dotnet build
dotnet add package Blazorise.Material --version 1.2.0
dotnet add package Blazorise.Icons.Material --version 1.2.0
dotnet add package Blazorise.DataGrid --version 1.2.0
dotnet add package Blazorise.Components --version 1.2.0
cd ../ServerApplication
dotnet build
dotnet dev-certs https --trust
```

## Run

### Run With Bat files (Only Windows)

1. Open project directory
2. Open `RunServerApplication.dat` file 
3. Open `RunClientApplication.bat` file

### Run With Visual Studio Code

1. Open VS Code in project directory
2. Create 2 Terminal
3. Select first terminal and run these codes

```bash
cd ServerApplication
dotnet build
dotnet watch
```

4. Select second terminal and run these codes

```bash
cd ClientApplication
dotnet build
dotnet watch
```
