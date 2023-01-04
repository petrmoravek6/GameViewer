# GAME VIEWER SERVER

This is a server of Game Viewer application. 
### Configuration
For server ip/port configuration, see application.properties in *src/main*. For Postgress port configuration, see *docker.compose* file. NOTE: Autonomous testing uses in-memory database (see *src/test/application.properties).
### Run
Use **gradle bootBuildImage** command inside the server root folder which builds a Docker image containing both the server and Postgres DB. After that, use **docker compose up** command to run the image.<br /><br />
Default server port: 8080

## 1st control point
_Data diagram_ = diagram.png<br /><br />
_Advanced business operation_ = Creating match - this will require check whether all players selected to play in the match are from home team or away team and also special check if they are not too old to play there; each match has a seniority level (for example: 42 old man is not allowed to play kid's game)<br /><br />
_Complex query_ = "Find all teams that a specific player has won against"
