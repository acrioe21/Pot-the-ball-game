using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BallInHand : MonoBehaviour
{
    //holds the cue ball
    public GameObject cueBall;
    //movement speed of the cue ball
    float movementSpeed = 10.0f;

    //Holds the controller gameobject
    public GameObject controller;
    //Main Game Controller script
    MainGameController control;
    //Holds the player A and player B GameObject
    public GameObject playerA;
    public GameObject playerB;

    //Holds the Parent Of The Balls To Pot GameObject
    public GameObject BallsToPot;
    //Holds the Rigidbody of all the Balls To Pot
    Rigidbody[] BallsToPotRB;
    //2D Camera for ball In Hand
    public Camera CamForBallInHand;

    public Text ReadyToPlayText;
    // Start is called before the first frame update
    void Awake()
    {
        //Getting the MainGameContoller script
        control = controller.GetComponent<MainGameController>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        BallsToPotRB = BallsToPot.GetComponentsInChildren<Rigidbody>();
        if (CamForBallInHand.isActiveAndEnabled)
        {
            Debug.Log("BALL IN HAND ");
            ReadyToPlayText.text = "Ball In Hand";
            //For all the Rigidbodies of the balls to pot (all balls except the cue ball)
            for(int i = 0; i < BallsToPotRB.Length; i++)
            {
                //Freeze all rotation and movements 
                //In order, not to allow the player to move the other balls with the cue ball
                BallsToPotRB[i].constraints = RigidbodyConstraints.FreezeAll;
            }
            Debug.Log("BALL IN HAND MOVEMENT");
            //Ball In Hand Allowing the player to move the ball
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //Setting the vector for movement
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            //Adding force to cueball 
            cueBall.GetComponent<Rigidbody>().AddForce(movement * movementSpeed);

            //Once the position of cueball is set and player hits enter
            if (Input.GetKey(KeyCode.Return))
            {
                //Allowing the other balls to move again 
                //No constraints on rotation and movement along any axis
                for(int i = 0; i < BallsToPotRB.Length; i++)
                {
                    BallsToPotRB[i].constraints = RigidbodyConstraints.None;
                }
                // if A is the current player playing set his camera active
                if (control.currentPlayerPlaying.Equals("A"))
                {
                    ReadyToPlayText.text = "Ready To Play";
                    this.enabled = false;
                    playerA.SetActive(true);
                }
                // else if B is the current player playing set his camera active
                else if (control.currentPlayerPlaying.Equals("B"))
                {
                    ReadyToPlayText.text = "Ready To Play";
                    this.enabled = false;
                    playerB.SetActive(true);
                   
                }
            }
        }


    }
}
