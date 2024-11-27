# Goal Flex - Server Side

## Description
Goal Flex is a fitness application designed to help users achieve their fitness goals by offering a customizable and interactive experience. Goal Flex is the fitness app for everyone! Whether you’re a frequent gym goer or just starting that new years resolution Goal Flex is here to help everyone stay on track and get fit!

## Table of Contents

- [Technologies](#technologies)
- [Get Started](#get-started)
- [API Endpoints](#api-endpoints)
- [Postman Documentation](#postman-documentation)
- [Video API Walkthrough](#video-api-walkthrough)
- [Contributors](#contributors)

## Technologies

- **Programming Language:** C#
- **Framework:** ASP.NET Core (.NET 8.0)
- **Object-Relational Mapper:** Entity Framework Core
- **Database:** PostgreSQL
- **Database Management Tool:** pgAdmin

## Get Started

#### For this project to run successfully, you'll need the following:

- Visual Studio
- .NET
- pgAdmin

Follow these steps to set up the **Fan Fusion API**:
#### 1. Fork and Clone the Repository
Fork the repository, then clone it to your local machine.

#### 2. Open in Visual Studio 2022
Open the solution file (`.sln`) in **Visual Studio 2022**.

#### 3. Restore Dependencies
Run the following command to restore project dependencies:

```bash
dotnet restore
```

#### 4. Configure User Secrets
Initialize user secrets and set your PostgreSQL connection string:

```bash
dotnet user-secrets init
dotnet user-secrets set "GoalFlexDbConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your-password>;Database=GoalFlex"
```
Replace `<your_postgresql_password>` with your actual database password.

#### 5. Apply Migrations and Create the Database
Run the following command to apply the existing migrations and create the database:

```bash
dotnet ef database update
```

#### 6. Start Debugging
Run the project in debug mode by selecting the **Start Debugging** option in Visual Studio. This will launch the API, and you can access Swagger to test the endpoints.

#### 7. Test the API
Use **Postman** or Swagger UI to interact with the API and test CRUD operations for books and authors.


## API Endpoints

### Category
| Method | Endpoint               | Description                |
|--------|------------------------|----------------------------|
| GET    | `/category`             | Retrieve all categories    |
| POST   | `/category`             | Create a new category      |
| PUT    | `/category/{categoryId}`| Update an existing category|
| DELETE | `/category/{categoryId}`| Delete a category          |

### Exercise
| Method | Endpoint               | Description                |
|--------|------------------------|----------------------------|
| GET    | `/exercise`             | Retrieve all exercises     |
| POST   | `/exercise`             | Create a new exercise      |
| GET    | `/exercise/{exerciseId}`| Retrieve a specific exercise|
| PUT    | `/exercise/{exerciseId}`| Update an existing exercise|
| DELETE | `/exercise/{exerciseId}`| Delete an exercise         |

### Meal
| Method | Endpoint               | Description                |
|--------|------------------------|----------------------------|
| GET    | `/meals`                | Retrieve all meals         |
| POST   | `/meals`                | Create a new meal          |
| GET    | `/meals/{mealId}`       | Retrieve a specific meal   |
| PUT    | `/meals/{mealId}`       | Update an existing meal    |
| DELETE | `/meals/{mealId}`       | Delete a meal              |

### User
| Method | Endpoint                   | Description                    |
|--------|----------------------------|--------------------------------|
| GET    | `/users/checkUser/{uid}`    | Check if the user is logged in |
| GET    | `/users/{userId}`           | Retrieve a specific user       |

### Workout
| Method | Endpoint               | Description                |
|--------|------------------------|----------------------------|
| GET    | `/workouts`             | Retrieve all workouts      |
| POST   | `/workouts`             | Create a new workout       |
| GET    | `/workouts/{workoutId}` | Retrieve a specific workout|
| PUT    | `/workouts/{workoutId}` | Update an existing workout |
| DELETE | `/workouts/{workoutId}` | Delete a workout           |

## Project Board
[Capstone Project Board](https://github.com/users/FletcherJMoore/projects/8)

## Project ERD
[Project ERD](https://dbdiagram.io/d/Capstone-ERD-672f8ca5e9daa85acae1ea3e)

## Postman Documentation
The API documentation is available in Postman, providing a detailed guide on how to interact with the Goal Flex Server Side.

- [Goal Flex Documentation](https://www.postman.com/gold-crescent-717386/goalflex/collection/4l7bkru/goal-flex-serverside)
- [Postman Documentation Walkthrough](https://www.loom.com/share/c26fa5dfd67d436da37dca5f164977f0?sid=70853725-860e-4547-b1e4-4b91240ec15c)

## Contributors

- [Fletcher Moore](https://github.com/FletcherJMoore)
