Movie Watchlist API

This repository contains an ASP.NET Core Web API implementation that allows users to search for movies and TV shows, add them to their personal watchlists, and mark movies as watched.

Features

Movie Search: The API provides a method to search for movies and TV shows by title, without requiring any user authentication.
Watchlist Management:
Users can add movies to their personal watchlist, identified by a unique UserId.
The API allows users to retrieve the list of all movies/TV shows in their watchlist.
Users can mark movies in their watchlist as "watched".
Technical Details
Framework: ASP.NET Core Web API
Validation: Fluent Validation is used for request model validation
Database: MS SQL Server, using EF Core with Code First approach and Migrations
Caching: In-memory caching is implemented for efficient movie/TV show search
Documentation: Swagger is used to generate and expose the API documentation
Messaging: MediatR is used for mediating between controllers and application services
Getting Started
Clone the repository: git clone https://github.com/NikolozKuridze/WatchlistAPI.git
Set up the database:
Create a new MS SQL Server database
Apply the database migrations using the EF Core CLI: dotnet ef database update
Build and run the project using your preferred method (e.g., dotnet run)
Explore the API documentation at http://localhost:<port>/swagger
