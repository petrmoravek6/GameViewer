# TJV

Repository of the semestral project of BI-TJV subject.
The subject is specialized for teaching the basis of Server x Client architecture. 

The application is called **Game Viewer** and servers as some kind of a football database, where users can display players, teams or games data, add new entites or update them. In the future it could be extended by statistics of the games or the players. Real life example can be www.livesport.com.

## Server

The server side is written in Java using Gradle technology. It uses PostgreSQL database and provides REST API to communicate and exchange information with the clients. The REST API is provided by the controllers.

![alt text](https://github.com/petrmoravek6/GameViewer/blob/main/server/architecture.PNG)

The server implements a 3 layer architecture (domain - business - dao). The design of domain layer models is captured below:

![alt text](https://github.com/petrmoravek6/GameViewer/blob/main/server/diagram.png)

## Client

The client is a desktop application written in C# using .NET 7 platform. I used WinForms technology for creating the GUI. The application is very simple and basically only allows the user to create, display and delete the application entites (games, players, teams) following the CRUD principle (Create, Read, Update, Delete).