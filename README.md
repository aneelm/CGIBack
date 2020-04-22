# CGIBack for CGI Summer internship 2020
Backend MVC for a SPA which handles movie requests, processing and filtering.
Made using **ASP.NET** and **C#**.

## Task completion assessment
### Data and business logic
#### 1. Create classes:
- [x] a) Movie [id, title, year, description, rating, category id]
- [x] b) Movies list **(Holds hardcoded list of movies)**
- [x] c) Category [id, name]
#### 2. Create Movie Repository class
- [x] a) Method, which returns a (hardcoded) list of movies.
- [x] b) Method, which returns a movie from the (hardcoded) list by id.
#### 3. Create Movie Service class 
**(Not sure if implemented correctly, my service class does request all the data from the repository, but you might have wished for something different. Either way, it should still work the same.**
- [x] a) List of movies (returns a list of movies from the Repository class method)
- [x] b) Chosen movie detailed info (returns a movie by id from the Repository class)
#### 4. Create MVC Controller, which returns information about movies
- [x] a) API method, which returns movie list
- [x] b) API method, which returns detailed movie info
#### Extras and/or changes

**1.1** Changed the Movie class from "int category id" to "List<int> category ids". My reasoning for that was because movies can have multiple categories and using only 1 category to classify it is too narrow.
  
**1.2** Created Category list class **(Holds hardcoded list of categories)**

**1.3** Created MovieDto class, which gets sent to the front end. Movies get mapped to MovieDto in the service class.

**2.1** Added additional methods to Movie Repository, which help in sorting by category, searching, mapping etc.

**2.2** Created category repository to deal with requests about categories.

**3.1** Created a category service class, which talks to the repository.

**4.1** Added additional method to the Movie Controller, which handles filtering and title search requests.

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
