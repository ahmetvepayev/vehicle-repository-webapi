# Vehicle Repository WebAPI

## Architecture

+ The individual services were designed as close to the Clean Architecture conventions as possible
+ Client performs all the actions via communication with the web API
+ The web API communicates with the PostgreSQL server for all data related operations
+ The web API targets .NET 6


## Usage

You need to install [Docker Engine](https://docs.docker.com/engine/install/) and [Docker Compose](https://docs.docker.com/compose/install/). Check the required steps for installation specific to your platform. You also need the Docker Engine running before you proceed with the following steps:

+ Clone the repository or download the source code
+ Open a terminal window from the folder containing the ```docker-compose.yml``` file or navigate to that folder on your terminal
+ Execute ```docker-compose up -d``` to start the application. Docker will automatically download all the necessary files required for the application and will set up a separate container for the PostgreSQL server
+ When you're done with the application, execute ```docker-compose down --rmi all --volumes``` to shut down the containers and remove all files associated with the application

Alternatively, you can use any other PostgreSQL server instead of hosting it on a Docker container. You will probably need to change the connection string in [appsettings.json](/src/VehicleRepo.Api/appsettings.json) in case you opt to use a different server


## API

You can connect to ```http://localhost:15000/swagger``` from a web browser to see the API documentation. The application automatically seeds sample data into the database when first started, assuming the application starts in development environment. Below are some sample API responses for calls sent from Postman

![](https://i.imgur.com/WNRlgsC.png)

---
![](https://i.imgur.com/JM61Gb8.png)

---
![](https://i.imgur.com/xs2QVAB.png)

---
![](https://i.imgur.com/1nC8hdk.png)

---
![](https://i.imgur.com/CjnBKEE.png)

---
![](https://i.imgur.com/y1AWyhE.png)

---