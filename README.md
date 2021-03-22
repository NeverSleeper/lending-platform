# lending-platform
This is a coding challenge which I tried to resolve as best as I could in a given time frame.


# setup

The project itself needs only to be compiled and can be used right away. It will use an InMemory-Database so no database setup is needed.

To make testing easier, I provided in the main-folder a Postman-Collection which can be imported.

Just make sure you create an environment with the following values:

- Variable: "url"
- Initial Value: "https://localhost:5001"

# testing

To test the application I suggest the following order: 

1. Go into the Tests folder and start the requests "Create Projects", "Create Users"

2. Go into the Projects folder and try to fund the different projects, which will give you different responses

3. Go into the Users folder and look into the different users and see their values.


# additional notes

I tried to use Dependency Injection for the Context, but sadly could not resolve it.

Cause this is only a MVP there is no real UserManagement yet and authorization is not included yet. 

Unit tests would also be a big benefit so no manually testing is necessary which is only provided for the moment.

To use this in a productive system, authentication and of course user management would also be necessary. Also some functionality to create new projects and also much further details like banking and personal information from users and project owners with data encryption and so on. 
