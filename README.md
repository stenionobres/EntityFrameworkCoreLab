# Entity Framework Core Lab

Read this documentation in other languages: [Portuguese (pt-BR)](README-pt-BR.md)

Application created with the main objective of exploring the features and characteristics of the Entity Framework Core.

In this application, several real usage scenarios were tested based on an ecommerce mini data model.

After the case studies, the main conclusions were documented in this file and serve as a reference for use and source of consultation.

**Used Packages:**

>Net Core 3.1

>[Entity Framework Core 3.1.2](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/3.1.2)

>[Entity.Framework.Core.Sql.Server 3.1.2](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.2)

>[Microsoft.EntityFrameworkCore.Tools 3.1.2](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.2)

>[EFCore.BulkExtensions 3.1.1](https://www.nuget.org/packages/EFCore.BulkExtensions/3.1.1)

>[Microsoft.Extensions.Logging.Console 3.1.2](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console/3.1.2)

>[Faker.Net 1.3.77](https://www.nuget.org/packages/Faker.Net/1.3.77)

>[NBuilder 6.1.0](https://www.nuget.org/packages/NBuilder/6.1.0)

## Prerequisites

What needs to be installed on the machine to extend and debug the project:

    Visual Studio Community 2019;
    Net Core SDK 3.1;
    SQL Server

## Getting Started

* Install and/or configure all the prerequisites mentioned above;
* Clone the repository on the local machine;
* Create the three databases used in the application: AmazonCodeFirst, EbayDatabaseFirst and Experiments;
* Download Nuget dependencies for the solution in Visual Studio;
* Run the migrations to the desired database with the command: Update-Database -Context [ClassName of context];
* Execute the calling of some class from the [Process](./EntityFrameworkCoreLab.Application/Process) namespace in the Program.cs file;

## Project Requirements

In order to experience the features of the Entity Framework Core and establish the best and most efficient usage practices, some requirements have been established.

These requirements aim to bring the case study closer to a real use scenario where several characteristics of the framework must be explored.

Below are listed which requirements the solution meets:

    Use of multiple databases;
    Use of multiple schemas;
    Use Model First and Database First;
    To consider 1 x 1 relationship between tables;
    To consider 1 x N relationship between tables;
    To consider N X N relationship between tables;
    Better use of DataAnnotations;
    Behavior of Inserts;
    Behavior of Updates;
    Behavior of Deletes;
    Use of transactions;
    Use of views;
    Database seed using migrations;
    Entities that do not use an auto-incremental key;
    Evaluate and optimize performance for operations with large data volumes;
    Querys log and data audit;

## Database Model

## Project Structure

### EntityFrameworkCoreLab.Application

### EntityFrameworkCoreLab.Persistence

## Model First x Database First

### Fields table

## Migration Strategies

### Criteria for generating migrations

### ModelSnapshot File

### Main commands when using migrations

### Database Seeding

## Relationships Strategies

### One to One (1 x 1)

### One to Many (1 x N)

### Many to Many (N x N)

## Inserts, updates and deletes considerations

### EF Core Entity State

## Insert and update use examples

The class [DisconnectedOperationProcess](./EntityFrameworkCoreLab.Application/Process/DisconnectedOperationProcess.cs) and its dependencies present examples of how to perform inserts and updates on entities with 1 x 1, 1 x N and N x N relationships.

The operations are carried out in a `disconnected` way, that is, the entities have not yet been tracked by DbContext. The [FullPopulateDatabaseDataProcess](./EntityFrameworkCoreLab.Application/Process/FullPopulateDatabaseDataProcess.cs) class also provides a good example of how to insert data into entities.

## Performance considerations

### INSERT

### UPDATE

### DELETE

### Considerations about data

## Considerations about selects

### Eager loading

### Explicit loading

### Lazy loading

### Select loading

### Which strategy to use?

### Raw SQL in querys

### Query examples

## Transactions

## Views

## Logging

## Data Audity

## Fast tips

### Indexes

**Create an index**
    
    modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp); 

**Create index with multiple fields**

    modelBuilder.Entity<MyEntity>().HasIndex(p => new {p.MyProp01, p.MyProp02}); 

**Create named index**

    modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp).HasName("Index_MyProp");

**Create unique index (unique key)**

    modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp).IsUnique();

### Schemas and Tables

### Primary keys

### Raw SQL

### Organize Fluent API in DbContext

## Lessons learned

## References used

* [Entity Framework Core Official documentation](https://docs.microsoft.com/en-us/ef/core/index)
* [Entity Framework Core in Action book](https://livebook.manning.com/book/entity-framework-core-in-action/about-this-book/)
* [Entity Framework Core Tutorial](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
* [Learn Entity Framework Core](https://www.learnentityframeworkcore.com/)
* [Blog of Entity Framework Core in Action Author - John P Smith](https://www.thereformedprogrammer.net/)
* [Blog of Engineering Manager for Entity Framework - Arthur Vickers](https://blog.oneunicorn.com/)
* [Entity Framework Core Specialist - Julie Lerman](http://thedatafarm.com/)
* [Pluralsight - Entity Framework Core Path](https://www.pluralsight.com/paths/entity-framework-core)
* [Pluralsight - Entity Framework Core in the Enterprise](https://app.pluralsight.com/library/courses/entity-framework-enterprise-update/table-of-contents)

## Authors

* **Stenio Nobres** - [Github](https://github.com/stenionobres)