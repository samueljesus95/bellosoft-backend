# Bellosoft Movie API

## Project Overview

Bellosoft Movie API is a RESTful ASP.NET Core Web API that provides endpoints to search, list, and retrieve details about movies using data from [The Movie Database (TMDB)](https://www.themoviedb.org/documentation/api).  
The API exposes endpoints for:
- Listing popular movies
- Searching movies by name
- Retrieving detailed information for a specific movie

All movie data is fetched in real-time from TMDB, and the API is designed for easy integration with front-end applications or other services.

---

## Setup Instructions

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [TMDB API Key](https://www.themoviedb.org/settings/api)
- (Optional) [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Configuration

1. **Clone the repository:**
2. git clone [<bellosoft-backend>](https://github.com/samueljesus95/bellosoft-backend.git)
2. **Configure your TMDB API Key:**

   Create a file named `appsettings.Development.json` in the `bellosoft.API` project folder (do not commit this file):
   { "TMDB": { "ApiKey": "YOUR_TMDB_API_KEY", "BaseUrl": "https://api.themoviedb.org/3/" } }
   
Alternatively, set the following environment variables:
   - `TMDB__ApiKey`
   - `TMDB__BaseUrl`

3. **Restore dependencies:**
   dotnet restore
4. **Run the API:**
   dotnet run --project bellosoft.API
5. **Access Swagger UI:**
   Open [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html) (or the port shown in your console) to explore and test the API endpoints.

---

## Third-party API Documentation

- [TMDB API Documentation](https://developer.themoviedb.org/docs)

---

## .gitignore for Sensitive Data

**Add the following lines to your `.gitignore` to prevent sensitive data and user secrets from being committed:**
# User secrets
secrets.json
# Local app settings
appsettings.Development.json appsettings.*.local.json
# VS/JetBrains/OS generated files
.vs/ *.user *.suo *.userosscache *.sln.docstates .idea/ *.swp


---

## License

This project is for demonstration purposes. Please refer to the TMDB API terms of use for any production or commercial usage.
