# Movie Quotes

Web application from holding movie names and quotes.

The application has an  Angular front-end

Once you have the source code, 
run  this from the "MovieQuotes/client" folder to load the dependencies
```sh
$ npm install
```
Run  these from the "MovieQuotes/" folder to create the database file.
More info here about database migrations in Entity Framework Core:
https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/
```sh
$ dotnet ef migrations add InitialCreate
$ dotnet ef database update
```

Use this to run the server ("MovieQuotes/" folder) 
```sh
$ dotnet run
```
and this to run the frontend
```sh
$ node start
```





