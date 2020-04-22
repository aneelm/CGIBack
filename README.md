# CGIBack for CGI Summer internship 2020
Backend MVC for a SPA which handles movie requests, processing and filtering.
Made using **ASP.NET** and **C#**.

## Running the project
The easiest way to just run the program, is using either Visual Studio Code or Visual Studio. 
That way you won't have to install Microsoft IIS or Microsoft Dev Server and it is much easier to just test it out.

1. Download/Clone the Project
2. Open it in VS Code or VS
3. Run Program.cs using either IDE
4. Localhost server should be running on https://localhost:5001/

## Structure

<img align="left" src="https://github.com/aneelm/images/blob/master/CGIInternship/backProjectStructure.png?raw=true">

**Controllers/MoviesController.cs** handles http requests made to different urls, sends it forward to a service and then responds with the correct information.
For example GET request to "Movies/Details/5" returns the movie with the id of 5, if it exists.

**Data/CategoryList.cs" and "Data/MoviesList.cs"** currently just holds the information about movies and categories, since there is not an actual database attached. These are **Hardcoded** lists of movie objects and category objects

**Dto/MovieDto.cs** is the "data transfer object" for Movie objects.

**Models/Category.cs and Models/Movie.cs** Category.cs is the category object class, which holds a category Id and Name, Movie.cs is the movie object class, which holds movie Id, Title, ReleaseDate, CategoryIds, Rating, Description

**Repositories/ICategoryRepository.cs and Repositories/IMovieRepository.cs** handle storing and sending objects to services.

**Services/ICategoryService.cs and Services/IMovieService.cs** handle filtering, searching, mapping etc. of objects gotten from a repository and send them forward to the controller class.

**Program.cs and Startup.cs** handle starting up the backend service and configuring everything correctly.
