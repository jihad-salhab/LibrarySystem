# .Net Core Project For Library System

This project defines the base logic that could be included in a library system it will have book entities and its related entities, including authors, categories and subcategories. This project was built using DB First Approach

## How Was This Project Built?

- Defining the DB with the following tables :

  - Category Table: ID, Name
  - SubCategory Table: ID, Name, CategoryID
  - Author Table: ID, Name
  - Book Table: ID, Title, CategoryID, SubCategoryID, AuthorID
  - **Note:** GUIDs could have been used in real-life scenario, but since this is a demo, INTs were preferred.

- Define Stored Procedures (SPs):

  - CRUD on all tables, with and without filtration

- Created new .Net Core MVC Project:

  - Modified appSettings.json and Program.cs
  - Created a singleton for retrieving global variables. Under "Shared" Folder

- Created a reflection entity for each table in Models Layer/Folder: These models are unified to allow Standard ADO.Net connections and EntityFrameWork. Different classes could have been created.

- Created Persistence Folder for EntityFramework DB Contexts

- Created a class called "DataResult" under "Shared -> Models":
  This is a generic class that contains: Data, DidFail, Reason
  This model is used to unify the returned results from all methods.

- Create Common Logic Code (Async Base Classes):
  - Created a class called "BaseDataManager.cs" under "Data" Folder: This class contains four async methods as follows:
    - ExecuteScalar: Overrides the logic in default ExecuteScalar, takes spName and params array to pass required parameters to stored procedure and returns an instance of DataResult class
    - ExecuteNonQuery: Takes spName and params, this returns a DataResult of type int.
    - GetSPItems: Returns a DataResult obj of type List of generic T and takes spName and params, and a mapper function that in its turn takes a SqlDataReader and returns an object of type T.
    - GetSPItem: Same as GetSPItems but returns a single entity mapped from the SqlDataReader.
- Create Shared folder containing two subdirectories "Business" & "Data":
  - Under Business: Two Interfaces were created, IManagerCommand, IManagerQuery. These two interfaces assure segregation is applied. These two interfaces contain method prototypes for all crud methods, Command Interface: Insert, Update, Delete. Query: GetAll, GetById. These interfaces will be implemented by Manager Classes for each entity, this uniforms the code structure. These implementations exist under Manager classes in "Business" Layer/Folder
  - Under Data: Creating Two interfaces IDataManagerCommand, IDataManagerQuery. These interfaces will be implemented by DataManager classes under "Data" Layer/Folder that shall read or alter data on the database and return data accordingly.

## Used Software Patterns & Techniques

- MVC (Model - View - Controller): Used as is, as described by Microsoft. These defaults were left untouched.

- CQRS: Command and Query Responsibility Segregation Pattern, this pattern was used in its simple form to make sure Command and Queries were logically separated. Thus, this ensures code can be maintained easily and features can be added flawlessly. This also satisfies the concept of "Keep low coupling, high cohesion".

- Onion Architecture: This project made good use of separating the main structure into layers, by building the following layers:
  - Data Layer: Classes and handlers related to reading from DB and mapping data to objects
  - Business Layer: Classes and handlers related to manipulating data and retrieving it.
  - Models Layer: Contains entities that the system will rely on.
  - View Layer: Contains UI and related components
  - Shared Layer: This layer contains shared classes and helpers that will be used throughout the system.

## How To Run This Project

- Open MSSQL, and restore from DataBaseBackUp -> LibraryDB.bak
- Clone Repo.
- Run Project
- Note:
  - Connection String Might Need To Change, It Exists In The `appSettings.json`
  - Check Port Number After Running Project And Change It In: `Controllers/HomeController.cs` & `Views/Home/Book.cshtml`
- Enjoy ❤️!
