# Final Project for Advanced Program Development Frameworks (CEN4031) 2024  
This course will provide the student with the skills to apply the Software Development Life Cycle (SDLC) to developing a business programming application. The student will implement advanced programming techniques using appropriate algorithms, programming concepts and tools. The course also provides the student with the necessary computing theories to produce software applications from design documents.

## Technologies Used:
- ASP.Net Razor with EF Core
- C#
- SQLite
- HTML and CSS
## Git Description
First, I started by creating a Razor application, as this will be used for my Presentation Layer

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

# Final Project Submission File

## Group Section:
### Description of the project, its functionality, and usage.
This project aims to develop the TitanHelp application, demonstrating proficiency in utilizing frameworks relevant to the subject matter covered.  This involves utilizing frameworks to create three separate layers for an application, the Presentation Layer, Domain Layer, and Data Access Layer.  This application should be able to display existing tickets and create new tickets via a “create” button.  Those are the initial requirements from the assignment, I decided to also implement a delete, edit, and view details features.
### Identification of team members and their roles, along with a general project description and initial requirements.
For this project, I was the sole member, so I developed each layer myself.  For the presentation layer, I had to find a framework that will relay the information to the user, as well as interact with the domain layer.  The assignment recommended Razor, Asp.net MVC, or WPF.  I chose to develop my project through Razor, this was done through:
```
dotnet new webapp -o TitanHelpFinal
```
This line of code creates a basic webapp using Razor.  To get these to work, I of course needed to install .NET 8.0 SDK, as well as C# for VS Code but I was able to get that through VS Code Extensions.  Once this was created, the presentation layer needed to be reorganized to better match the requirements of the project.  This included changing header and footer sections in layout.cshtml, as well as changing wordings and anchor tags in index.cshtml.  The presentation layer required a create ticket button, and the ability to view tickets which has been setup, but nothing is being displayed because there is no connection to a database and no Ticket object created yet, next was to start working on the Domain Layer.
To implement Ticket objects, I created a Models folder in the project which will be used with EF Core to both create the objects, output them to the presentation layer, and communicate with the database.  Here is the Ticket class, as you can see it covers the requirements and has a primary key, ID, as well as public attributes Name, ProblemDescription, and SubmittedDate.

```
namespace TitanHelpFinal.Models
public class Ticket
{
  public int ID { get; set; }
  public string Name { get; set; }
  public string ProblemDescription { get; set; }
  public DateTime SubmittedDate { get; set; }
}
```

Once this Ticket.cs template has been created, I needed to “scaffold” the Ticket object to display its contents and be able to update them.  I used ASP.NET Core scaffolding tool to create a EntityFramework DbContext class, as well as create CRUD (Create, Read, Update, and Delete) functions for the Ticket objects.  To scaffold my Ticket object, I had to first install the required NuGet packages:

```
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
```
Once these packages were installed, I was able to run the following command to create the CRUD features, index.cshtml in the Ticket folder, to view the tickets, and a database connection string which will connect the Domain Layer to the Data Access Layer.  In appsettings.json I added the following line to connect it to a local database:
```
"ConnectionStrings": {
  "TicketContextSQLite": "Data Source=CU.db"
}
```
This means that the TicketContext, or the bridge between the Database and Domain Layer will initially pull and ultimately update/push the CU.db file.  I also had to update the database context class, so I changed the class to store the list of Tickets using the following code:
```
public DbSet<Ticket> Tickets { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
  modelBuilder.Entity<Ticket>().ToTable("Ticket");
}
```
Next, I wanted to populate the database temporarily to test the CRUD functions.  To do this I created DbInitializer.cs which populates the CU.db database only if it is empty, this ensures that on the first launch it will have Tickets but if I change them and rebuild the application, the database will remain the same and not get rebuilt.  This is done though the following line:
```
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<TicketContext>();
  context.Database.EnsureCreated();
  DbInitializer.Initialize(context);
}
```
After this, I was able to test the functionalities of the CRUD functions using the project itself, and DB Browser, an application that can read local .db files.  Lastly, I changed some of the boilerplate code to better reflect a Ticket system and removed unnecessary text.  I also corrected the links in the navbar to send the user to Tickets/Index and Tickets/Create.  I believe this project achieved what was assigned and shows understanding of different frameworks such as Razor and EF Core. 

