# 🌍 TripRoute - Travel Planning App

## 📌 About the Project

**TripRoute** is a travel planning application designed to help users plan and manage their trips efficiently. The app allows users to define destinations, choose transportation, lodging, and other travel services, optimizing the entire travel experience. The project follows best practices such as **SOLID**, **TDD**, and **Clean Architecture**, aiming to create a robust, scalable solution for travelers.

---

## 🛠️ Technologies Used

- **.NET Core** – Backend development
- **Entity Framework Core** – ORM for database access
- **SQL Server** – Database management system
- **Swagger** – API documentation
- **Microservices** – For scalable architecture (if applicable)
- **Clean Architecture** – For maintaining separation of concerns
- **SOLID Principles** – For writing maintainable and scalable code

---

## ⚙️ Setup Instructions

### 🔹 Step 1 – Clone the Repository

Clone this repository to your local machine using the following command:
git clone https://github.com/joaovtrsantos/TripRoute.git

## 🔹 Step 2 – Install Dependencies
Make sure you have Visual Studio and .NET Core SDK installed. You can get it from here.

Run the following command to restore the necessary NuGet packages:
dotnet restore

##🔹 Step 3 – Set Up the Database
Ensure you have SQL Server installed locally or use a cloud-based solution. Update the appsettings.json file with your database connection string.

##🔹 Step 4 – Apply Migrations
Run the following command to create the database and apply migrations:
dotnet ef database update

🚀 Using the Application
🔸 Create a Trip
Use the POST method on the /trips endpoint to create a new trip. Pass the necessary details such as destination, dates, and transportation options.

🔸 View All Trips
Use the GET method on the /trips endpoint to view all trips.

🔸 View Trip Details
Use the GET method on /trips/{id} to view the details of a specific trip by its ID.

🔸 Optimize the Travel Route
Use the GET method on /trips/optimize/{origin}/{destination} to get the optimized route for your trip. The app will suggest the best route based on distance, cost, and time.

🔧 Features
Trip Creation: Users can plan trips by selecting destinations, dates, and services.

Trip Optimization: The app suggests the most efficient travel routes and options.

Trip Details: Detailed information on transportation, lodging, and itineraries.

🧑‍💻 Running the Application Locally
Clone the repository to your machine.

Run the application using:
dotnet run

The app should be accessible via http://localhost:5000 (or the port defined in your configuration).

## 👨‍💻 Developed by

**João Vitor Santos**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-blue?logo=linkedin&style=for-the-badge)](https://www.linkedin.com/in/jo%C3%A3o-vitor-d-13032413b/)
[![GitHub](https://img.shields.io/badge/GitHub-black?logo=github&style=for-the-badge)](https://github.com/joaovtrsantos)
