# Overview
This document provides a comprehensive introduction to the InkWaveAPI, a robust e-commerce platform built with ASP.NET Core that implements a clean architecture approach. The InkWaveAPI serves as the backend system for managing various aspects of an online store, including payments, orders, user management, and product catalogs.

For specific implementation details about the payment system, which is the most critical component of the application, see Payment System.

## System Purpose and Scope
The InkWaveAPI is designed to provide a scalable, maintainable backend for an e-commerce platform with the following primary capabilities:
- Payment processing and management
- User authentication and account management
- Order creation and processing
- Item and category management
- Shopping cart functionality
- Address management
- Favorites management
- Printing service management
- 
## 🏗️ Architecture Overview
InkWaveAPI follows a clean architecture approach with clearly defined boundaries between layers. This design promotes separation of concerns, maintainability, testability, and enables independent evolution of each layer.



![image](https://github.com/user-attachments/assets/aae196b6-e6c5-44f0-941b-70cbac345aa3)


## Core Architectural Layers
### API Layer

The API layer consists of controllers that handle HTTP requests and serve as the entry point to the application. Controllers use the Mediator pattern to dispatch commands and queries to their respective handlers.
Example controller from the codebase:


![image](https://github.com/user-attachments/assets/d4e2fce1-1e91-4b42-9e2a-371191155ede)

### Application Layer
The Application layer implements the Command Query Responsibility Segregation (CQRS) pattern, separating read operations (Queries) from write operations (Commands). This layer contains:
1- **Commands**: Request objects representing actions that change state
2- **Queries**: Request objects for retrieving data
3- **Handlers**: Process commands and queries, coordinating with domain entities and repositories
4- **Validators**: Ensure commands and queries contain valid data
5- **DTOs**: Data Transfer Objects that shape the data returned to clients
![image](https://github.com/user-attachments/assets/d273408b-21d4-4f5a-bc6e-37e63872e06b)
### Domain Layer
The Domain layer contains the core business logic and entities that represent the business concepts. It includes:
1- **Entities**: Core business objects with identity and lifecycle
2- **Value Objects**: Immutable objects that have no identity
3- **Domain Events**: Notifications of significant changes within the domain
4- **Domain Interfaces**: Abstractions for repositories and services
![image](https://github.com/user-attachments/assets/10afae5a-9c58-4a4e-986c-0de6e4e63f36)
### Infrastructure Layer
The Infrastructure layer provides implementations of interfaces defined in the Domain and Application layers. It includes:

1- **DbContext**: Manages database connections and entity relationships
2- **Repositories**: Implement data access logic
3- **Unit of Work**: Manages transactions and ensures atomic operations
4- **External Services**: Implementations of third-party service integrations
![image](https://github.com/user-attachments/assets/d16ca62c-2b3d-47b0-947c-c3f39d491df5)
## Design Patterns Implementation
### Repository Pattern
The Repository pattern abstracts data access logic from the rest of the application. InkWaveAPI implements a generic repository base class and specific repositories for each domain entity.
![image](https://github.com/user-attachments/assets/30621723-c402-46da-9db0-b43d7aed8371)
## Unit of Work Pattern
The Unit of Work pattern ensures that all repository operations are part of a single transaction, maintaining data consistency.
![image](https://github.com/user-attachments/assets/a8dd5989-9ca6-45bb-a87b-d6dca5c06176)
## CQRS Pattern
The Command Query Responsibility Segregation pattern separates read operations from write operations. This pattern is implemented using MediatR.
![image](https://github.com/user-attachments/assets/b6053c1c-d1d8-4521-9be2-034b030520b8)
## Request Flow
The following diagram illustrates how a typical request flows through the system:
![image](https://github.com/user-attachments/assets/646be95e-40e9-475f-96de-d535f7a0b1a8)
## Database Schema
The ApplicationDbContext manages the following entity relationships:
![image](https://github.com/user-attachments/assets/f4b049a5-c5f2-439b-9d62-6893ab5c161b)
## Cross-Cutting Concerns
### Domain Events
The system uses domain events to notify other parts of the application when significant changes occur. These events are intercepted by the PublishDominEventInterceptor.
![image](https://github.com/user-attachments/assets/cdb8219e-e007-446e-afcb-11033ccfbbab)
## Dependency Injection
Services are registered using extension methods on IServiceCollection:
![image](https://github.com/user-attachments/assets/7f3c05e4-af3e-47d4-819d-d847609ea018)

# 🔧 Technology Stack
The InkWaveAPI technology stack follows modern best practices for building scalable, maintainable, and testable applications.
![image](https://github.com/user-attachments/assets/14be877a-7896-4558-ac6c-40d982051962)
## Primary Libraries and Technologies
### API and Application Layer
| Technology        | Version   | Purpose                                         |
|-------------------|-----------|-------------------------------------------------|
| **ASP.NET Core**  | 7.0       | Web API framework                               |
| **MediatR**       | (Implied) | Mediator pattern implementation for CQRS        |
| **AutoMapper**    | 12.0.1    | Object-to-object mapping                        |
| **FluentValidation** | 11.8.0 | Validation library                              |
### Data Access and Persistence

| Technology        | Version   | Purpose                                         |
|-------------------|-----------|-------------------------------------------------|
| **Entity Framework Core**  | 7.0       | Object-Relational Mapper (ORM)                             |

### Authentication and Security
| Technology           | Purpose                                         |
|-------------------|-------------------------------------------------|
| **JWT Authentication**  | Token-based authentication                               |
| **JwtBearer**  |  JWT token validation and processing                              |
### Communication Services
| Technology           | Purpose                                         |
|-------------------|-------------------------------------------------|
| **SMTP Client**  | 	Email sending functionality                               |

## CQRS Implementation with MediatR
The InkWaveAPI implements the Command Query Responsibility Segregation (CQRS) pattern using MediatR as the mediator library.
![image](https://github.com/user-attachments/assets/a7b8be2e-b0ff-4843-b367-15ff10a26fb4)

## JWT Authentication Flow
The authentication system uses JWT tokens for secure API access.
![image](https://github.com/user-attachments/assets/1241ce60-5169-43a8-9e2d-11fcef843a02)
## Email Service Integration
![image](https://github.com/user-attachments/assets/755c79bc-14e6-454f-ad49-033d661419cb)
## Dependency Injection Configuration
The application uses ASP.NET Core's built-in dependency injection container to register and resolve services throughout the application.
![image](https://github.com/user-attachments/assets/0a66ceab-55c4-4f43-84c9-6d8c94690974)




# Payment System
## Overview
The Payment System is a critical component of the InkWaveAPI that handles all payment-related operations within the application. This system manages both payment transactions and payment methods for users, providing a comprehensive solution for processing and tracking financial transactions.

The system is designed to handle:

Payment creation and processing for orders
Payment method management (credit/debit cards)
Payment status tracking
Secure storage of payment information
For information about the Order processing that triggers payments, see Order System.
## System Architecture
### Domain Model Diagram
![image](https://github.com/user-attachments/assets/5fb70118-3500-470a-b3c0-0161c3b6c1be)
### System Interaction Flow
![image](https://github.com/user-attachments/assets/9d556022-f84f-4104-86a0-114d834c3761)
## Payment Processing Components
### Payment Entity
The Payment class is the core domain entity that represents a payment transaction in the system:
| Property       | Type           | Description                                                                 |
|----------------|----------------|-----------------------------------------------------------------------------|
| Id             | Guid           | Unique identifier for the payment (inherited from BaseAuditableEntity)      |
| PaymentStatus  | PaymentStatus  | Current status of the payment (NotPaid, Processing, Paid, Failed, Refunded) |
| PaymentValue   | double         | Amount of the payment                                                       |
| PaymentDate    | DateTime       | Date and time when the payment was made                                     |
| PaymentType    | string         | Type of payment (e.g., "Credit Card", "PayPal")                             |
| PaymentMethod  | string         | Method of payment (e.g., "Visa", "MasterCard")                              |
The Payment entity includes a static factory method for creating new payment instances:
```csharp
public static Payment Create(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
```
### Payment Repository
The PaymentRepository class implements the IPaymentRepository interface to provide data access operations for payment entities:
| Method               | Description                      |
|----------------------|----------------------------------|
| CreatePaymentAsync   | Creates a new payment            |
| RemovePaymentAsync   | Removes a payment                |
| GetPaymentByIdAsync  | Retrieves a payment by ID        |
| GetAllPaymentsAsync  | Retrieves all payments           |

### Payment API Endpoints
The PaymentController exposes the following RESTful endpoints for payment operations:
| Endpoint             | HTTP Method | Description                      |
|----------------------|-------------|----------------------------------|
| /api/Payment         | POST        | Add a new payment for an order   |
| /api/Payment/{id}    | DELETE      | Remove a payment by ID           |
| /api/Payment         | GET         | Get all payments                 |
| /api/Payment/{id}    | GET         | Get a payment by ID              |
All endpoints require authentication as indicated by the [Authorize] attribute on the controller.

## 🧾 Payment Commands and Queries

The system uses the **CQRS (Command Query Responsibility Segregation)** pattern to separate read and write operations:

### 🛠️ Commands

- `AddPaymentCommand`: Creates a new payment for an order  
  **Properties**: `OrderId`, `PaymentValue`, `PaymentType`, `PaymentMethod`

- `RemovePaymentCommand`: Removes a payment  
  **Properties**: `UserId`, `ItemId`

### 🔍 Queries

- `GetPaymentByIdQuery`: Retrieves a payment by ID  
- `GetAllPaymentsQuery`: Retrieves all payments
## Payment Method Components
### PaymentMethod Entity
The PaymentMethod class represents a stored payment method (like a credit card) that users can save for future transactions:
| Property    | Type   | Description                                                             |
|-------------|--------|-------------------------------------------------------------------------|
| Id          | Guid   | Unique identifier for the payment method (inherited from BaseAuditableEntity) |
| UserId      | Guid   | ID of the user who owns this payment method                             |
| CardName    | string | Name on the card                                                        |
| CardNumber  | string | Card number                                                             |
| CardMonth   | string | Expiration month                                                        |
| CardYear    | string | Expiration year                                                         |
| CardCVV     | string | Card security code                                                      |
The `PaymentMethod` entity includes both factory and update methods:
- `Create(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)`  
  Creates a new `PaymentMethod` instance.

- `Update(Guid userId, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)`  
  Updates the existing `PaymentMethod` instance.
### PaymentMethod Repository
The `PaymentMethodRepository` class implements the `IPaymentMethodRepository` interface to provide data access operations for payment method entities:
| Method                             | Description                                                   |
|------------------------------------|---------------------------------------------------------------|
| **CreatePaymentMethodAsync**       | Creates a new payment method                                  |
| **UpdatePaymentMethod**            | Updates an existing payment method                            |
| **GetById**                        | Retrieves a payment method by ID                              |
| **GetAllPaymentMethodsByUserId**   | Retrieves all payment methods for a user                      |
| **GetPaymentMethodById**           | Retrieves a payment method by ID                              |
### PaymentMethod API Endpoints
The `PaymentMethodController` exposes the following RESTful endpoints for payment method operations:
| Endpoint            | HTTP Method | Description                                          |
|---------------------|-------------|------------------------------------------------------|
| /api/PaymentMethod  | POST        | Add a new payment method                            |
| /api/PaymentMethod  | PUT         | Update an existing payment method                   |
| /api/PaymentMethod  | GET         | Get all payment methods for the authenticated user  |
All endpoints require authentication and include user verification to ensure users can only access their own payment methods.
## PaymentMethod Commands and Queries
### Commands:

- `AddPaymentMethodCommand`: Creates a new payment method
- `UpdatePaymentMethodCommand`: Updates an existing payment method
### Queries:

- `GetPaymentMethodByIdQuery`: Retrieves a payment method by ID
- `GetPaymentMethodByUserIdQuery`: Retrieves all payment methods for a user
## Validation
The Payment System implements validation using FluentValidation to ensure data integrity:

## AddPaymentCommandValidator
```csharp
public class AddPaymentCommandValidator : AbstractValidator<AddPaymentCommand>
{
    public AddPaymentCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.PaymentValue)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.PaymentType)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.PaymentMethod)
            .NotEmpty()
            .NotNull();
    }
}
```
## RemovePaymentCommandValidator
```csharp
public class RemovePaymentCommandValidator : AbstractValidator<RemovePaymentCommand>
{
    public RemovePaymentCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("{UserId} is required.")
            .NotNull();
        RuleFor(p => p.ItemId)
            .NotEmpty().WithMessage("{ItemId} is required.")
            .NotNull();
    }
}
```
## Integration with Other Systems
![image](https://github.com/user-attachments/assets/9c89ed12-e7f7-404c-9ea2-37a268e6fbf7)
The Payment System integrates with:
1- **Order System**: Payments are associated with orders, and payment processing is triggered when an order is placed.
- The `AddPaymentCommandHandler` interacts with the `IOrderRepository` to validate the order before creating a payment.
2- **User System**: Payment methods are associated with users, allowing users to save and reuse payment information.
- The `PaymentMethodController` verifies the user's identity before allowing access to payment methods.
## Security Considerations
The Payment System implements several security measures:
1- **Authentication**: All payment endpoints require authentication using the [Authorize] attribute.
2- **User Verification**: The `PaymentMethodController` validates that users can only access their own payment methods.
3- **Validation**: Input validation is performed using FluentValidation to prevent invalid data.
4- **Sensitive Data Handling**: Payment method information (credit card details) should be stored securely according to PCI DSS guidelines.

## Data Management
This document outlines the data persistence and database management infrastructure of the InkWaveAPI system. It covers the database context configuration, entity relationships, repository pattern implementation, and data access strategies used throughout the application.

For information about specific business entities and domain models, see Overview. For details on how the payment processing system utilizes this data layer, see Payment System.

## Database Context and Configuration
The InkWaveAPI uses Entity Framework Core with SQL Server as its primary data store. The database context serves as the foundation for all data persistence operations.

### ApplicationDbContext
The `ApplicationDbContext` class is the central component of the data persistence layer, extending Entity Framework's `DbContext`. It defines all entity collections and configures their relationships.
![image](https://github.com/user-attachments/assets/ad66a13c-dbe0-468b-ae6e-13d016c64a20)
The context includes:

- **Entity Collections**: Defined as DbSet properties for each domain entity
- **Interceptors**: A `PublishDominEventInterceptor` for publishing domain events when changes occur
- **Model Configuration**: Applied through the `OnModelCreating` method, which configures entity relationships and indexes
## Database Registration and Configuration
The database connection and context are configured through extension methods in the IServiceCollectionExtensions class:
![image](https://github.com/user-attachments/assets/058c1280-18f4-4173-aa60-ae3b4c0bc79d)
Key aspects of the database configuration:

- Connection string is loaded from the application configuration
- SQL Server is configured as the database provider
- Migrations assembly is set to the assembly containing the ApplicationDbContext
- The PublishDominEventInterceptor is registered as a scoped service
### Entity Relationships and Data Model
The InkWaveAPI database schema includes several interconnected entities that form the foundation of the application's data model.

#### Entity Relationship Diagram
![image](https://github.com/user-attachments/assets/2041f783-e42b-4628-9ac7-c268c5ec8ab9)
####Key Entities and Their Properties
The InkWaveAPI data model consists of the following primary entities:
| Entity          | Primary Purpose             | Key Properties                                  |
|-----------------|-----------------------------|-------------------------------------------------|
| **User**        | Authentication and user information | Id, UserName, Email, passwordHash, passwordSalt |
| **Item**        | Product information         | Id, Title, Price, Quantity, Description         |
| **Category**    | Product categorization      | Id, Name, Description, CategoryParentId         |
| **Order**       | Purchase records            | Id, CustomerId, OrderStates, PaymentStatus     |
| **OrderLine**   | Order item details          | Id, OrderId, ItemId, Quantity, Price           |
| **Payment**     | Payment records             | Id, PaymentValue, PaymentStatus, PaymentMethod |
| **PaymentMethod** | Stored payment methods    | Id, UserId, CardNumber, CardName               |
| **Address**     | Shipping and user addresses | Id, UserId, Country, City, Street              |
| **Cart**        | User shopping cart          | Id, UserId, ItemId, Quantity                   |
| **Favourite**   | User favorite items         | Id, UserId, ItemId                             |
####Repository Pattern Implementation
InkWaveAPI implements the Repository pattern to abstract the data access layer and provide a consistent interface for working with entities.

####Repository Architecture
![image](https://github.com/user-attachments/assets/9663c007-507e-4c4e-8c5e-58c7dbddfb87)
####Generic Repository
The system implements a generic repository pattern that provides common data access operations for all entity types:

1- **IGenericRepository** interface defines standard CRUD operations
2- **GenericRepository** provides the implementation using Entity Framework Core
3- **Entity-specific** repositories extend the generic repository with specialized queries

####Specialized Repositories
The application includes several specialized repositories for different entity types:

- `UserRepository`: User-specific queries and operations
- `ItemRepository`: Product and item management
- `FavouriteRepository`: User favorites management
- `AddressRepository`: User addresses management
- `OrderRepository`: Order processing and management
- `CartRepository`: Shopping cart operations
- `PrintingRepository`: Print service requests
- `PaymentRepository`: Payment processing
- `PaymentMethodRepository`: Saved payment methods management
Each repository is registered with the dependency injection container as a transient service, allowing for proper lifecycle management.

####Unit of Work Pattern
InkWaveAPI implements the Unit of Work pattern to maintain transaction integrity and coordinate operations across multiple repositories.

####Unit of Work Implementation
![image](https://github.com/user-attachments/assets/3d1671c2-4650-494b-beba-a03b1a3989e4)
The Unit of Work pattern provides the following benefits:

1- **Transaction Management**: Ensures that multiple database operations are treated as a single transaction
2- **Consistency**: Maintains data consistency across related entities
3- **Performance**: Optimizes database calls by batching changes
####Database Migrations
InkWaveAPI uses Entity Framework Core's migrations to manage database schema changes. Migrations are applied automatically during application startup to ensure the database schema matches the current entity model.

Key migration files include:

- Initial migration for setting up the database
- Entity-specific migrations for adding or modifying tables
- Many-to-many relationship configurations
####Data Access Workflow
![image](https://github.com/user-attachments/assets/2eb1f610-7907-43bd-b7ad-a59dce55f66b)
The typical workflow for data access in InkWaveAPI:

1- **Controller or Command Handler**: Requests a repository through the Unit of Work
2- **Repository Operations**: Perform data access operations through repositories
3- **Unit of Work Completion**: Call `CompleteAsync()` to save all changes as a single transaction
4- **Data Consistency**: Entity Framework manages relationships and ensures data integrity
This architecture ensures separation of concerns, testability, and maintainability while providing a consistent approach to data access across the application.

