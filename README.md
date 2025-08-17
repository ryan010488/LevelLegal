# LevelLegal
.Net 8 Blazor Server, MSSQL

Softwares required:

1. Microsoft Visual Studio
2. Microsoft SQL Server/SSMS


Steps to run the project:

1. Clone the project to your local from this repository.
2. Open appsettings.json in UI\LevelLegal.UI.Main project.
3. In the section ConnectionStrings > LevelLegalDataAccess, update the Server and Database value base on your local/remote.
4. Open Package Manager Console tab, you can find in Tools > Nuget Package Manager.
5. Ensure selected Default project is Domain\LevelLegal.Domain.Entities.
6. Ensure selected Startup project is UI\LevelLegal.UI.Main.
7. Type "Update-Database" and enter so that the database will be create in sql server.
8. Run the project by pressing F5.
