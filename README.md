Final Project for CEN4031

How this was developed:
First, I started by creating a sample Razor application, as this will be used for my Presentation Layer

![starterrazorapp](https://github.com/MalachiV12303/Final-Project/assets/60449281/0a1d50a0-b895-4514-9a5d-af90ede65a1f)

For the next layer, the Domain layer I used EF Core to communicate between the Presentation layer and Data Acces Layer, SQLite.
Next, for creating and storing Tickets to a database, I created a Ticket object in C# utilize EF Core to write these Tickets to the database,

The final layer, the Data Access layer, I implemented a simple SQLite database to contain all Ticket objects.  This was created autonomously through
program.cs EF Core, .EnsureCreated().  It was then initialized to have example Tickets using DbInitializer.cs:
I installed and used DB Browser to view my sample database, with sample Tickets:

![sample database](https://github.com/MalachiV12303/Final-Project/assets/60449281/ba2c8d27-e593-4dc2-a1e5-fff5c020c73f)

Implemented links to Tickets/Index and Tickets/Create on the navbar, updates boilerplate wordings, removed unnecessary buttons and removed "fake" tickets.
I removed these tickets to ensure the database will not overwrite itself back to the DbInitializer database each time the project is built.

![featuresadded](https://github.com/MalachiV12303/Final-Project/assets/60449281/e749e8e4-4a0e-45a3-a4ec-efbdb33a6f8c)

Lastly, I updated the stylings:

![finalstyling](https://github.com/MalachiV12303/Final-Project/assets/60449281/ebf9ece3-5dd5-43fa-a746-abbdddeeeb41)
