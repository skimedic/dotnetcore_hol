dotnet new globaljson --sdk-version 3.1.100

rem create the solution
dotnet new sln -n SpyStore.Hol
rem create the ASP.NET Core Web App project and add it to the solution
dotnet new mvc -n SpyStore.Hol.Mvc -au none --no-https  -o .\SpyStore.Hol.Mvc
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Mvc
rem create the Data Access Layer class library, and add to the solution
dotnet new classlib -n SpyStore.Hol.Dal -o .\SpyStore.Hol.Dal -f netcoreapp3.1
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Dal
rem create the class library for the Models and add it to the solution
dotnet new classlib -n SpyStore.Hol.Models -o .\SpyStore.Hol.Models -f netcoreapp3.1
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Models
rem create the Data Access Layer XUnit project and add it to the solution
dotnet new xunit -n SpyStore.Hol.Dal.Tests -o .\SpyStore.Hol.Dal.Tests
dotnet sln SpyStore.Hol.sln add SpyStore.Hol.Dal.Tests

dotnet add SpyStore.Hol.Mvc reference SpyStore.Hol.Models
dotnet add SpyStore.Hol.Mvc reference SpyStore.Hol.Dal

dotnet add SpyStore.Hol.Dal reference SpyStore.Hol.Models

dotnet add SpyStore.Hol.Dal.tests reference SpyStore.Hol.Models
dotnet add SpyStore.Hol.Dal.tests reference SpyStore.Hol.Dal

dotnet add SpyStore.Hol.Mvc package AutoMapper -v 9.0.0
dotnet add SpyStore.Hol.Mvc package LigerShark.WebOptimizer.Core -v 3.0.250
dotnet add SpyStore.Hol.Mvc package Microsoft.Web.LibraryManager.Build -v 2.0.96
dotnet add SpyStore.Hol.Mvc package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1

dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1 
dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.Design -v 3.1.1
dotnet add SpyStore.Hol.Dal package System.Text.Json -v 4.7.1
dotnet add SpyStore.Hol.Dal package Microsoft.EntityFrameworkCore.Tools -v 3.1.1

dotnet add SpyStore.Hol.Models package Microsoft.EntityFrameworkCore.Abstractions -v 3.1.1
dotnet add SpyStore.Hol.Models package AutoMapper -v 9.0.0
dotnet add SpyStore.Hol.Models package System.Text.Json -v 4.7.1

dotnet add SpyStore.Hol.Dal.Tests package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.1



