# CRUDy
CRUDy  is a C# library based on .NET 8 and Entity Framework Core, designed to simplify CRUD (Create, Read, Update, Delete) operations in applications. It provides a generic and extensible implementation of CRUD services, enabling developers to focus on their application's business logic without worrying about common database operations.

# Features
- Generic CRUD Operations: Simplifies data access with generic repository patterns.
- Entity Framework Core Integration: Utilizes EF Core for efficient database interactions.
- Auditable Entities: Automatically tracks creation and modification details (CreatedDate, CreatedBy, UpdatedDate, UpdatedBy).
- Async Support: Asynchronous methods for scalable and responsive applications.
- Dependency Injection Ready: Seamlessly integrates with ASP.NET Core dependency injection.

# Installation
You can install CRUDy via NuGet Package Manager:

    dotnet add package CRUDy


## Getting Started

### 1. Define Your Entities

Create your application-specific entities inheriting from `AuditableEntity<TEntityId>` provided by CRUDy :

    public class Product : AuditableEntity<long> // long, string, int
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Add other properties as needed
    }

### 2. Implement Repository Interfaces

Define repository interfaces using `ICrudyGenericRepository<TEntity, TEntityId>` for each entity :

     public interface IProductRepository : ICrudyGenericRepository<Product,long>{
     }

### 3. Implement Repository Classes

Implement repository classes based on your interfaces, using CRUDy's base repository class :

    public class ProductRepositoryImpl : CrudyGenericRepositoryImpl<Product, long>, IProductRepository
    {
        public ProductRepositoryImpl(YourAppDBContext context) : base(context)
        {
        }
    }

### 4. Register Services

Register your repository classes and DbContext in the ASP.NET Core `Program.cs or Startup.cs` file:

    builder.Services.AddScoped(typeof(ICrudyGenericRepository<,>), typeof(CrudyGenericRepositoryImpl<,>));

// Your services

    builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();  

## Contributing

We welcome contributions! If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.