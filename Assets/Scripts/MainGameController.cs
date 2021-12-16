using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player
{
    string name;
    public Player(string name)
    {
        this.name = name;
    }
}
public class MainGameController : MonoBehaviour
{
    
    //Player A
    Player A = new Player("A");
    //Player B
    Player B =  new Player("B");
    //Holds the balls that A has to pocket
    ArrayList ballsToBePocketedByA = new ArrayList();
    //Holds the balls that B has to pocket
    ArrayList ballsToBePocketedByB = new ArrayList();
    //to check if the player continues to play
    bool playerContinuesPlay = false;
    
    public GameObject playerA;
    public GameObject playerB;

    //Stores the cue ball object
    public GameObject cueBall;
    //cue ball starting position
    Vector3 startingPositionCueBall = new Vector3(-2.6f,34.73f,20.4f);
    public string currentPlayerPlaying;

    //Storing the images for the score
    public Image b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b11,b12,b13,b14,b15;
    //Reference for game over text
    public Text GameOverText;
    //Reference for Player A and Player B Text
    public Text PlayerAText;
    public Text PlayerBText;

    //Referece to display the currentplayer playing text
    public Text currentPlayerText;
    //Reference for FaultText
    public Text faultText;

    //Reference for ready to play text
    public Text ReadyToPlayText;

    //Keeping track of the players score
    int PlayerAScore;
    int PlayerBScore;

    //A boolean to check if two or more balls are pocketed by the player in one hit
    //then if for example the first ball pocketed is not meant for the player
    //and the second ball pocketed is meant for him , then the playerContinuesPlay should be false
    //To achieve this behaviour this variable will be used.
    bool alreadyPocketedWrongBall = false;

    bool cueBallPocketed = false;
    //2D Camera
    public Camera CamForBallInHand;
    //Ball In Hand Script
    BallInHand ballInHandScript;
 
    //Storing Player A Camera
    public Camera playerACam;
    //Mouse move Script of Player A
    MouseMove mouseMoveScriptPlayerA;

    //Storing Player B Camera
    public Camera playerBCam;
    //MouseMove Script of Player B
    MouseMove mouseMoveScriptPlayerB;

    //Player move script of the players
    PlayerMove playerAMoveScript;
    PlayerMove playerBMoveScript;

