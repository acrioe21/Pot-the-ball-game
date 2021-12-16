# Pot-the-ball-game

An 3D 8 Ball Pool game developed in Unity, It includes a single player version and an multi-player version.

•	A menu screen is shown to the user initially, to allow the user to select either Single Player Mode or the Multi Player Mode , Help (To show the user basic controls), Quit (To Allow the user to quit the game).

•	On Clicking the Single Player Mode, The game scene would be loaded showing the player empty room with a billiards table in the center of the room , The First Person Controller would be on with the stick in hand ready to hit the cue ball.

•	The Single Player Mode would indicate the two players at the top as a score card , Player A (which is the player controlled by the user) and Player B(which is the player coded (AI)) , and it would also indicate the balls to be pocketed by each player , typically Player A would have to pocket solids (1-7) and Player B will have to pocket the stripes (9-15) , A Ball Number 8 would be displayed at the top center indicating the importance of the 8th ball , The current player playing would be indicated below it , Below it the status would be indicated such as “Ready To Play” indicating that the player can play his shot, or “AI Playing” indication to the player that player B is playing now, or “Ball In Hand” indicating that the cue ball was pocketed in the previous shot so the other player has the cue ball in hand right now and can place it anywhere on the table. Also, a short message to quit the game using the Escape Key would be shown at the bottom left corner.

• In the case of Multi Player Mode, both the players would be controlled by the user (Assuming there are 2 people taking turns at the game).

•	The Player can move around the room using the Arrow Keys , or the WASD Keys as usual , In order to start the game , player A would be in control initially , The player can aim at the cue Ball which is the white ball , by moving around with the keys mentioned above and moving the mouse in different directions which would move the players camera , The cue stick is attached to the camera itself so it also moves with the camera , the player has to aim the stick at the cue Ball.

•	Subsequently the player has to hold on to the Left Mouse Button , in order to aim upon which the stick would move forward and back indicating the aim , The longer the Left Mouse Button Is Held the more the force into the shot.

•	On Releasing the Left Mouse Button the stick is fired towards the cue ball and quickly reset , upon which a force is added to the cue ball causing it to move in the direction aimed at(which is the direction the stick was facing or the tip of the stick is facing), After the hit the player’s movement’s freeze for about 12 seconds to calculate the number of balls pocketed by the player, at this moment the status would indicate “Calculating pots” telling the player to wait until the game calculates the balls which have been pocketed.

•	After the 12 seconds the game decides whether the player continues to play which is if the player has pocketed the balls meant for him and not pocketed the cue ball which is a foul , Or the player does not continue to play which is when the player has pocketed the balls not meant for him or has pocketed the cue ball which is a foul ,or has not pocketed any ball at all, the game changes the camera depending on whether the current player continues to play or not , If yes the camera is unchanged , if not the current player cameras is deactivated and the player B camera is activated.

•	For Ball In Hand the player would be shown a 2D view from the top of the table and the player can move the cue ball using the mouse keys, the other balls are frozen at this point so that the player cannot move the other balls using the cue ball, after the player is satisfied he/she can press enter and continue to play in 3D view.

•	After the conditions mentioned in the game summary are satisfied which is if a player pockets all the balls meant for him and also pockets the 8th ball before the opposition player , the player is declared as the winner and a win message is shown on the screen , along with asking the player to press the escape key to quit , and start playing again , Or if a player pockets the 8th ball before pocketing all the balls meant for him the opposite player is declared as the winner.
