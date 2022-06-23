# ToyRobot
.NET 3.1 Console application

## Download source code
1. git clone https://github.com/rodel-p-ocfemia/ToyRobot

## Setup program using Visual Studio
1. Open ToyRobot\ToyRobot.sln
2. Once project is loaded in Visual Studio, Build and run the program.

## Setup program using console
1. Using command prompt, navigate to directory where ToyRobot.csproj is located. eg <download path>\ToyRobot\ToyRobot
2. Then type dotnet build
3. Once build is completed, type dotnet run


# ToyRobot Game instructions

## Commands accepted (not case sensitive):	
* PLACE X,Y,F	: put the Toy robot in the position X,Y and facing NORTH, SOUTH, EAST or WEST
* MOVE	    : move the toy robot one unit forward in the direction currently facing
* LEFT	    : rotate the toy robot 90 degrees to left
* RIGHT	    : rotate the toy robot 90 degrees to right
* REPORT	    : display the X,Y and F of the robot

## Constraints:	
* The Robot is free to roam around the surface table but must be prevented from falling.
* Any command that would cause the robot to fall must be ignored.
* First command should be PLACE. Discard all other commands until PLACE is executed.

## Examples:
1.
    PLACE 0,0,NORTH <br>
    MOVE <br>
    REPORT <br>
    Output: 0,1,NORTH <br>

2.
    PLACE 0,0,NORTH <br>
    LEFT <br>
    REPORT <br>
    Output: 0,0,WEST

3.
    PLACE 1,2,EAST <br>
    MOVE <br>
    MOVE <br>
    LEFT <br>
    MOVE <br>
    REPORT <br>
    Output: 3,3,NORTH
