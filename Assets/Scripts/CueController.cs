using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CueController : MonoBehaviour
{
    //0.04166667 ,272125 ,-0.749
    //Holds the Stick Game Object
    public GameObject Stick;
    //Hold the cueBall Game Object
    public GameObject cueBall;
    //Holds the minimum Distance between Stick and cue ball when aiming
    private float minDistance = 55.5388f;

    //Holds the maximum Distance between Stick and cue ball when aiming
    private float maxDistance = 68f;
    //Holds the cueDirection to move the stick towards or away from the cue ball
    private float cueDirection = -1;
    //Speed of movement by the stick
    private float speed = 20f;
    //amount of time the player aims this is equal to the power when hitting the cue ball
    int countMousePressed = 0;
    //to check if stick movement when hitting the cue ball is complete
    bool stickMovementComplete = false;

    //to check if a hit is done so that the reset can be done after a hit is done
    bool hitIsDone = false;
    //hold the position that the cue ball was in before making the shot
    Vector3 previousCueBall_position;
    //Holds reference to the controller game object.
    public GameObject controller;
    MainGameController control;
    //Storing the camera of the current player
    public Camera playerCam;
    //Move movement script
    MouseMove mouseMovementScript;

    //Storing the player object 
    public GameObject player;
    //PlayerMove script
    PlayerMove playerMoveScript;

    bool hitIsDoneForMovement = false;

    public Text ReadyToPlayText;
    // Start is called before the first frame update
    void Start()
    {
        //Initialising previous cue ball position as current position for the first shot
        previousCueBall_position = cueBall.transform.position;
        //getting reference to main game controller script to access its methods
        control = controller.GetComponent<MainGameController>();
        //Getting the mouse movement script for not allowing the script movement after hit
        mouseMovementScript = playerCam.GetComponent<MouseMove>();
        //Getting the player movement script for not allowing the player movement after hit
        playerMoveScript = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log("Stick Pos In Update : " + Stick.transform.position);
        Debug.Log("Cue Ball Pos In Update : " + cueBall.transform.position);
        Debug.Log("Distance in update " +Vector3.Distance(Stick.transform.position, cueBall.transform.position));*/
    }

    private void FixedUpdate()
    {
        //Stores the hit object
        RaycastHit hit;
        //Casting a ray from the cube in front of the stick 
        //Casting it in the y axis(0,1,0)
        //Distance of 20
        if (Physics.Raycast(transform.position, transform.up, out hit, 20))
        {
            //If the ray hits the cue ball that is if the stick is facing the cue ball
            //and the player has held the LMB

            if (hit.collider.gameObject.name == "CueBall" && Input.GetMouseButton(0) && hitIsDoneForMovement == false)
            {
                
                //Count mouse pressed to keep track of how long the user has held on to the key
                //More the count more the force by which the ball is hit
                countMousePressed++;
                //Getting the distance between the stick and the cue ball
                
                var distance = Vector3.Distance(Stick.transform.position, cueBall.transform.position);
                //Debug.Log("Stick : " + Stick.transform.position);
                //Debug.Log("Cue Ball : " + cueBall.transform.position);
                //Debug.Log("Distance Stick Aim" + distance);
                //If the distance is less than min distance or greater than max distance
                //Turn the cueDirection
                if (distance < minDistance || distance > maxDistance)
                {
                    cueDirection = cueDirection * -1;
                }

                //Move the stick back and forth to aim
                Stick.transform.Translate(Vector3.down * cueDirection * speed * Time.fixedDeltaTime);
                ////Stick.GetComponent<Rigidbody>().MovePosition(Stick.transform.position + (Vector3.down * cueDirection * speed * Time.fixedDeltaTime));
            }
            //If the ray hits the cue ball and the player releases the mouse
            if (hit.collider.gameObject.name == "CueBall" && Input.GetMouseButtonUp(0) && hitIsDoneForMovement == false)
            {

                //Getting the distance between the cue and the cueBall
                var distance = Vector3.Distance(Stick.transform.position, cueBall.transform.position);
                //while the stick movement is not complete
                while (!stickMovementComplete)
                {

                    //if the distance is greater than min Distance meaning the cue is back 
                    //minDistance is the distance where the cue is close to the cueBall
                    if (distance > minDistance)
                    {

                        //Move the stick forward towards the cueBall
                        Stick.transform.Translate(Vector3.down * -1);
                        ////Stick.GetComponent<Rigidbody>().MovePosition(Stick.transform.position + (Vector3.down * -1));
                        //Debug.Log(" : " + (Vector3.down * -1));
                        //Measure the distance again to update
                        distance = Vector3.Distance(Stick.transform.position, cueBall.transform.position);
                        //Debug.Log("Distance : " + distance);
                    }
                    //Once the stick reaches the cueBall
                    if (distance <= minDistance)
                    {

                        //stick movement is complete
                        stickMovementComplete = true;
                        //move the cue ball 
                        //storing the cue ball position before moving it
                        previousCueBall_position = cueBall.transform.position;
                        cueBall.GetComponent<Rigidbody>().AddForce(transform.up * speed * countMousePressed);
                        //Debug.Log("Force : " + speed * countMousePressed);
                        //hit is complete at this point
                        hitIsDone = true;
                        hitIsDoneForMovement = true;
                    }
                }
            }


        }
        //Reset for next shot
        if (hitIsDone)
        {
            Reset();
        }
    }
    private void Reset()
    {
        //Setting stick movement complete to false
        stickMovementComplete = false;
        //CountMousePressed to default of 0 
        countMousePressed = 0;
        Stick.transform.localPosition = new Vector3(0.0416f, -0.27f, -0.749f);
        //hit is done is set to false again 
        hitIsDone = false;

        //Setting the camera to switch player or to not switch player
        //Based on the ball being pocketed or not
        StartCoroutine("resetCam");
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CueBall")
        {
            Debug.Log("Hit");
        }
    }*/
    IEnumerator resetCam()
    {
        //Freezing the movement of the mouse till the balls pocketed are being checked
        mouseMovementScript.toFreezeMovement = true;
        //Freezing the movement of the player till the balls pocketed are being checked
        playerMoveScript.toFreezeMovement = true;

        ReadyToPlayText.text = "Calculating Pots";
        //Waiting for 12 seconds to detect whether a ball is pocketed or not
        yield return new WaitForSeconds(12f);
        //Setting the camera for chnaging the player or not
        control.SetCam();
        hitIsDoneForMovement = false;
        //Mouse Movement allowed now once the camera has been set
        mouseMovementScript.toFreezeMovement = false;
        //Player Movement allowed now once the camera has been set
        playerMoveScript.toFreezeMovement = false;
    }
}
