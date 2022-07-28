# TestNorthwind is a REST API project with Database First and Authentication to our REST API with JWT token

  ## Project database
You have to run the sql file in sql Folder on your local sql server [Execute northwind on SQL SErver.sql]

  ## Import Package in Net Core Project
 #### 'Microsoft.EntityFrameworkCore.SqlServer'
 #### 'Microsoft.EntityFrameworkCore.Tools'
 #### 'Microsoft.VisualStudio.Web.CodeGeneration.Design'
 #### 'Swashbuckle.AspNetCore'
 #### 'Microsoft.ASPNETCore.Authentication.JwtBearer'
 #### 'Microsoft.AspNetCore.Identity.EntityFrameworkCore'
 #### 'Microsoft.AspNetCore.Identity.UI'

  ## Reconfigure your database connection
  Reconfigure your connection to the database in the [appsettings.json]
  ####  'DataConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=True;',
  ####  'UserConnection": "Server=(localdb)\\MSSQLLocalDB;Database=NorthwindwithLogin;Trusted_Connection=True;MultipleActiveResultSets=true;'
    -where your "Server" is equal to the name of your server
    -and "Database" is equal to the name of your database "Northwind"
    I have two connections, one to the Northwind data app and another for authentication issues
    
 ## migrate the users database 
 You need to migrate the users database NorthwindwithLogin for that
 Since you use several contexts, you must specify the context that inherits from IdentityBdContext
  ####  Add-Migration "InitialCreate" -Context "ApplicationDbContext"




