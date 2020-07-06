# AcmeGames solution

## Backend

The backend application was built with .netcore 2.0.

### Project structure

Here are the main backend project files that contain application logic:
* AcmeGames
    * Controllers
    * Data
    * Domain
    * Extensions
    * Filters
    * Mapping

### Used 3th party components

| Components  | Reason |
| ----------- | ------ |
| AutoMapper  | AutoMapper used for getting rid of code that mapped one object to another. |
| MediatR     | Simple mediator implementation in .NET. MediatR is used to request\respones, commands\queries dispatching. |
| NSwag       | NSwag is used to generate OpenApi specification from existing controllers. |
| Swashbuckle | Swashbuckle is used to build a slick discovery UI for API. |

### How to run backend application

Open AcmeGames.sln with Visual Studio 2017 or higher or with Rider IDE. Build and the  run solution into IDE.

After the run you can navigate to http://localhost:56654/swagger to see Swagger UI of AcmeGames API.

## Frontend

The frontend application was built with Angular framework.

### Project structure

Each feature has it's own folder (game, login, etc.), other shared/common code such as services, models, helpers etc are placed in folders with same names to group them together at the top of the folder structure.

Frontend application located into ```AcmeGames\app``` folder. Here are the main frontend project files that contains application logic:

* src
    * app
        * components
            * account
                * account.component.ts
            * admin
                * admin.component.ts
            * game
                * game.component.ts
            * login
                * login.component.ts
        * helpers
            * admin.guard.ts
            * auth.guard.ts
            * error.interceptor.ts
            * jwt.interceptor.ts
        * model
            * authData.ts
            * changeUserData.ts
            * game.ts
            * user.ts
        * services
            * auth.service.ts
            * game.service.ts
            * user.service.ts
        * validation
            * confirmedValidator.ts
* proxy.conf.json

### Auth Guard

The auth guard (```helpers/auth.guard.ts```) is an angular route guard that's used to prevent unauthenticated users from accessing restricted routes, it does this by implementing the CanActivate interface.

### Admin Guard

The admin guard (```helpers/admin.guard.ts```) is an angular route guard that's used to prevent authenticated users from accessing admin area, it does this by implementing the CanActivate interface and parsing jwt payload to get actual user role.

### Confirmed Validator

The confirmed validator (```validators/admin.confirmedValidator.ts```) is a function that's used to compare two field values on one form (password and confirm password).

### Backend proxy configuration

The proxy configuration file (```proxy.conf.json```) contains settings for backend proxy and solve cors requests without cors handling on the backend.

### How to run frontend application

1. Install Nodejs
2. Navigate to ```AcmeGames\app``` folder
3. Open your favourite terminal and type command
    ```
    npm install
    ```
4. Serve angular application by command
    ```
    ng serve --open
    ```
5. Now you can go to http://localhost:4200 to see the application

## What next

Here are several steps which are not implemented yet:
* Backend
    * Add unit tests
    * Move ```Data``` and ```Domain``` files to separate assemblies ```AcmeGames.Data``` and ```AcmeGames.Domain```
    * Produce some logging for better application behaviour understanding
    * Implement an access layer to the real database engine
* Frontend
    * Add unit tests
    * Implement the following features in the admin area:
        * Search for a specific user account.
	    * View and edit all details of a user account.
	    * Grant user ownership of a game, without the use of a key.
	    * Revoke a user's ownership of a game.