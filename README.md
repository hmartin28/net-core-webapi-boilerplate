# Boilerplate for ASP.NET Core WEB API

## Installing the necessary packages

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore.Swagger
- Swashbuckle.AspNetCore.SwaggerUI
- Swashbuckle.AspNetCore.SwaggerGen

## Creating the database context class

> public [ContextFileName](DbContextOptions<[ContextFileName]> options) : base(options) { }
>
> public DbSet<[ModelFileName]> [ModeFileNames] { get; set; }

## Creating a connection string in appsettings.json file 

> "ConnectionStrings": {
    "DefaultConnection": "Server=MARTIN;Initial Catalog=test;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;"
}

## Setting up the database context and connection string in the Program.cs file

> builder.Services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

## Initializing the database in the server

> Add-Migration [MigrationName]
> 
> Update-Database

## Setting up swagger in Program.cs (if necessary)

> builder.Services.AddSwaggerGen();
>
> app.UseSwagger();
>
> app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API v1");
});
