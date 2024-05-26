# Equipment Status API

## Overview

The Equipment Status API is a simple, yet functional backend application that demonstrates how to keep track equipment status updates and provide a RESTful API to interact with this data. 
The API is documented using Swagger and uses a lightweight SQLite database.

## Features

- Receive and store equipment status updates
- Retrieve the current status of any equipment
- API documentation and testing using Swagger UI

## Setup Instructions

### Prerequisites

- .NET Core SDK 8.0 or later
- SQLite (included in the project)
- Entity Framework core

### Steps to Run the Application

1. **Clone the Repository**

   Clone the repository and and navigate to the solution directory.

   ```bash
   git clone https://github.com/p-koskey/EquipmentStatusAPI.git
   cd EquipmentStatusAPI

2. **Restore dependencies**

   Restore the necessary NuGet packages.

     ```bash
     dotnet restore

3. **Build the project**

   Build the project to ensure all dependencies and configurations are correct.

     ```bash
     dotnet build

Make sure you install dotnet-ef tool, if you don't have it installed, use the following command :    
   
     dotnet tool install --global dotnet-ef --version 8.*
     
4. **Change the directory into the API directory**

   Navigate to the project directory.
      ```bash
     cd EquipmentStatusAPI
     
5. **Add the Initial Migration**
 
    Add the initial migration to set up your database schema.

    ```bash
     dotnet-ef migrations add InitialCreate

6. **Update the database**

   Apply the migration to update your database.

     ```bash
     dotnet-ef database update

7. **Run the application**

   Run the application using the following command:

    ```bash
     dotnet run

Open your browser and navigate to http://localhost:5147/swagger/index.html to view and test the endpoints
     
## Choice of database
The application uses SQLite as a lightweight, file-based database. SQLite is suitable for this project due to its simplicity and it's quite easy to setup. 

## Architectural pattern
Since it is a small project, a traditional layered architecture was used.
This architecture has the following layers:

- Controllers: Handle HTTP requests and responses.
- Services: Contain business logic.
- Repositories: Interact with the database.
- DTOs (Data Transfer Objects): Transfer data between layers and to/from the client.

This pattern promotes separation of concerns, making the application easier to maintain and extend.

## Testing
Unit tests are included to ensure the reliability of the API endpoints. 

### Running Tests
1. **Change the directory into the EquipmentStatusAPI.Tests directory**

   Navigate to the test project

     ```bash
    cd EquipmentStatusAPI.Tests
     
3. **Run the Tests**

   Run the tests using the following command:

     ```bash
    dotnet test
