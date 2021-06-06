# ServiceBasedBookingsManagementApp

## A sample application to manage clients and service-based bookings
>#### It includes possibility to manage company resources such as:
* Employees
* Clients
* Bookings
* Employee Work Schedule
* Services
* Categories (of Services)

### Technologies
>### Back End
* .NET 5
* C# Language
* PostgreSQL
* Entity Framework Core 5
* Swagger
    
>### Front End
* Angular 10
* TypeScript
* Angular Material Design
* Angular Calendar
* NGXS
* RxJs

### Architecture
> This application has been written using the CQRS (Command Query Responsibility Segregation) pattern (without a Mediator).<br/>
All commands and queries have the `ExecuteAsync` method. The `BaseControler` class is responsible for getting Commands/Queries from the DI Container using the almighty `HttpContext` class. <br/>
Each command is wrapped into a transaction handled by the unit of work of type `IUnitOfWork` that performs some audit also.

***
NB: This app has been developed just for a training and practical purpose.
