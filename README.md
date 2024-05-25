# Equipment Status API

## Overview

The Equipment Status API is a simple, yet functional backend application that demonstrates how to handle equipment status updates and provide a RESTful API to interact with this data. 
The API is documented using Swagger.

## Features

- Receive and store equipment status updates
- Retrieve the current status of any equipment
- API documentation and testing using Swagger UI

## Setup Instructions

### Prerequisites

- .NET Core SDK 8.0 or later
- SQLite (included in the project)

### Steps to Run the Application

1. **Clone the Repository**

   ```bash
   https://github.com/p-koskey/EquipmentStatusAPI.git
   cd EquipmentStatusAPI

2. **Restore dependencies**
 
     ```bash
     dotnet restore

3. **Build the project**
 
     ```bash
     dotnet build

Make sure you install dotnet-ef tool, if you don't have it installed, use the following command :    
   
     dotnet tool install --global dotnet-ef --version 8.*
     
4. **Change the directory into the API directory**

      ```bash
     cd EquipmentStatusAPI
     
5. **Add the Initial Migration**
 
    ```bash
     dotnet-ef migrations add InitialCreate

6. **Update the database**

     ```bash
     dotnet-ef database update

8. **Run the application**

    ```bash
     dotnet run

Open your browser and navigate to http://localhost:<port>/swagger/index.html to view and test the endpoints
     
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

##Testing
Unit tests are included to ensure the reliability of the API endpoints. 

### Running Tests
1. **Navigate to the tests project**
   
     ```bash
    cd EquipmentStatusAPI.Tests
     
3. **Run the Tests**
   
     ```bash
    dotnet test
