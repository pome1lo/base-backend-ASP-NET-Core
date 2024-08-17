 
---

# Web Application Template with Three-Layer Architecture

This repository contains a template for creating a web application using a three-layer architecture, including DataAccess, BusinessLogic, and Presentation layers. All logic is encapsulated in C# class libraries. Controllers are located in ASP.NET Core Web API applications (microservices).

## Project Structure

- **DataAccess**: Contains classes and methods for working with the MS SQL Server database.
- **BusinessLogic**: Contains the business logic of the application.
- **Presentation**: Contains controllers for ASP.NET Core Web API.

## Microservices

### Authentication

A basic authentication service using JWT tokens with login, registration, and password recovery capabilities.

### Profiles

A profile service with the ability to edit and delete user profiles.

### Notifications

A service for sending notifications to users.

## API Gateway

Ocelot is used for routing requests to the appropriate microservices.

## Docker Compose

Support for Docker Compose to simplify container deployment and management.

## Caching

Redis is used for caching data.

## Database

MS SQL Server is used for data storage.

## Configuration

Example `appsettings.json` file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "EmailSettings": {
    "SmtpServer": "smtp.mail.ru",
    "SmtpPort": 465,
    "Email": "example@mail.ru",
    "Password": "password"
  },
  "Jwt": {
    "Key": "",
    "Issuer": "App",
    "Audience": "Users",
    "ExpiresInMinutes": 60
  },
  "ConnectionStrings": {
    "AppDbContext": "Server=DESKTOPALX\\SQLEXPRESS;Database=APP;User Id=sa;Password=sa;TrustServerCertificate=true;",
    "Redis": "localhost:6379"
  },
  "AllowedHosts": "*"
}
```

## Getting Started

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo.git
   ```

2. Configure the `appsettings.json` file in each microservice.

3. Start Docker Compose:
   ```sh
   docker-compose up
   ```

4. The application will be available at `http://localhost:5000`.

## Contributing

We welcome your suggestions and improvements! Please create pull requests and open issues.
  
