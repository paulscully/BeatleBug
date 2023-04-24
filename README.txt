The BugTracker Application uses a .NET 7 API and a Blazor Web Assembly Front End

The choice behind the FE was purely because it was something I hadn't used before and wanted to learn and try out.

I have added Authentication using JWT, although most of the API's and the FE do not require authentication, there is only
one page which requires authentication, which is "Create Bug" and this is not fully implemented in the FE, but is used as 
a demo of Authentication.

It is possible to Register and Login as a User anyway and Logout again.

If you wish to Create more bugs, these can be added through the API using Swagger or Postman using the POST. There are 4 
other API's (all GET) that are currently used as part of the BugController, 

1. Get a list of bugs for a bug Status type (used to populate the bugs list from the drop down)
2. Get The list of bug status' and descriptions, used to populate the dropdown
3. Get a similar list for bug severity
4. Get a single bug using a bugId

There are also 2 User API's.

A next stage of this would be to add authentication to other pages and to select from actual users in the database when
assigning or creating bugs through the FE. As this is only performed through the API at the moment, it uses simple strings

There is a single simple Unit Test to demonstrate the use of Unit Testing in the Application.

Errors are handled where possible, although there is no time to add extensive error handling and not enough time to add
logging.


Running the application

Extract the Zip file, open the Solution in Visual Studio 2022
Install the database locally

Build the Application, this should now be ready to run

To run the Application both BeatleBug.WebApi and BeatleBug.Web.Client must be run at the same time. These projects should be
authomatically set to do this. The API can obviously be tested without the FE, but the FE will not work without the API.

This uses a local database stored in "Data Source=(localdb)\\MSSQLLocalDB" which is set in appsettings.json of BeatleBug.WebApi

The FE runs on port 7099 and the API's on port 7143, if there are any clashes, these should be updated in the code 
accordingly in the Program.cs file of the corresponding project.

