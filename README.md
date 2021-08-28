# Command API Helper

Command API Helper is an API that helps developers summarizing the manual pages for command lines and provides the use cases for a particular command.

## Why?

I wanted a tool that provided a quick reference to the tools I usually use in my project. I can quickly query the command and its usage by making a ` GET ` request. In this project I have implemented a basic CRUD api.  

## How it works

You can create a database for the most recent command line arguments you use, use cases and platform by making a ` POST ` request to ` /api/commands `. The API uses  CRUD operations. 

## JSON Payload

The API implements Data Transfer Objects for user models. The domain models are different from what is being seen and used by users. I have implemented different DTOs for different operations. There are different models for reading, updating and creating command line arguments. 

Domain Model
```
  {
    "Id" : "1",
    "HowTo" : "migrate code first database using entity framework",
    "Platform" : "net core cli",
    "CommandLine" : "dotnet ef migrations add MigrateInitial"
  }
```
