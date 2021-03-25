# Promo code management system

This is a promo code management system

## Installation and Setup Instructions

Clone this repository to your local computer.

### Open solution with Visual Studio 2019
Open the solution with Visual studio 2019 by double-clicking on "option-one.sln" file on the root of the folder. 
Optionally, open Visual Studio 2019. Then go to File -> Open -> Project/solution. Navigate to the root of the cloned folder and click on the "option-one.sln" file to open the solution.

### Setting up the database
Locate the appsettings.json file on the root of the directory. You will find the connection string to your database. Change the settings to suite your environment.

"ConnectionStrings": {
    "SQLConnection": "Data Source=xxxx;Initial Catalog=PromoCodesDB;Integrated Security=True"
  }, 

Open Package Manager Console by going to "Tools -> Nuget Package Manager -> Package Manager Console"

On the console, run the command "dotnet ef database update" to create the database structure and seed some dummy data.

### Start the system
To start the system, simply press F5 key on your keyboard or click on the green play button on your IDE to run the system.

### Access the application

The application should automatically launch.
If it doesn't, using your browser, visit [https://localhost:44377/]

