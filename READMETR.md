# Mehmet Uysal Razor + Blazor Uygulaması

## İçerik

- [Mehmet Uysal Razor + Blazor Uygulaması](#mehmet-uysal-razor--blazor-uygulaması)
  - [İçerik](#i̇çerik)
  - [Gereklilikler](#gereklilikler)
  - [Kurulum](#kurulum)
    - [Bat Dosyaları İle Kurulum (Yalnızca Windows'da)](#bat-dosyaları-i̇le-kurulum-yalnızca-windowsda)
    - [Visual Studio Code İle Kurulum](#visual-studio-code-i̇le-kurulum)
  - [Çalıştır](#çalıştır)
    - [Bat Dosyaları İle Çalıştır (Yalnızca Windows'da)](#bat-dosyaları-i̇le-çalıştır-yalnızca-windowsda)
    - [Visual Studio Code İle Çalıştır](#visual-studio-code-i̇le-çalıştır)


## Gereklilikler

- .NET Core SDK 7 veya sonraki sürümler

## Kurulum

Not: Uyhulamayı Windowsda çalıştımanızı tavsiye ederiz. Linux'de SSL sertifilasını manual olarak kurmanız gerekmektedir. Lütfen ilgili [link](https://aka.ms/dev-certs-trust)i kontrol ediniz.


### Bat Dosyaları İle Kurulum (Yalnızca Windows'da)

1. Repoyu yükleyin
2. Proje klasörünü açın
3. `BuildApplication.dat` dosyasını çalıştırın

### Visual Studio Code İle Kurulum

1. Repoyu yükleyin
2. VS Code'u proje klasöründe açın
3. Terminal oluşturun
4. Aşağıda ki kodları çalıştırın

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

## Çalıştır

### Bat Dosyaları İle Çalıştır (Yalnızca Windows'da)

1. Proje klasörünü açın
2. `RunServerApplication.dat` dosyasını çalıştırın 
3. `RunClientApplication.bat` dosyasını çalıştırın

### Visual Studio Code İle Çalıştır

1. VS Code'u proje klasöründe açın
2. 2 adet terminal oluşturun
3. İlk terminali seçip aşağıdaki kodları çalıştırın

```bash
cd ServerApplication
dotnet build
dotnet watch
```

4. İkinci terminali seçip aşağıdaki kodları çalıştırın

```bash
cd ClientApplication
dotnet build
dotnet watch
```