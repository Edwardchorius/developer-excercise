# Developer Exercise

This update on the original ReadMe file is intented to provide a brief explanation of the current author's chance to provide an architecture and an overall idea of an implementation of the initial project requirements.


## Project Structure
This is the initial project structure

![Image description](Images/ProjectStructure1.png)
There are 5 folders.

Starting from the **first**:
![Image description](Images/ProjectStructure2.png)
The Core folder contains 3 projects:
- Application.Commands
- Application.Queries
- Domain

**Second**: Application
![Image description](Images/ProjectStructure3.png)
- Persistence
- Persistence.Commands
- Persistence.Queries

**Third**: Libs
![Image description](Images/ProjectStructure4.png)
- Mediator folder, containing projects related to the setup of the Mediator
- Persistence folder, containing projects related to the overall abstraction layer for the persistence layer.
- Domain project, related to the overall abstraction of the domain layer in the project
- ExceptionHandlingMiddleware, providing a pipeline for handling thrown exceptions

**Forth**: Presentation
![Image description](Images/ProjectStructure5.png)
- Api, which serves as an endpoint for clients( i.e. Angular client, React client, etc)

**Fifth**: UnitTests
![Image description](Images/ProjectStructure6.png)
- Test project for tests related to the business layer

                                            
##The idea


 
