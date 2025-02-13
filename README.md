Before running the project, ensure the database is created.
The default database name is basiccrud, and PostgreSQL is being used.

### Data Migration
Open the project in Visual Studio, VS Code, or Rider (Visual Studio is recommended).

If you're using Visual Studio, open the Package Manager Console, then type the following command to create the migration folder:
`Add-Migration` 
then Press Enter.

Once the migration completes without errors, run the following command to update the database:
`Update-Database` 
then Press Enter.

After completing the migration, the tables and seeded data should be in place. Verify this by checking the database directly.

### Running the Project
Click the Play button to start the project (**https**).

The Swagger UI should open automatically. You can use this interface to test the API, or alternatively, use Postman.  
     
