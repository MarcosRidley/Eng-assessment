# ENG software engineer assessment

## Overview

This project is developed in line with the guidelines provided by Eng, aiming to create a scalable and flexible User Manager Service with basic CRUD functionality.

## Description

This service is designed to efficiently manage user data within our system. It provides endpoints to create new users, update user states, delete users, and list all active users. The service follows RESTful API conventions and utilizes the .NET Core framework.

## Features

**This project uses a fully generic API building system in which you inject entity framework models into appropriate service classes and a basic CRUD is automatically generated**

- **Create a New User:** Allows the creation of a new user with the "Active" status set to true by default.
- **Update User State:** Enables updating the "Active" status of an existing user. **BONUS:** Toggle User State route included as well.
- **Delete Users:** Provides functionality to delete users from the database. Note this is a hard database delete.
- **List All Active Users:** Returns a list of all users with the "Active" status set to true. 
- 

## Technology Stack

- **Framework:** .NET Core
- **Database:** SQL Server
- **Testing:** nUnit tests have been implemented to ensure the reliability of the service. Due to the nature of the generic system, all of those could also be made generic so as to include future additions to the codebase.

## Installation

1. Clone the repository.
2. Set up your database and configure the connection string in the `appsettings.json` file.
3. Run migrations through the update-database command on package manager console in Visual Studio (or your choice of CLI)
4. Build and run the project.

## Usage

Once the project is running, you can access the API endpoints using your preferred API client. Swagger GUI will load by default.

## Testing

- Unit tests have been implemented to cover critical functionalities of the service.
- To run tests simply run the testing project instead of the API project.

If you have any questions or need further assistance, feel free to contact [through LinkedIn](https://www.linkedin.com/in/marcosridley/).
