# DarkoDemo

## Prerequisites

Before running the project, ensure you have the following installed:

- **Visual Studio 2022** with the following workloads:
  - ASP.NET and web development
  - Azure Development
  - .NET Multi-platform App UI development
- **LocalDB**

## Steps to Run

1. Open the solution
2. Set the **Startup Project** to: DarkoDemo.AppHost
3. Click **Run** (F5) to start the application.
4. To start the mobile app (Windows) - right click on DarkoDemo project and Debug->Start New Instance
    - Other platforms are not setup at the moment

## Migrations 
Example commands
- Add-Migration InitialCreate -Project DarkoDemo.DataServices -StartupProject DarkoDemo.Api

- Update-Database -Project DarkoDemo.DataServices -StartupProject DarkoDemo.Api