### Explanation of how the project showcases understanding and mastery of the subject matter, including frameworks and design patterns utilized.
The project showcases understanding and mastery of the subject matter because it uses Razor for the Presentation layer, built in classes created using aspnet-code-generator for the Domain Layer, and EF Core for the Data Access Layer.  This involves a three-tiered system where one of the tiers can be replaced, and the others will not be affected.
### Inclusion of status reports, design documents, and major decision rationale.
Honestly, there was no major comparing and contrasting between different framework options.  I chose to do Razor because it reminded me of React.js which I am already familiar with.  It is similar in the way that components are stored in separate files.  The folder layout is slightly different, and the files are cshtml files instead of JSX files, but this framework worked well with EF Core, and I was able to find the most documentation regarding Razor and EF Core, and not React.js and EF Core.  As far as design documentation, the application had a set style using tag styles in cshtml code, up until the last couple of commits.

![homepage2](https://github.com/user-attachments/assets/34e63780-77d3-4863-973e-cd6bac6c1989)

![viewpage2](https://github.com/user-attachments/assets/f60f6344-bbad-4c94-9999-e76900dac6fd)

![createticket3](https://github.com/user-attachments/assets/17c7e1b2-6dd0-4438-a19a-a4766b9ec497)

 
Lastly, I updated the styling and tried designing the website to look like an official SPC website.  I took the colors from SPC websites, added my own CSS, and removed some class names that had been assigned from asp-code-generator.   The final product:

![finalstyling](https://github.com/user-attachments/assets/992d4938-bf4e-485e-97f5-2659ec53b1eb)

![finalstylingg](https://github.com/user-attachments/assets/a7f8e56a-cb08-419b-980e-46f2274ff069)

![finalstylinggg](https://github.com/user-attachments/assets/3cd3f48a-4aca-47f0-a881-bd3911cfb4d9)

### Provision of user documentation detailing program operation and input files.
Input files are not required, if there is no database, one will be created.
#### How to add a Ticket:
-	Click Create New Ticket at the top of the screen, fill in the required fields, and press create.
#### How to view all Tickets:
-	Click View/Edit Tickets at the top of the screen, from here you can view and edit Tickets.
#### How to Delete a Ticket:
-	From the View/Edit Tickets screen, then click delete next to the ticket you would like to delete.  This will take you to the delete screen where you will be able to see the full ticket and delete it.
#### How to Edit a Ticket:
-	From the View/Edit Tickets screen, then click edit next to the ticket you would like to edit.  This will take you to the edit screen where you will be able to change Ticket information.
#### Evaluation of the final project, highlighting strengths, weaknesses, and areas for improvement.
To evaluate the final project, it is strong in the sense that it interacts with a locally stored database, creates one if one does not exist, and is easily modifiable through Razor.  It is weak in the sense that the CRUD functions are not asynchronous, which could cause performance errors at a larger scale.  There are workarounds to this using Razor, I just did not implement them in my project because of the time needed, and it felt unnecessary when this application is being run locally on my computer.  If this application was used for TitanHelp, I would take some precautions such as replacing “FirstOrDefaultAsync” with “FindAsync” when related data is not necessary.  Lastly, this project can be improved at both the back end with performance time, and the front end with better CSS.

## Individual Section:
### Each group member writes a section reflecting on the project and personal understanding of the subject matter.
I feel that there are sufficient responses in the group section that answer the same prompt, but to briefly reiterate, because of this project I have gotten a better understanding of the three layers and how to create an application using Razor and EF Core.
### Evaluation of the project from the individual's perspective, possibly differing from the group evaluation.
This is the same evaluation as in the Group Section, it did not change.
### Discussion of lessons learned from the course, emphasizing practical insights and real-life applications.
The lessons from the course demonstrated to me how real-world applications are designed from the ground up, and it demonstrated the concepts used and decision making behind an applications structure.  This included multiple frameworks at each layer of an application, but I was primarily interested in JavaScript.  This project did not require much JavaScript, I believe React.js would have, however, I enjoyed learning how to implement C# with web development.  These lessons can and will be applied to real-life because I plan on pursuing a career in web development soon.  Having another framework in my programming toolbelt will improve my skill as a web developer.  More specifically, lessons learned from the course will help me understand common system architectures, design patterns, and test-driven development techniques.
