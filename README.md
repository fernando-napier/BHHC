# BHHC

This is a sample .NET Core web application using Razor pages for the UI. The 3 libraries used to separate the logical layers of the application are .NET Standard. This is a C# heavy project where all of the packages are within one solution. This was a fun little exercise in writing an MVC style application.

Technology used:

.Net Core, EF Core, Razor Pages, Xunit, FakeItEasy, AutoBogus, Sqlite, PostgreSQL, HTML, 3-tier Architecture

## Get Started

1) Clone the repo
2) open the solution in Visual Studio
3) Run the application

### Quirky note
The sqlite database lives within the BHHC.App project, I would have liked to have a remote server to connect to rather than one within the application. Obviously in a situation where setup wouldn't take too long I'd list out instructions about creating a local PostgreSQL instance and running that through localhost so the connection strings look nice but the sqlite implementation does the job.
