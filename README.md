![menupanel](https://github.com/nanalynh/DSP-lab/assets/114456930/f1ba0c18-b4f3-4fb5-bf7e-79036eb5b79f)






<!-- TABLE OF CONTENTS -->
# Table of contents 🧁:
1. [Introduction](#Introduction)
2. [Game](#Game)
3. [UML-class-diagram-and-explain](#UML-class-diagram-and-explain)
7. [References](#References)
<!-- <details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#Introduction">Introduction</a>
      <ul>
        <li><a href="#Team-members">Team Members</a></li>
	<li><a href="#task-allocation">Task Allocation</a></li>      
      </ul>
    </li>
    <li><a href="#technologies">Technologies</a></li>
    <li><a href="#uml-class-diagram">UML Class Diagram</a></li>
     <ul>
        <li><a href="#Control">Control</a></li>
	<li><a href="#Control button">Control button</a></li>
	<li><a href="# Sound Controns"> Sound Controns</a></li>
	<li><a href="#Model">Model</a></li>   
      </ul>
    <li><a href="#references">References</a></li>
  </ol>
</details> -->

<!-- ABOUT THE PROJECT -->

## Introduction <a name="Introduction"></a> 🔮:

<div align="center">
<img src="screenshots/Intro.gif" alt="">
</div>

<div style="text-align:justify">
This is our game project for our final lab in our Object-Oriented Programming course in semester 1 (2021 - 2022).The project is built entirely using available java libraries with graphics using Java Swing.
</div>

### Team Members :

| Order |         Name          |     ID      |            Email                         |                       Github account                        |     Lecture lab   |
| :---: | :-------------------: | :---------: | :--------------------------------------: | :---------------------------------------------------------: |:-----------------:|
|   1   | Nguyen Thi Thanh Thao | ITITIU20310 |ITITIU20310@student.hcmiu.edu.vn          | [thanhthao](https://github.com/nanalynh)                    | Mr. P. Q. S. Lam  |
|   2   | Trinh Thi Nhu Quynh   | ITITIU20291 |ititiu20291@student.hcmiu.edu.vn 	 | [nhu quynh](https://github.com/nhuquynh875) 	               | Mr. P. Q. S. Lam  |
|   3   | Ho Tu Quyen           | ITITIU19196 |ITITIU19196@student.hcmiu.edu.vn          | [Ho Tu Quyen](https://github.com/HoTuQuyen)                 | Mr. P. Q. S. Lam  |
|   4   |  Nguyen Huu Chau      | ITITIU20174 | ITITIU20174@student.hcmiu.edu.vn         | [Chau]( https://github.com/HChau1)                          ||Mr.Thanh          |



### Task Allocation 💁‍♀️_man:

| Order | Task                                                     |  Person   | 
| :---- | :------------------------------------------------------- | :-------: | 
| 1     |                   | nhu quynh |
| 2     |                                     | Thanh Thao|
| 3     |            | Tu Quyen  |
| 4     |                          | Huu Chau |


<!-- Game -->
<br />

## Game <a name="Game"></a>:joystick:
### Technologies :globe_with_meridians:

- Language: [C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)
- Framework: [Visual studio ](https://visualstudio.microsoft.com/)



### How to play ? 
Color Lines is a traditional puzzle game in which players must form lines of five or more balls of the same color on a grid-based board. After finishing a game, players are requested to enter their name into an option pane. After entering their name, a scoreboard appears, displaying the top players and their respective scores. The game starts with a randomized grid of colored balls, and players must move the balls intelligently to build lines.Players can make moves to create lines by selecting a ball and a target cell.When five or more balls of the same color form a line, those balls are removed from the board and points are awarded.
</div>

### Game logic :bulb:
To launch the game, open the project in your code editor, press Run. After that, the game will be launched.
<img width="517" alt="gamesceen" src="https://github.com/nanalynh/DSP-lab/assets/114456930/e413e1dd-98ce-4218-9c65-6bd110035372">
In the Game tab contains 4 options: three levels: easy, average, hard which help player choose level game, and 
Help, to instruct the game.
<img width="120" alt="level" src="https://github.com/nanalynh/DSP-lab/assets/114456930/d7aa0ecf-b55c-4cd2-97ac-d6c3d2b155a8">
We also help the information table so that players can login to play.
<img width="395" alt="infor" src="https://github.com/nhuquynh875/dsa_game-line/assets/114456930/4fc784bc-c0a4-4362-8968-d40e7c6fff6f">
Game over panel 
![Game over background](https://github.com/nhuquynh875/dsa_game-line/assets/114456930/b3fe4531-69e1-4b00-b83a-e48ebb35ca32)





## UML Class Diagram and explain <a name="UML-class-diagram and explain"></a>:
# Control 🦋:
 Class Diagram<br/>
<img width="358" alt="control" src="">
<br />
Container class: use the CardLayout in Jpanel lib.CardLayout class manages the components in such a manner that only one component is visible at a time and it treats each component as a card .
<br />
GameManager class:
Method readMap() help the computer can read, understand the map and set the location for the items on the map  in-game

Al(t) helps the boss automatically move 
-We have to edit the checkMoveBoom() ,moveBoss() ,checkBoomToBoss() ,checkBoomToBoom(),checkDieToBoss() in the Boss, Player and BomBang class. Instead of taking input from the keyboard, you will get the object's direction from the _ai attribute via the AI() function.Here we use the isEmpty() method which checks whether a string is empty or not (all the boss die or not).This myPlayerBoom() method allows the player to place bombs at any allowed location.
<br/>
*With AI the simplest is to go random, orient classes to return random values. Specifying the return integer value corresponding to which direction is up to you to decide in function initBoss().
<br/>
*In inititIterm()we set the update power items randomly after the object can destruct base the map on the mapIterm()
<br/>
PanelGame class:
The run() in PanelGame is controlled ANYA BOMBER base on input( Up, Down,Left, Right) from the keyboard, checking the conditions for placing bombs, including: whether to receive a bomb signal from the player ( _input. space ), the time between two bombs, it also directs the win panel and the game over panel when player lose or win.The try-catch statements in run() method handles any exceptions that may occur.The "thread.sleep" is to wait 20 ms before calling move so that all the objects are completely created.

# Control buttons 🎛️:
<br/>
Class Diagram:
<br/>
<img width="399" alt="controlbutton" src="https://user-images.githubusercontent.com/114456930/209488333-b53e755d-585c-4c52-80da-a5f116c146c1.png">
<br/>
This class presents the menu game with three buttons(Start, Help, Exit) for players to begin the games.The initComponents()will set the size, the location and add  images of button on menu background.The initListener() is used when player click any button and it work depend on the package  java.awt.event.ActionListener
ActionListener in Java is a class that is responsible for handling all action events such as when the user clicks on a component.For buttons Start to come to panel game,Help to come to the PanelHelp , Exit to exit of the game .

# Sound Controns 🔊:
Class Diagram:
<br/>
<img width="382" alt="sound" src="https://user-images.githubusercontent.com/114456930/209489361-0b6f0f04-425e-415b-8a7b-7cd75360265d.png">

<br/>Sound class: is control by class sound which can add sounds to the game, including background sounds and the sounds of in-game events (bombs exploding, characters dying, winning, eating items, etc.). Note that the background sound and the event are independent of each other, ie playing the event sound does not affect the background sound.

## Model 😊:
# Player class:
Class Diagram:<br/>




	


## References<a name="References">  :eye::tongue::eye:


<br />

<p align="right">(<a href="#top">Back to top</a>)</p>

