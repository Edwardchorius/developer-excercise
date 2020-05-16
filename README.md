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

                                            
## The Idea behind all of this

Since the initial requirements stated that the author should choose a way of implementing
a solution to the problem, I chose the **Onion Architecture**. I was after a clean architecture, meaning following as much as possible rules associated with the **Clean** model. In this case, I wanted to put the **Domain** & **Application** layers in the centre, meaning all other layers, such as **Persistence**, other **Infrastructure** layers, **Presentation** & **Tests** are coupled to the Application Core, not the other way around. This means following a dependency rule **Outwards to Inwards**.

The **Libs** folder with its purpose mentioned above servers as a "common" folder for other services if it were a microservices architecture. It could be extended to provide abstractions for other ORM's, other Mediator functionality, but the purpose is to define how other potential microservices, if added, could use the overall base Abstraction for its persistence (if it were to use EF then it would use the Persistence related to EF, defined in the Presentation folder).

## CQRS
One thing to notice is the decision to use a separate persistence project for PUT/POST/DELETE & a separate persistence project for /GET. This is an attempt to 
implement the CQRS pattern, without event sourcing **AND** using a **single DB** for both commands and queries. The idea was to provide something which could be extendable, maintainable and scalable. That is why the decision was made by the author to showcase a potential for the CQRS here, even though for the initial project requirements this is an overall **overkill**.

## Mediator
The mediator pattern is also something, which provides a potential for writing shorter code in the controller action's and to provide a good feature structure in the application layer. Once again, this is an overkill, but if the project were to scale, this would come in handy. With the **MediatR**, one could build up pipeline behaviors, such as for **Logging**, **Validation** (something which is unfortunately not seen in the current implementation, but could in a day be provided), **ExceptionHandling** etc. This will act as filters, meaning if configured in the Startup and implemented in the MediatorBuilder, each request would pass through these pipelines. The only behavior implemented in the current project is the **Persistence**, which brings us to the use of **UoW** pattern.

## UnitOfWork  

If one would use multiple different databases or other storages (like filesystems etc) and would want to coordinate multiple operations on these many potential storages in a **single transaction**, he would benefit a lot from the UoW. Once again, it was briefly introduced here in order to show the its potential, serving as an feature, providing better maintainability.

## Testing
Last but not least, the tests. Surely the **clean** architecture provides for better testability. One could test the whole application layer and if he were to use **DDD** and write many logic in each domain model (currently that is not the case the business requirements for the current project are way too puny) he could also test each method in each Aggregate.


Overall I tried to stick to the business requirements but prioritized mainly the architecture.



 
