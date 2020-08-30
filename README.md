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

In order to exemplify the use of the Entity Framework, a mini **database model was created that has 1 x 1, 1 x N and N x N** relationships. This model is geared towards ecommerce and is mainly based on `Customers` who live in certain `Addresses`, these customers in turn buy several `Products` and the products have related `Delivery Rates`.

Below is a **conceptual modeling** of the database. The modeling was done with the support of the tool [BrModelo](http://www.sis4.com/brModelo/).

![image info](./readme-pictures/ecommerce-conceitual.png)

In this diagram, **logical modeling** of the database is presented. The modeling was done with the support of the tool [SqlDBM](https://sqldbm.com/). It is important to note that the tables have been divided into two schemes: `common` and `sales`.

![image info](./readme-pictures/ecommerce-logical.jpg)

## Project Structure

The solution `EntityFrameworkCoreLab` is divided into two projects: `EntityFrameworkCoreLab.Application` and `EntityFrameworkCoreLab.Persistence`. Below each of the projects are detailed.

### EntityFrameworkCoreLab.Application

It is a `.Net Core Console Application` that has the responsibility of being the entry point for executing and debugging the classes developed in the solution. To perform the execution, the classes in the **Process** namespace must be instantiated and the methods executed in the **Program.cs** class.

![image info](./readme-pictures/entityframeworkcorelab-application.jpg)

The main namespaces are `Data Factory` and `Process`.

* **Data Factory**: classes that have the responsibility **to create fakes objects** to make some operations in the databases feasible. These objects are created with the support of the extensions NBuilder and Faker.Net.

* **Process**: classes that manage calls to the `EntityFrameworkCoreLab.Persistence` project, which in turn accesses the databases. Each class has a set of operations that seek to evaluate a specific scope of actions in EF Core.

### EntityFrameworkCoreLab.Persistence

It is a `.Net Core Class Library` which has the responsibility to maintain the EF Core configurations and carry out the operations in the databases.

![image info](./readme-pictures/entityframeworkcorelab-persistence.jpg)

The main namespaces are: `DataTransferObjects`, `EntityFrameworkContexts`, `EntityTypeConfigurations`, `Log`, `Mappers` and `Migrations`.

* **DataTransferObjects**: classes that represent the models that map the tables in each database.

* **EntityFrameworkContexts**: classes that configure access to databases. In this case study, three databases were used.

* **EntityTypeConfigurations**: classes that aim to modularize the code of configurations made for each model in DbContexts.

* **Log**: classes developed to write EF Core logs to file.

* **Mappers**: classes that perform CRUD operations on databases.

* **Migrations**: classes that represent the migrations that will be applied in each database.

## Model First x Database First

The two main strategies for manipulating, updating and creating database schema using EF Core are: `Model First and Database First`.

The strategy that the author recommends to be used is the **Model First**, however in some situations it is necessary to work with a database already defined, with a physical model already created. In this scenario, EF Core allows the **Database First** strategy to be used to use the database.

Based on this it is important that the three data model configuration strategies provided by EF Core are explained:

* **By Convention**: simple rules adopted in the types and names of properties for configuring the database schema. It does not meet all configuration scenarios;
* **Data annotation**: a set of annotations that can be used in the entity classes and properties for configuration;
* **Fluent API**: can be used when overriding the `OnModelCreating` method of the class that extends the `DbContext`. This is the most powerful and flexible way to configure the data model, however the configuration can become more complex and generate much boilerplate code.

A problem observed with the `Database First` strategy is that it creates a lot of unnecessary code or `boilerplate code`, leaving the data model created in the application more complex and often difficult to understand.

With that in mind, based on the tests and experiments carried out in the project, a way of working with existing tables was established using all the power of the **Model First** strategy.

>If the table already exists in the database, it is possible to create the `Model` based on the database structure. After the creation of this model the migration is generated normally, but its application in the database is not done. To avoid any error, an `Insert` is done in the `__EFMigrationsHistory` table with the name of the migration file and EF Core version. In this way, the Database First strategy's boilerplate code is avoided. `But, how to translate the fields from the SqlServer to C# types?` **Answer**: using the field table below.

### Fields table

This table represents the types of C# fields for the types of fields in the SqlServer. Field sizes are useful to establish the most appropriate type and configuration for each situation, in order to make a physical design of the most suitable database.

With this table it is possible to create models for tables that already exist in the database in order to avoid the boilerplate code of the Database First strategy.

The table leads us to two **important conclusions**: all **numeric types are generated as not null** in SqlServer and **string fields are generated as null**.

It is possible to check the way the table was generated by consulting the model code [DTODataType](./EntityFrameworkCoreLab.Persistence/DataTransferObjects/Experiments/DTODataType.cs).

[Migration](./EntityFrameworkCoreLab.Persistence/Migrations/Experiments/20200307214738_CreateDTODataType.cs) file that generated the table in the database from the model.

| **C# Type** |     **DataAnnotation**            |   **SqlServer Type**   | **SqlServer Lenght**  |
|:-----------:|:---------------------------------:|:----------------------:|:---------------------:|
|     int     |          -                        |  int not null          |       4 bytes         |
|     int?    |          -                        |     int null           |       4 bytes         |
|    string   |          -                        | nvarchar(max) null     |         2GB*          |
|    string   |        MaxLength(50)              |  nvarchar(50) null     |      100 bytes*       |
|    string   |         Required                  | nvarchar(max) not null |         2GB*          |
|   DateTime  | Column(TypeName = "date")         |   date not null        |       3 bytes         |
|   DateTime? | Column(TypeName = "date")         |     date null          |       3 bytes         |
|   DateTime  |           -                       | datetime2(7) not null  |       8 bytes**       |
|   DateTime? |           -                       |  datetime2(7) null     |       8 bytes**       |
|   TimeSpan  |           -                       |   time(7) not null     |       5 bytes***      |
|   TimeSpan? |           -                       |     time(7) null       |       5 bytes***      |
|    float    |           -                       |   real not null        |       4 bytes         |
|    float?   |           -                       |      real null         |       4 bytes         |
|   double    |           -                       |    float not null      |       8 bytes         |
|   double?   |           -                       |      float null        |       8 bytes         |
|     long    |           -                       |    bigint not null     |       8 bytes         |
|     long?   |           -                       |      bigint null       |       8 bytes         |
|   decimal   |           -                       | decimal(18,2) not null |       9 bytes         |
|   decimal   | Column(TypeName = "decimal(6,2)") |  decimal(6,2) not null |       5 bytes         |
|   decimal?  |           -                       |   decimal(18,2) null   |       9 bytes         |
|    bool     |           -                       |   bit not null         |       2 bytes         |
|    bool?    |           -                       |       bit null         |       2 bytes         |
|    char     |           -                       | nvarchar(1) not null   |       2 bytes         |
|    char?    |           -                       |    nvarchar(1) null    |       2 bytes         |
|    byte[]   |           -                       |   varbinary(max) null  |         2GB*          |

*Maximum value that varies according to the content of the field.

**6 bytes for accuracy less than 3, 7 bytes for accuracy between 3 and 4. All other precision needs 8 bytes.

***3 bytes for accuracy less than 3, 4 bytes for accuracy between 3 and 4. All other precision needs 5 bytes.

## Migration Strategies

This section describes the characteristics of the commands to make use of migrations and how they can best be used.

Migrations can be used in either the **Model First** or **Database First** strategy.

The commands listed are in the format used in the **Package Manager Console**. It is necessary that the project has the dependency `Microsoft.EntityFrameworkCore.Tools` as described in the section [Project Structure](#project-structure).

### Criteria for generating migrations

EF Core establishes some criteria for generating migrations, which consequently generate changes in the database. The execution of commands to generate migrations will always compile the **Target project** and **Startup project**. The criteria are:

* Change in the properties of the entity classes, for example, the name of the property or inclusion of a new property;

* Changing the EF Core settings, for example, changing the configuration of some relationship between tables;

* Change in **DbSet** properties in some **DbContext** of the application. This change can be changing the name of that property or adding a new property.

>For migration purposes, the EF Core data model configuration strategies have **order of precedence** when generating changes to the database. Following, the strategies are cited in order of precedence, from lowest to highest: **By Convention, Data Annotation and Fluent API**. Based on this it is correct to state that the same configuration made via Fluent API or Data Annotation, the configuration that was done via Fluent API will be used when generating the migration.

### ModelSnapshot File

Migrations create a **snapshot** of the current database schema in the `Migrations/<DbContextName>ModelSnapshot.cs` file. When a migration is added, EF Core determines which changes will be applied by comparing the data model with the snapshot file.

### Main commands when using migrations

    Add-Migration <MigrationName> -Context <ClassName of context>

The above command generates a file in the `Migrations` folder with the naming pattern `utc_datetime_<MigrationName>.cs`, where `utc_datetime` is a timestamp generated with the hour, minute and seconds based on Coordinated Universal Time (UTC).

Updates the `ModelSnapshot` file in the `Migrations` folder with the difference between the data model and the ModelSnapshot file.

You cannot use a `<MigrationName>` that has already been used in another file, even if you change the ModelSnapshot.

If the entire data model is already listed in the `ModelSnapshot` file, a migration file will be created with **empty Up and Down methods**.

It is possible to execute pure sql in the migration file by calling `migrationBuilder.Sql()` within the Up or Down method.

When creating a migration, the contents of the `design` file from the previous migration are added to the design file in the new migration.

    Add-Migration <MigrationName> -Context <ClassName of context> -OutputDir <Migration folder> 

The above command creates a migration with the flexibility to enter the context name and directory of migrations. Very useful for the scenario of using various contexts and custom migration directories.

    Remove-Migration -Context <ClassName of context>

The above command removes the migration file generated by the `Add-Migration` command. The file removed will be the one with the largest timestamp that has not yet been applied to the database and/or is not in the `__EFMigrationsHistory` table. The ModelSnapshot file is also updated.

The removed migration files are inserted into the project's `.csproj file`.

    Update-Database -Context <ClassName of context>

Apply all migration files, from the smallest to the largest timestamp, which do not yet exist in the `__EFMigrationsHistory` table.

    Update-Database -Migration <MigrationName> -Context <ClassName of context>

Apply the instructions contained in the migration design file passed in the parameter to the database. This occurs only if the migration-related design file, mentioned in the parameter, does not yet exist in the `__EFMigrationsHistory` table.

It is important to note that every file **migration design** has the design code of all other migrations of smaller timestamp. This makes it possible for previous changes to be applied if the name of the files from previous migrations does not already exist in the `__EFMigrationsHistory` table.

This command also performs the **call of the Down method** of finished migration. For this to occur, it must be executed with the name of a previous migration to which the Down method is to be executed. All migrations with a timestamp greater than the migration mentioned in the parameter will have their Down methods executed from the largest to the smallest timestamp.

    Update-Database -Context <ClassName of context> -Migration 0

Reverses all changes, from the largest to the smallest timestamp, applied to the database made by migrations. Does not alter the `ModelSnapshot` file.

    Script-Migration -From 0

Generates the sql script of all migration files regardless of whether or not they are in the ` __EFMigrationsHistory` table.

    Script-Migration -From <MigrationName> -To <MigrationName>

Generates the sql script for a given migration file regardless of whether it is in the `__EFMigrationsHistory` table.

    Script-Migration -Idempotent -Context <ClassName of context>

Generates the sql script for all existing migrations **with the benefit** that the generated sql script **verifies that the changes for each migration have already been applied to the database**. It is highly recommended to use this strategy to **apply changes to the production database** in order to avoid possible errors and inconsistencies that may occur during the application of migrations.

### Database Seeding

In the migration file [DatabaseSeeding](./EntityFrameworkCoreLab.Persistence/Migrations/Amazon/20200404115959_DatabaseSeeding.cs) an example of loading into the database is presented through the use of migration. Both `Insert, Update and Delete` operations are presented.

## Relationships Strategies

This section discusses the ways that relationships between tables can be made using EF Core. For this, the strategies can be used: `By Convention, Data annotation and Fluent API`.

The way these relationships can be made is implemented in the namespace `Experiments` of the project `EntityFrameworkCoreLab.Persistence`. Below is an image with the namespaces highlighted:

![image info](./readme-pictures/relationship-experiments.jpg)

To better understand how relationships are carried out it is necessary to describe the types of participating entities: `Principal Entity, Middle Entity and Dependent Entity`.

* **Principal Entity**: Contains the key property on which the Dependent Entity refers via a foreign key.
* **Middle Entity**: Entity that associates the Principal Entity and Dependent Entity in an N to N relationship.
* **Dependent Entity**: Contains the foreign key property that references the Principal Entity.

The entities are specified in the folders: `ManyToManyRelation, OneToManyRelation and OneToOneRelation`. The names of the entities follow the following nomenclature rule:

    <Entity type><relationship strategy><relationship type abbreviation>.cs

**Entity type**: Principal Entity, Middle Entity and Dependent Entity;

**Relationship strategy**: By Convention, Data annotation and Fluent API;

**Abbreviation for relationship type**: OTO (one to one), OTM (one to many), MTM (many to many).

**Example entity name:** `PrincipalEntityByConventionOTM.cs`

>The author's experience in creating and developing this project shows that the best strategy for creating relationships between entities is **By Convention**. The project becomes simpler and more intuitive to understand.

Below are some important characteristics of each type of relationship.

### One to One (1 x 1)

By default, EF Core creates a field that can assume **null values** in the database. This field is a foreign key for the dependent table and assumes the exclusion pattern `ReferentialAction.Restrict`. If `DataAnnotation [Required]` is inserted, it assumes the `ReferentialAction.Cascade` exclusion pattern.

It can be done in two ways:

1 - A property in the main class referencing the dependent class with a property in the dependent class that represents the key of the main;

2 - The reverse. A property in the main class that represents the dependent key with a property in the dependent class referencing the main class;

### One to Many (1 x N)

If the id of the main entity does not exist in the dependent entity, EF Core inserts it as `shadow property`. It is recommended to insert the id property that references the main entity for the sake of clarity in the data model.

### Many to Many (N x N)

By default, EF Core does not define the two foreign keys in the associative table as a composite primary key. An extra key must be added or a configuration used to define both fields as a key. Example:

``` C#
modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
```

It is not necessary to include the class that represents the associative table in DbSet for it to be created in the database.

## Inserts, updates and deletes considerations

### EF Core Entity State

A brief explanation of the EF Core Entity State aims to help understand what happens when entities are added, updated or deleted from the database.

When an entity is read it is `tracked` by default by EF Core, this is known as a `tracked entity`.

> Tracked entities: are instances of entities that were read from the database using a query that does not include the **AsNoTracking** method. Alternatively after an entity is used in an EF Core method (Add, Update or Delete) the entity is tracked.

All tracked entities have a property called `State`. The State of an entity can be obtained using the following command:

    context.Entry(someEntityInstance).State

Where `context` is the instance of the DbContext class used.

Below is a list of possible States and what happens when the `SaveChanges` method is executed:

* Added - The entity does not exist in the database. SaveChanges inserts it.
* Unchanged - The entity exists in the database and has not been modified on the client. SaveChanges ignores it.
* Modified - The entity exists in the database and has been modified on the client. SaveChanges updates it.
* Deleted - The entity exists in the database and has been deleted. SaveChanges the delete.
* Detached - The entity is not "tracked". SaveChanges ignores it.

Normally the `State` is not changed directly, for that, several EF Core commands are used to ensure that everything will be changed correctly.

The classes [AmazonCustomerInsertLabMapper](./EntityFrameworkCoreLab.Persistence/Mappers/Amazon/AmazonCustomerInsertLabMapper.cs), [AmazonCustomerUpdateLabMapper](./EntityFrameworkCoreLab.Persistence/Mappers/Amazon/AmazonCustomerUpdateLabMapper.cs) and [AmazonCustomerDeleteLabMapper](./EntityFrameworkCoreLab.Persistence/Mappers/Amazon/AmazonCustomerDeleteLabMapper.cs) present examples of how the different states of the `State` property influence the operations sent to the database by DbContext. For better interpretation it is necessary to pay attention to the comments inserted in the code.

> It is highly recommended that the **State** property is not changed directly via code in real applications.

## Insert and update use examples

The class [DisconnectedOperationProcess](./EntityFrameworkCoreLab.Application/Process/DisconnectedOperationProcess.cs) and its dependencies present examples of how to perform inserts and updates on entities with 1 x 1, 1 x N and N x N relationships.

The operations are carried out in a `disconnected` way, that is, the entities have not yet been tracked by DbContext. The [FullPopulateDatabaseDataProcess](./EntityFrameworkCoreLab.Application/Process/FullPopulateDatabaseDataProcess.cs) class also provides a good example of how to insert data into entities.

## Performance considerations

The purpose of this session is mainly to explore the various possibilities of data manipulation using EF Core in terms of performance.

It is important to evaluate the data collected from the point of view of `order of magnitude`, that is, if strategy A needs 10ms and strategy B needs 1ms to do the same operation, then strategy B is more efficient. However, it does not mean that strategy B will run at the same time on different hardware.

With that in mind, don't take the time spent on each strategy so much into consideration, but **how often it is more efficient** compared to the others.

Evaluations were made for the Insert, Update and Delete operations. For the tests the following forms of execution were used:

* **Add**: evaluated the method that is part of both DbSet and DbContext;
* **AddRange**: evaluated the method that is part of both DbSet and DbContext;
* **ExecuteSql**: Use of pure SQL through DbContext;
* **Bulk Operation**: Use of Bulk operations on SQL Server through DbContext and the **EFCore.BulkExtensions** extension.

The operations that are described as `with Recycle` mean that the DbContext instance has been recreated for each database call.

For testing purposes **15,000 addresses** were created using the **NBuilder** and **Faker.Net** extensions.

The data below are presented in **Milliseconds per record**.

### INSERT

To consult the code used, check the class [PerformanceInsertLabProcess](./EntityFrameworkCoreLab.Application/Process/PerformanceInsertLabProcess.cs).

| **INSERT BENCHMARK**             |  DbSet  | DbContext |
| -------------------------------- |:-------:|:---------:|
| **Add**                          | 11,63*  |  10,51*   |
| **Add with Recycle**             |  9,56   |  12,11    |
| **AddRange**                     |  0,25   |   0,24    |
| **AddRange with Recycle**        |  0,25   |   0,23    |
| **ExecuteSql**                   |    -    |   5,13    |
| **ExecuteSql with Recycle**      |    -    |   7,67    |
| **Bulk Operation**               |    -    |   0,02    |

*With the use of the same instance of DbContext and successive calls to `SaveChanges` the time spent per registration increases with the increase in operations.

### UPDATE

To consult the code used, check the class [PerformanceUpdateLabProcess](./EntityFrameworkCoreLab.Application/Process/PerformanceUpdateLabProcess.cs).

| **UPDATE BENCHMARK**             |  DbSet  | DbContext |
| -------------------------------- |:-------:|:---------:|
| **Add**                          |  9,06*  |  13,27*   |
| **Add with Recycle**             |  9,23   |  10,00    |
| **AddRange**                     |  0,23   |   0,23    |
| **AddRange with Recycle**        |  0,24   |   0,22    |
| **ExecuteSql**                   |    -    |   6,11    |
| **ExecuteSql with Recycle**      |    -    |   5,57    |
| **Bulk Operation**               |    -    |   0,03    |

*With the use of the same instance of DbContext and successive calls to `SaveChanges` the time spent per registration increases with the increase in operations.

### DELETE

To consult the code used, check the class [PerformanceDeleteLabProcess](./EntityFrameworkCoreLab.Application/Process/PerformanceDeleteLabProcess.cs).

| **DELETE BENCHMARK**             |  DbSet  | DbContext |
| -------------------------------- |:-------:|:---------:|
| **Add**                          | 23,90*  |  29,27*   |
| **Add with Recycle**             | 24,33   |  28,30    |
| **AddRange**                     |  0,20   |   0,21    |
| **AddRange with Recycle**        |  0,17   |   0,16    |
| **ExecuteSql**                   |    -    |   5,43    |
| **ExecuteSql with Recycle**      |    -    |   5,90    |
| **Bulk Operation**               |    -    |   0,03    |

*With the use of the same instance of DbContext and successive calls to `SaveChanges` the time spent per registration increases with the increase in operations.

### Considerations about data

* The code using Bulk Operation is the most efficient. It should be used for large masses of data that need to be processed in a short time;
* Whether or not to recreate the DbContext instance did not change the time spent on operations;
* The use of the call `SaveChanges` should only be made after including all the data in DbContext, EF Core has optimizations so that the data can be processed more quickly.
* Among all strategies, the one using `AddRange` proved to be the strategy with the best cost benefit. It has excellent performance using only native EF Core features.

## Considerations about selects

The Entity Framework Core has **4 strategies for querying information** in the database, they are: **Eager loading, Explicit loading, Select loading and Lazy loading**. By default when querying an entity, related classes or dependencies are not loaded into queries. To load the related classes, it is necessary to point to the EF Core explicitly which dependencies must be selected. Below is a brief summary of each strategy for querying data in EF Core.

### Eager loading

Load the related entity in the same query as the main class. The relationship in the SQL query is usually expressed using the `LEFT JOIN` command. This strategy uses two fluent methods: `Include and ThenInclude`. In some scenarios, EF Core can translate commands into more than one query in the database. Example:

``` C#
var book = context.Books.Include(r => r.AuthorsLink).ThenInclude(r => r.Author);
```

### Explicit loading

This strategy is characterized by the search for related entities after loading the main entity. It is useful when you are not sure which relationships you want to load in advance. The disadvantage is that several calls are made to the database. Example:

``` C#
var book = context.Books.First();          
context.Entry(book).Collection(c => c.AuthorsLink).Load();
```

### Lazy loading

Load data and relationships only when they are really needed. In practice, it has already proved to be a strategy with serious disadvantages if it is misused. To use it, you need a set of [settings](https://docs.microsoft.com/en-US/ef/core/querying/related-data) that must be made in the application. Several authors do not recommend its use.

### Select loading

Technique named by **John P Smith** in his book [Entity Framework Core in Action](https://livebook.manning.com/book/entity-framework-core-in-action/about-this-book/), consists of using LINQ to build the queries. Its great advantage is the flexibility in obtaining the data.

The disadvantage in its use is that the developer needs to pay attention and care in the construction of the query so that the code is not too complex and so that EF Core is able to translate all commands into SQL with good performance. This can be tracked through the query log generated by EF Core. Example:

``` C#
var result = context.Books.Select(p => new {p.Title, p.Price, NumReviews = p.Reviews.Count}).First();
```

### Which strategy to use?

After reading chapter 2 of the book **Entity Framework Core in Action** and developing some queries in the [data model](#database-model) defined for this case study, it can be said that the [Select loading](#select-loading) strategy is more effective for building queries using EF Core. This is due to the fact that this strategy has good flexibility and performance. Throughout this documentation, examples of building queries using this strategy will be presented.

### Raw SQL in querys

It is possible to run queries with raw SQL using EF Core. For this, the `FromSqlInterpolated` method must be used. This method with the use of string interpolation already adds parameters to the query in order to avoid SQL Injection failures. Example:

``` C#
var searchTerm = ".NET";

var blogs = context.Blogs.FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
                         .AsNoTracking()
                         .ToList();
``` 

The use of raw SQL with this strategy has the following limitations:

* The SQL query must return data for all properties of the entity;
* The names of the columns in the result set must match the names of the columns to which the properties are mapped;
* It is only possible to list other tables using the `Include` method;

Another alternative for using raw SQL is to use the `GetDbConnection` method to obtain the connection to the database and use the api offered by ADO.NET. Example:

``` C#
using (conn = context.Database.GetDbConnection())
{
    try
    {
        conn.Open();
        using (var command = conn.CreateCommand())
        {
            command.CommandText = "select * from dbo.Books";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                }
            }
        }
    }
    catch (Exception ex)
    {

    }
    finally
    {
        conn.Close();
    }
}
``` 

### Query examples

In the previous sessions, the various strategies for performing queries on the Entity Framework Core were presented. One of them is `Select loading` which uses LINQ to bring information from the database.

Beginner programmers to EF Core or LINQ may find it difficult to develop such queries, since the syntax is slightly different from the standard SQL they are used to. With this in mind, this session provides several examples of queries, made with LINQ, which generate the SQL expected and optimized for each type of action in the database.

To see the examples of queries just access the class [LinqQueryExampleProcess](./EntityFrameworkCoreLab.Application/Process/LinqQueryExampleProcess.cs). Below are listed which SQL operations the examples use:

* INNER JOIN;
* LEFT JOIN;
* WHERE Filter;
* Relational Operators >, =, etc;
* Logical Operators AND, OR, etc;
* IN Filter;
* NOT IN Filter;
* LIKE;
* UNION;
* DISTINCT;
* BETWEEN;
* ORDER BY;
* GROUP BY;
* HAVING;
* MAX;
* MIN;
* AVG;
* SUM;
* COUNT;

### Query performance

To improve the performance of queries using the Entity Framework Core, it is important to note some aspects that reduce the data mapping execution time. The items shown below serve as points of attention and/or checklist for improving performance in querys:

* Analyze the SQL generated in the EF Core [log](#logging). The goal is to search for queries that are performing poorly. Often, some change in the construction of LINQ already improves query performance, if necessary the [query execution plan](https://en.wikipedia.org/wiki/Query_plan) of the database can be used. The [Query examples](#query-examples) section presents several common queries that already have the optimized syntax for execution;

* Review the physical design of the database. Eliminate joins with alphanumeric fields whenever possible, check if it is possible to create or improve indexes in columns;

* Use the **AsNoTracking** extension method after the LINQ developed. This method prevents EF Core from mapping entities to `ChangeTracker`, this reduces the time to map the data. Example:

``` C#
public IEnumerable<Customer> GetCustomersWithAddressExemplifyingOneToOneRelationship()
{
    using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
    {
        var query = from customer in amazonCodeFirstContext.Customer
                    join address in amazonCodeFirstContext.Address
                        on customer.AddressId equals address.Id
                    select new
                    {
                        customer, address
                    };

        var data = query.AsNoTracking().ToList();

        return data.Select(d => d.customer);
    }
}
```

* Assess whether the creation of a **view** that returns the queried data reduces the execution time. Sometimes using the processing power of the database server can be an alternative to improve performance. In the section [Views](#views) it is shown how to use views in EF Core;

* Consider using pure SQL via [ADO.NET](https://docs.microsoft.com/en-US/dotnet/framework/data/adonet/ado-net-code-examples) or [Dapper](https://github.com/StackExchange/Dapper);

## Transactions

By default, EF Core's DbContext class performs database operations within a transaction. Based on this, it is possible to make several calls to the `Add/AddRange, Update/UpdateRange and Remove/RemoveRange` methods of the same DbContext instance that when calling the` SaveChanges` the operations will be executed within a transaction. Based on this, **in most scenarios it is not necessary to use transactions explicitly in EF Core**.

The [TransactionLabProcess](./EntityFrameworkCoreLab.Application/Process/TransactionLabProcess.cs) and [EbayTransactionLabMapper](./EntityFrameworkCoreLab.Persistence/Mappers/Transaction/EbayTransactionLabMapper.cs) class present several examples that evaluate the behavior of transactions in DbContext.

It is important to pay attention to some `comments` in the [TransactionLabProcess](./EntityFrameworkCoreLab.Application/Process/TransactionLabProcess.cs) class that explain the behavior of each evaluated scenario.

To see an example of using the transaction `explicitly` the method` InsertAddressWithAddWithTransactionSaveChangesBefore` of class [EbayTransactionLabMapper](./EntityFrameworkCoreLab.Persistence/Mappers/Transaction/EbayTransactionLabMapper.cs) should be used as an example.

## Views

You can use views in EF Core by following these steps:

1 - The view sql script is created;

2 - The **model** is created to represent the view in the application using this [Table](#table-of-fields)*;

3 - The view creation script is applied directly to the database or through migration;

4 - Performs the inclusion of an entry for the model in the DbContext and the instruction below in the `OnModelCreating` method of the DbContext;

``` C#
modelBuilder.Entity<TEntity>().ToView("ViewName", "schemaName");
```

*The use of the table is optional, however its objective is to approximate as much as possible the types and annotations of the model with the types established in the database.

The [SalesInsightsProcess](./EntityFrameworkCoreLab.Application/Process/SalesInsightsProcess.cs) and [SalesInsights](./EntityFrameworkCoreLab.Persistence/DataTransferObjects/Amazon/SalesInsights.cs) classes and their dependencies present an example of using views. In this example, the view was created directly in the database without using migration.

Below is an example of migration that creates a view:

``` C#
public partial class CreateView : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("create view SomeView as select * from SomeTable");
    }
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("drop view SomeView");
    }
}
```

## Logging

It is possible to use the [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console/3.1.2) extension to capture logs of the operations applied in the database.

This log can be presented either in the console, in the development environment, or recorded in a file for later verification. The main utility of these logs is to identify any errors or eventual queries that have performance problems.

In class [AmazonCodeFirstDbContext](./EntityFrameworkCoreLab.Persistence/EntityFrameworkContexts/AmazonCodeFirstDbContext.cs), an implementation was made to present the log on the console using the `LoggerFactoryToConsole` property.

The implementation of the log in file was done through the `LoggerFactoryToFile` property using classes that extend some interfaces of the Microsoft log package. These classes are in the [Log](./EntityFrameworkCoreLab.Persistence/Log/) namespace.

To use the log in file, just use the call `optionsBuilder.UseLoggerFactory (LoggerFactoryToFile)` in the `OnConfiguring` method of DbContext.

## Data Audity

In some situations, it is necessary to record the creation, update and deletion times of the records manipulated in the database, as well as the user who performed these operations.

In order to avoid duplication of code, the `SaveChanges` method of DbContext [EbayDatabaseFirstDbContext](./EntityFrameworkCoreLab.Persistence/EntityFrameworkContexts/EbayDatabaseFirstDbContext.cs) was overwritten. This overwrite applies the audit data in the database to entities that are of the type [Auditable](./EntityFrameworkCoreLab.Persistence/Auditing/Auditable.cs). An example of an entity that uses auditing is the entity [Customer](./EntityFrameworkCoreLab.Persistence/DataTransferObjects/Ebay/Customer.cs).

## Fast tips

### Indexes

**Create an index**

``` C# 
modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp); 
``` 

**Create index with multiple fields**

``` C#
modelBuilder.Entity<MyEntity>().HasIndex(p => new {p.MyProp01, p.MyProp02}); 
```

**Create named index**

``` C#
modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp).HasName("Index_MyProp");
```

**Create unique index (unique key)**

``` C#
modelBuilder.Entity<MyEntity>().HasIndex(p => p.MyProp).IsUnique();
```

### Schemas and Tables

**Apply schema and table name (Data Annotation)**

``` C#
[Table("TableName", Schema = "SchemaName")]
public class MyEntity
{

}
```

**Apply schema and table name (Fluent API)**

``` C#
modelBuilder.Entity<MyEntity>().ToTable("TableName", "SchemaName");
```

**Default value columns**

``` C#
modelBuilder.Entity<MyEntity>().Property(p => p.MyProp).HasDefaultValue(3);

modelBuilder.Entity<MyEntity>().Property(p => p.MyProp).HasDefaultValueSql("getdate()");
```

### Primary keys

**Create table without primary key**

``` C#
modelBuilder.Entity<MyEntity>().HasNoKey();
```

**Create table with primary key without autoincrement**

``` C#
modelBuilder.Entity<MyEntity>().Property(p => p.MyProp).ValueGeneratedNever();
```

**Create table with compound primary key**

``` C#
modelBuilder.Entity<MyEntity>().HasKey(p => new { p.MyProp01, p.MyProp02 });
```

### Raw SQL

It is possible to use raw sql with the Entity Framework Core if necessary. Just use the following call:

``` C#
context.Database.ExecuteSqlInterpolated("stringSqlWithCommand")
```

Where `context` is the instance of DbContext used and `stringSqlWithCommand` is the desired sql command. The call executes the sql command on the database and returns the number of rows affected.

It is important to reinforce the importance of avoiding `SQL Injection` failures. For this, it is important to use `string interpolation` in the construction of the sql command. EF Core already translates this command using parameters that prevent SQL Injection errors.

Example of a sql command that uses string interpolation:

``` C#
context.Database.ExecuteSqlInterpolated($"delete from common.Address where Id={address.Id}")
```

If you want to build the command in a separate method, the return type `FormattableString` should be used.

``` C#
private FormattableString GetDeleteAddressSql(Address address)
{
    return $"delete from common.Address where Id={address.Id}";
}
```

**It is important to reinforce that the use of raw SQL with Entity Framework Core is not recommended, being advisable only in exceptional cases.**

### Organize Fluent API in DbContext

Sometimes, over time, the use of the Fluent API in the `OnModelCreating` method of DbContext can leave the class with excessive lines, making maintenance a little more difficult and increasing complexity.

EF Core has a feature to better organize this code. This is the use of the `IEntityTypeConfiguration` interface. An example of this feature is presented in class [CustomerTypeConfiguration](./EntityFrameworkCoreLab.Persistence/EntityTypeConfigurations/Ebay/CustomerTypeConfiguration.cs), in which some configurations of the entity were defined. These settings are applied at [EbayDatabaseFirstDbContext](./EntityFrameworkCoreLab.Persistence/EntityFrameworkContexts/EbayDatabaseFirstDbContext.cs).

## Lessons learned

* Entity Framework Core 3.1 has considerably improved aspects of ease of use, robustness and performance over Entity Framework 6 and earlier versions;

* Although EF Core makes a lot easier, aspects such as database design and SQL performance generated should not be overlooked. If your database design and queries are bad, EF Core won't do a miracle;

* The data model must be decoupled from your application domain model. Almost 100% of the examples on the internet or reference materials preach the idea of using the same model. This is a major architectural error that most of the time will cause problems in your modeling. With that in mind, use models that have the sole responsibility of generating your data model and loading query data. For business objects use other classes, despite the slightly larger work, this leaves the application with fewer bugs and code smells in the medium/long term;

* Programmers with little experience in database design, query optimization and the use of ORMs pointed to EF Core as the villain of performance. Check these items first before pointing out the ORM as the villain of the performance;

* For operations that involve inserting/updating/deleting several records, try to accumulate the N operations in DbContext and make a single call to SaveChanges. In addition to being in a transaction context, EF Core already has optimizations for working with batch records. The use of methods that work with AddRange/UpdateRange/RemoveRange collections are much more efficient in terms of performance;

* For operations that need to be part of a single transaction, just call SaveChanges after the N DbContext method calls. All operations will already be transacted;

* The use of LINQ proved to be the most expressive and flexible tool for building queries. However, it is necessary to pay attention to the generated query log in order to check if the generated SQL needs to be optimized for each situation;

* Avoid the use of raw SQL with EF Core, ORM has the objective of abstracting raw SQL. If you notice that the need for pure SQL is becoming frequent, try to improve your knowledge in using the framework or migrate to a solution using [ADO.NET](https://docs.microsoft.com/en-US/dotnet/framework/data/adonet/ado-net-code-examples) or [Dapper](https://github.com/StackExchange/Dapper);

* This entire case study was done using SQL Server. Some implementations and/or results may change to other DBMSs. If your DBMS is not the SqlServer do tests with the DBMS you use to have more reliable results;

* The use of the Model First strategy proved to be more reliable and generated less boilerplate code. The design is cleaner and more intuitive. Nevertheless, if you are using Model First, check the migrations generated and how the physical database project is doing. Adjustments always appear according to the needs of each business;

* To create the data and relationship model, prioritize the use of the ByConvention strategy and then DataAnnotation, leave the FluentAPI strategy for exceptional cases. The project is more intuitive and with less code generated for maintenance;

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