    public Camera winningCam;

 
    // Start is called before the first frame update
    void Start()
    {
        //Camera for ball in hand is not enabled
        CamForBallInHand.enabled = false;
        //Getting the mouse move scripts of player A and player B
        mouseMoveScriptPlayerA = playerACam.GetComponent<MouseMove>();
        mouseMoveScriptPlayerB = playerBCam.GetComponent<MouseMove>();
        //Getting the player move scripts of player A and player B
        playerAMoveScript = playerA.GetComponent<PlayerMove>();
        playerBMoveScript = playerB.GetComponent<PlayerMove>();


        ballInHandScript = CamForBallInHand.GetComponent<BallInHand>();
        ballInHandScript.enabled = false; // CHANGE
        //Setting the players score to 0
        PlayerAScore = 0;
        PlayerBScore = 0;
        //Player A starts first
        playerA.SetActive(true);
        playerB.SetActive(false);
        //Setting current player playing 
        currentPlayerPlaying = "A";
        currentPlayerText.text = "Current Player : " + currentPlayerPlaying;
        //Adding the balls to be pocketed by each player
        //A should pocket the stripes 1-7
        //B should pocket the spots 9-15
        for(int i = 1; i <= 7; i++)
        {
            ballsToBePocketedByA.Add(i);
        }
        for(int i = 9; i <= 15; i++)
        {
            ballsToBePocketedByB.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If Escape is pressed
        if (Input.GetKeyDown("escape"))
        {
            //Quit Game And Go Back to main menu
            SceneManager.LoadScene(0);
            Destroy(GameObject.FindGameObjectWithTag("Audio"));
        }
    }
    //Called when ball is pocketed and collides with the plane under the table
    public void scoreTracker(int ballNumber)
    {
        //If ball number 8 is pocketed
        if(ballNumber == 8)
        {
            //If the player playing is A and if he has already collected his 7 balls
            //Then he wins else player B wins
            if (currentPlayerPlaying.Equals("A"))
            {
                if(PlayerAScore == 7)
                {
                    GameOverText.text = "PLAYER A WINS! PRESS ESC TO QUIT";
                }
                else
                {
                    GameOverText.text = "PLAYER B WINS! PRESS ESC TO QUIT";
                }
            }
            //Similarly if current Player playing is player B and he has collected 7 balls he wins
            // Else player A winsS
            else if (currentPlayerPlaying.Equals("B"))
            {
                if(PlayerBScore == 7)
                {
                    GameOverText.text = "PLAYER B WINS! PRESS ESC TO QUIT";
                }
                else
                {
                    GameOverText.text = "PLAYER A WINS! PRESS ESC TO QUIT";
                }
            }
            playerA.SetActive(false);
            playerB.SetActive(false);
            ReadyToPlayText.text = "";
            currentPlayerText.text = "";
            winningCam.enabled = true;
            return;
        }
        //else disable the ball and increase the players score
            switch (ballNumber)
            {
                case 1: b1.enabled = false; PlayerAScore++;SetPlayerAText(); break;
                case 2: b2.enabled = false; PlayerAScore++; SetPlayerAText(); break;
                case 3: b3.enabled = false; PlayerAScore++; SetPlayerAText(); break;
                case 4: b4.enabled = false; PlayerAScore++; SetPlayerAText(); break;
                case 5: b5.enabled = false; PlayerAScore++; SetPlayerAText(); break;
                case 6: b6.enabled = false; PlayerAScore++; SetPlayerAText(); break;
                case 7: b7.enabled = false; PlayerAScore++; SetPlayerAText(); break;
                case 9: b9.enabled = false; PlayerBScore++; SetPlayerBText(); break;
                case 10: b10.enabled = false; PlayerBScore++; SetPlayerBText(); break;
                case 11: b11.enabled = false; PlayerBScore++; SetPlayerBText(); break;
                case 12: b12.enabled = false; PlayerBScore++; SetPlayerBText(); break;
                case 13: b13.enabled = false; PlayerBScore++; SetPlayerBText(); break;
                case 14: b14.enabled = false; PlayerBScore++; SetPlayerBText(); break;
                case 15: b15.enabled = false; PlayerBScore++; SetPlayerBText(); break;

            }
        
    }
    void SetPlayerAText()
    {
        PlayerAText.text = "PLAYER A SCORE : " + PlayerAScore;
    }
    void SetPlayerBText()
    {
        PlayerBText.text = "PLAYER B SCORE : " + PlayerBScore;
    }
    //To set if the playerContinuesPlay
    public void ballPocketed(int ballNumber)
    {

        
        Debug.Log("BALL POCKETED :Controller Ball pocketed : " + ballNumber);
        //Resetting cue ball position if it is pocketed
        //And returning, means playerContinuesPlay is set to false and the player is changed
        if(ballNumber == 0)
        {
            cueBall.transform.position = startingPositionCueBall;
            cueBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            cueBallPocketed = true;
            playerContinuesPlay = false;
            return;
        }
        // if cue ball has not been pocketed in this hit
        if (!cueBallPocketed)
        {
            //If current Player is PlayerA
            if (currentPlayerPlaying.Equals("A"))
            {
                //If he has pocketed a ball meant for him/her , which is Player A has pocketed balls 1-7then
                if (ballsToBePocketedByA.Contains(ballNumber))
                {
                    Debug.Log("BALL POCKETED : Player A Continues");
                    //Player Continues to play if he/she has not pocketed a wrong ball in this hit
                    if (!alreadyPocketedWrongBall)
                    {
                        playerContinuesPlay = true;
                    }
                    Debug.Log("BALL POCKETED : PLAYER CONTINUES PLAY : " + playerContinuesPlay);
                }
                //Else if he has pocketed a ball not meant for him/her, which is 9-15 for player A
                else
                {
                    Debug.Log("BALL POCKETED : Player A Does Not Continue");
                    //Player does not continue to play
                    playerContinuesPlay = false;
                    //the player has already pocketed the wrong ball
                    alreadyPocketedWrongBall = true;
                    Debug.Log("BALL POCKETED : PLAYER CONTINUES PLAY : " + playerContinuesPlay);
                }
            }
            //Similarly if current player playing is Player B
            if (currentPlayerPlaying.Equals("B"))
            {
                //If he/she has pocketed a ball meant for him/her , which 9-15 for player B
                if (ballsToBePocketedByB.Contains(ballNumber))
                {
                    Debug.Log("BALL POCKETED : Player B Continues");
                    //Player Continues to play if he/she has not pocketed a wrong ball in this hit
                    if (!alreadyPocketedWrongBall)
                    {
                        playerContinuesPlay = true;
                    }
                    Debug.Log("BALL POCKETED : PLAYER CONTINUES PLAY : " + playerContinuesPlay);
                }
                //else if he/She has pocketed a ball not meant for him/her , which is 1-7 for player A
                else
                {
                    //Player Does not continue to playe
                    Debug.Log("BALL POCKETED : Player B Does not continue");
                    playerContinuesPlay = false;
                    alreadyPocketedWrongBall = true;
                    Debug.Log("BALL POCKETED : PLAYER CONTINUES PLAY : " + playerContinuesPlay);
                }
            }
        }
    }
    public void SetCam()
    {
        Debug.Log("SET CAMERA START");
        //Setting the camera called 12 seconds after hit , from cueController class
        Debug.Log("SET CAMERA : Setting Cam");
        //If current player is PlayerA
        if (currentPlayerPlaying.Equals("A"))
        {
            Debug.Log("SET CAMERA IN IF 1");
            //If he/she does not continue to play
            if (!playerContinuesPlay)
            {
                //Set current player to player B
                currentPlayerPlaying = "B";
                //Set current player text
                currentPlayerText.text = "Current Player : " + currentPlayerPlaying;
                //Changing the player
                playerA.SetActive(false);
                //CHANGE
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    playerB.SetActive(true);
                }
                else if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    singlePlayerMode_PlayerBCAM();
                }
            }
        }
        //Else if current player is playerB
        else if (currentPlayerPlaying.Equals("B"))
        {
            
            //if he/she does not continue to play
            if (!playerContinuesPlay)
            {
                
                //Set current player to player A
                currentPlayerPlaying = "A";
                //Set current player text
                currentPlayerText.text = "Current Player : " + currentPlayerPlaying;
                //Changing the player
                playerA.SetActive(true);
                //CHANGE
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    playerB.SetActive(false);
                }
                else if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    resetSinglePlayer_PlayerBCAM();
                }
            }
        }
        //If ball pocketed and multiplayer mode
        if (cueBallPocketed && SceneManager.GetActiveScene().buildIndex == 1)
        {
           
            if (currentPlayerPlaying.Equals("A"))
            {
                playerA.SetActive(false);
                ballInHandScript.enabled = true;
                CamForBallInHand.enabled = true;
                ReadyToPlayText.text = "Ball In Hand";
                //Debug.Log("Here Cue Ball Cam");
            }
            else if (currentPlayerPlaying.Equals("B"))
            {
                playerB.SetActive(false);
                ballInHandScript.enabled = true;
                CamForBallInHand.enabled = true;
                ReadyToPlayText.text = "Ball In Hand";
                //Debug.Log("Here Cue Ball Cam");
            }
        }
        //If cue ball pocketed and single player mode.
        else if(cueBallPocketed && SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (currentPlayerPlaying.Equals("A"))
            {
                playerA.SetActive(false);
                ballInHandScript.enabled = true;
                CamForBallInHand.enabled = true;
            }
            else if (currentPlayerPlaying.Equals("B"))
            {

                playerB.GetComponent<AIPlayerB>().ballInHand = true;

            }
        }
        //Resetting playerContinuesPlay  , and alreadyPocketedWrongBall
        playerContinuesPlay = false;
        alreadyPocketedWrongBall = false;
        cueBallPocketed = false;
        Debug.Log("SET CAMERA : Current Player Playing : " + currentPlayerPlaying);
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (currentPlayerPlaying.Equals("A"))
            {
                ReadyToPlayText.text = "Ready To Play";
            }
            else if (currentPlayerPlaying.Equals("B"))
            {
                ReadyToPlayText.text = "AI Playing";
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            ReadyToPlayText.text = "Ready To Play";
        }
        
    }

    public void fault()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || (SceneManager.GetActiveScene().buildIndex == 2 && currentPlayerPlaying.Equals("A")))
        {
            //Fault has occured the current player no longer continues to play
            playerContinuesPlay = false;
            //Displaying the fault Text
            StartCoroutine("setFaultText");
        }

    }
    
    IEnumerator setFaultText()
    {
       
        //Set fault text
        faultText.text = "FAULT";
        //Debug.Log("Here");
        //Freezing move movement
        mouseMoveScriptPlayerA.toFreezeMovement = true;
        
        //Freezing player movement
        playerAMoveScript.toFreezeMovement = true;

        //If in multiplayer
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            mouseMoveScriptPlayerB.toFreezeMovement = true;
            playerBMoveScript.toFreezeMovement = true;
        }

        //Wait for three seconds
        yield return new WaitForSeconds(5f);
        //Changing the camera , since the player will switch
        SetCam();
        //Mouse Movement allowed
        mouseMoveScriptPlayerA.toFreezeMovement = false;
        
        //Player Movement Allowed
        playerAMoveScript.toFreezeMovement = false;

        //If in multiplayer
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            mouseMoveScriptPlayerB.toFreezeMovement = false;
            playerBMoveScript.toFreezeMovement = false;
        }
        //Resetting the fault text;
        faultText.text = "";

    }
    //CHANGE
    public void singlePlayerMode_PlayerBCAM()
    {
        CamForBallInHand.enabled = true;
        ballInHandScript.enabled = false;
        playerB.SetActive(true);
        Rect rect1 = new Rect(0, 0f, 0.5f,1f);
        Rect rect2 = new Rect(0.5f, 0, 0.5f, 1f);
        playerBCam.rect = rect1;
        CamForBallInHand.rect = rect2;
    }
    //CHANGE
    public void resetSinglePlayer_PlayerBCAM()
    {
        playerBCam.rect = new Rect(0, 0, 1, 1);
        CamForBallInHand.rect = new Rect(0, 0, 1, 1);
        playerB.SetActive(false);
        CamForBallInHand.enabled = false;
    }

 

}
