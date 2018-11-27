# aspnetcoresql

The first choice for SQL-database should be the PaaS version of SQL-Server found on azure. 
Ef core is a lightweight ORM cross platform version of Entity Framework.
It is compatible with a vast array of databases – including of course the database of choice: Microsoft SQL-Server, which will serve as the example here.
It’s posible to either generate a database from a model in code, or generate entity classes from an existing database.
For new projects the code-first approach will usually be the most sensible.

Create Entity classes.
This should either have a property with it’s name ending in Id – or have a property with an annotation to specify the Id.

Create Context class extending DbContext and have it contain DbSets with the entity classes.
Add context to services:
services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));

This is using the Core way of adding dependencies to services for use through injection in the constructor of classes that need the ressource. 
The connectionstring should of course be placed in a keyvault instead of a configuration-file, and never directly in code.

Use the Package Manager Console to create a migration and update the database to correspond to the model:
dotnet ef migrations add InitialCreate
dotnet ef database update


This will create the tables listed as DbSets, and we are good to go!
From here we can use an instance of the DbContext to query for objects.
Example: _dataContext.Things.Find(id);
Linq can be used for more advanced queries.

Changes to objects are persisted using the SaveChanges() method on the context instance.

This example is quite simplified, note in particular that a keyvault was not configured, and API methods are rather minimalistic.
These will naturally have to be fixed in an application for production.
There are a number of annotations for defining names and relations in ef-core.
These can be found at https://entityframeworkcore.com/model-data-annotations as well as in official Microsoft documentation.
