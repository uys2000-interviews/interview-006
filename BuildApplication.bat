cd ClientApplication
dotnet build
dotnet add package Blazorise.Material --version 1.2.0
dotnet add package Blazorise.Icons.Material --version 1.2.0
dotnet add package Blazorise.DataGrid --version 1.2.0
dotnet add package Blazorise.Components --version 1.2.0
cd ../ServerApplication
dotnet build
dotnet dev-certs https --trust