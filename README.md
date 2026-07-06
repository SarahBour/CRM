# CRM Web App  
## Description:  
This CRM web app is a group project that I contributed to, written in C#, HTML, and CSS using Razor Pages. The app focuses on customer management, interaction tracking, and user authentication. While the app is functional, the project is incomplete as it is based on my individual contributions.  

## Features  
👥 Customer Management: Add, view, edit, and delete customer records.  
📋 Interaction Tracking: Track customer interactions, including notes and contact details.  
🔐 User Authentication: Implemented login and registration functionality.  
✅ Admin Functions: Admin can approve or reject membership requests.  
💾 Database Integration: Integrated with MySQL via Entity Framework for persistent data storage.  
## Tech Stack 
🖥️ Backend: C# (.NET Core, Razor Pages)  
🌐 Frontend: HTML, CSS  
🗃️ Database: MySQL  
🔧 Tools: Visual Studio, PHPMyAdmin  
## Getting Started  
1️⃣ Clone the Repository  
```
git clone https://github.com/SarahBour/CRM.git
cd CRM
```
2️⃣ Set Up the Database  
To use the database, follow these steps:  

Import the SQL File:  

The database schema is exported from phpMyAdmin. Import the database.sql file into phpMyAdmin or another MySQL client.  
Update Connection Strings:  
In appsettings.json, configure the database connection string. The default string is:  

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost; Database=Culture2Geth; User ID=root; Password="
}
```   
Important:  

If you're using a different MySQL server, update the Server part.  
Set the correct password for your MySQL root user or any other database user you're using.  
If you face any issues with the password field being empty, simply add your MySQL password after Password= in the connection string.  

3️⃣ Install Dependencies   
Ensure you have all the required dependencies installed for the project. Open Visual Studio, then restore the NuGet packages. Alternatively, you can run:  

```
dotnet restore
```  
4️⃣ Running the Application  
Run the app locally by using Visual Studio or running the following command:  

```
dotnet run
```  
Visit http://localhost:5000 in your browser to view the app.  

Admin Functions  
To log in the admin's account and use its functions, enter the following credentials:  
⚠️ Demo credentials for evaluation purposes only — not tied to any real account


Email: admin@gmail.com  
Password: Password1!  
Login and Registration: Users can register and log in using a secure authentication system.  
Admin Approval and Rejection: The admin has the ability to approve or reject membership requests from users, providing control over who gets access to the system.  
Once logged in, the admin can view pending requests in the admin dashboard and make decisions regarding user access.  
5️⃣ Troubleshooting  
### 🛠️ Database Connection Issues:  
If you're having trouble with the database connection, make sure that MySQL is running, and check the username/password in the appsettings.json file.  
### 🚫 Missing Database Tables:  
If the tables are missing, re-import the SQL file from phpMyAdmin or your MySQL client.  
### 🔐 Admin Authentication Issues:  
Ensure you're using the correct admin credentials to access the admin dashboard and approve/reject users.  
## Limitations  
⚠️ This project is a work in progress and may have incomplete features due to being part of a group project. Some functionalities may not be fully integrated.  
## Contributions  
Feel free to fork the repository and contribute improvements! If you find any bugs or want to discuss ideas, please open an issue.    

🌟If you like this project don't forget to star ⭐ the repository!
