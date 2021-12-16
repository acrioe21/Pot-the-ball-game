using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Class Ball Player B
public class BallPlayerB
{
    //Ball Game Object Which Can Be Pocketed By Player B
    GameObject Ball;

    //Holds the distance of the ball from the cueBall.
    float[] Distances_From_Pockets;

    //Holds the number of other balls between the ball and the pockets
    int[] number_of_Collisions_Between_Ball_Pockets;

    //Holds the pocket priorities which is desirable for this ball
    int[] Desirable_Pocket_Priorities;

    //Position cue ball needs to reach, to hit the ball to the pocker
    Vector3[] position_to_hit_into_pocket;

    //Other balls behind cue ball in the direction to hit to pocket the ball in a particular pocket
    int[] number_of_collisions_behind_cue_ball_in_hit_Direction;

    //Angle between the vector from cue ball to hit position and the vector from hit position to each pocket.
    float[] angle_between_cueBall_hitPosition_and_hitPosition_pocket;

    //Holds the number of balls between the ball desired hit position and the cue ball 
    //Except the balls which are belonging to the player B itself
    int[] number_Of_Collisions_Between_hitPosition_cueBall;

    //Holds the distance from the ball desired position to the cue ball
    float[] Distance_From_Cue_Ball_To_HitPosition;

    //True or false for each pocket, no collision between the ball and the pocket
    bool[] no_collision_ball_pockets;

    //True or false for each pocket, no collision behind cue ball in the direction to hit
    bool[] no_collision_behind_cue;

    //True or false for each pocket, the angle calculated above is below 125 degrees.
    bool[] angle_satisfied;

    //True or false for each pocket, no collision between hit position and the cue ball
    bool[] no_collision_hitPosition_cue;

    //Holds the deviaton from the desired properties mentioned above
    int[] deviation_collision_ball_pockets;
    int[] deviation_collision_behind_cue;
    float[] deviation_angle;
    int[] deviation_collision_hitPosition_cue;

    //Sums all the deviations for each pocket
    float[] sumOfDeviations;

    //Constructor
    public BallPlayerB()
    {
        Ball = null;
        Distances_From_Pockets = new float[6];
        number_of_Collisions_Between_Ball_Pockets = new int[6];
        Desirable_Pocket_Priorities = new int[6];
        position_to_hit_into_pocket = new Vector3[6];
        number_of_collisions_behind_cue_ball_in_hit_Direction = new int[6];
        angle_between_cueBall_hitPosition_and_hitPosition_pocket = new float[6];
        number_Of_Collisions_Between_hitPosition_cueBall = new int[6];

        Distance_From_Cue_Ball_To_HitPosition = new float[6];

        no_collision_ball_pockets = new bool[6];
        no_collision_behind_cue = new bool[6];
        angle_satisfied = new bool[6];
        no_collision_hitPosition_cue = new bool[6];

        deviation_collision_ball_pockets = new int[6];
        deviation_collision_behind_cue = new int[6];
        deviation_angle = new float[6];
        deviation_collision_hitPosition_cue = new int[6];

        sumOfDeviations = new float[6];
    }

    //Get and Set Methods
    public void SetBall(GameObject Ball)
    {
        this.Ball = Ball;
    }
    public GameObject GetBall()
    {
        return this.Ball;
    }
    public void Set_Distance_From_Pockets(float[] distance)
    {
        this.Distances_From_Pockets = distance;
    }
    public float[] Get_Distances_From_Pockets()
    {
        return Distances_From_Pockets;
    }
    
    public int[] Get_Desirable_Pocket_Priorities()
    {
        return Desirable_Pocket_Priorities;
    }

    public void Set_Desirable_Pocket_Priorities(int[] priorities)
    {
        Desirable_Pocket_Priorities = priorities;
    }

    public void Set_Distance_From_Cue_Ball_To_HitPosition(float[] distance)
    {
        this.Distance_From_Cue_Ball_To_HitPosition = distance;
    }

    public float[] Get_Distance_From_Cue_Ball_To_HitPosition()
    {
        return Distance_From_Cue_Ball_To_HitPosition;
    }

    public int[] Get_Number_Of_Collisions_Between_hitPosition_CueBall()
    {
        return number_Of_Collisions_Between_hitPosition_cueBall;
    }

    public void Set_Number_Of_Collisions_Between_hitPosition_CueBall(int[] num)
    {
        number_Of_Collisions_Between_hitPosition_cueBall = num;
    }

    public Vector3[] Get_Position_To_Hit_Into_Pocket()
    {
        return position_to_hit_into_pocket;
    }

    public void Set_Position_To_Hit_Into_Desired_Pocket(Vector3[] pos)
    {
        position_to_hit_into_pocket = pos;
    }

    public void Set_Number_Of_Collisions_Between_Ball_Pockets(int[] cols)
    {
        number_of_Collisions_Between_Ball_Pockets = cols;
    }

    public int[] Get_Number_Of_Collisions_Between_Ball_Pockets()
    {
        return number_of_Collisions_Between_Ball_Pockets;
    }

    public void Set_Number_Of_Collisions_Behind_Cue_Ball(int[] collisions)
    {
        number_of_collisions_behind_cue_ball_in_hit_Direction = collisions;
    }

    public int[] Get_Number_Of_Collisions_Behind_Cue_Ball()
    {
        return number_of_collisions_behind_cue_ball_in_hit_Direction;
    }

    public void setAngle(float[] angles)
    {
        angle_between_cueBall_hitPosition_and_hitPosition_pocket = angles;
    }
    public float[] getAngle()
    {
        return angle_between_cueBall_hitPosition_and_hitPosition_pocket;
    }

    public bool[] getCondition1()
    {
        return no_collision_ball_pockets;
    }
    public void setCondition1(bool[] cols)
    {
        no_collision_ball_pockets = cols;
    }

    public bool[] getCondition2()
    {
        return no_collision_behind_cue;
    }
    public void setCondition2(bool[] cols)
    {
        no_collision_behind_cue = cols;
    }

    public bool[] getCondition3()
    {
        return angle_satisfied;
    }
    public void setCondition3(bool[] angles)
    {
        angle_satisfied = angles;
    }

    public bool[] getCondition4()
    {
        return no_collision_hitPosition_cue;
    }
    public void setCondition4(bool[] cols)
    {
        no_collision_hitPosition_cue = cols;
    }

    public void setDeviation1(int[] devs)
    {
        deviation_collision_ball_pockets = devs;
    }
    public int[] getDeviation1()
    {
        return deviation_collision_ball_pockets;
    }
    public void setDeviation2(int[] devs)
    {
        deviation_collision_behind_cue = devs;
    }
    public int[] getDeviation2()
    {
        return deviation_collision_behind_cue;
    }
    public void setDeviation3(float[] devs)
    {
        deviation_angle = devs;
    }
    public float[] getDeviation3()
    {
        return deviation_angle;
    }
    public void setDeviation4(int[] devs)
    {
        deviation_collision_hitPosition_cue = devs;
    }
    public int[] getDeviation4()
    {
        return deviation_collision_hitPosition_cue;
    }

    public void setSumOfDeviations(float[] sum)
    {
        sumOfDeviations = sum;
    }
    public float[] getSumOfDeviations()
    {
        return sumOfDeviations;
    }



}
public class AIPlayerB : MonoBehaviour
{
    //Pockets or the holes on the table
    GameObject[] Pockets = new GameObject[6];

    //7 balls to be pocketed initially, will hold all the information regarding AI calculation
    BallPlayerB[] ballToPocketPlayerB = new BallPlayerB[7];

    //Gets the reference to access the Main Game Controller Script
    public GameObject controller;

    //Main game controller script
    MainGameController control;

    //Cue Ball Game Object
    public GameObject cueBall;

    //Desired Angle between cue ball hit position vector and hit position pocket vector
    const int DESIRED_ANGLE = 125;

    //If the ball and the pocket to hit are found
    bool ballPocketFound = false;

    //Selected ball index
    int SELECTED_BALL_INDEX;

    //Selected pocket index
    int SELECTED_POCKET_INDEX;

    //Reference to the nav mesh agent
    public NavMeshAgent agent;

    //Radius of the sphere ball game object
    float ballRadius;

    //Stick of the player B
    public GameObject Stick2;

    //Min Distance between stick and cue ball as in cue controller script
    float minDistance = 55.5388f;

    //Max Distance between stick and cue ball, when the stick is back
    float maxDistance = 68f;

    //cue direction
    float cueDirection = -1;

    //Speed of the stick movement when aiming
    int cueSpeed = 20;

    //whether the player has reached the position to hit
    bool playerInPosition = false;

    //elapsed time after agent starts moving, afterwhich to check if the player has stopped
    float elapsedTimeAferMovement = 0.0f;

    //whether the movement of the stick aiming is complete
    bool stickMovementComplete = false;

    //whether the hit is done
    bool hitComplete = false;

    //keeping in track of how long to aim for
    int countMousePressed = 0;

    //Whether stick is rotated slightly up, when moving since the stick might collide with the balls on the table
    bool StickUp = false;

    //To bring the stick back down.
    bool oneRoundStickUpComplete = false;

    //Reference to the ready to play text.
    public Text ReadyToPlayText;

    //Whether ball in hand is enabled
    public bool ballInHand = false;

    //Selected ball when in ball in hand
    int SELECTED_BALL_BALLINHAND;

    //Selected pocket when in ball in hand
    int SELECTED_POCKET_BALLINHAND;

    //whether the ball and pocket are found in the ball in hand view
    bool ballPocketFound_BALLINHAND = false;

    //Other balls to hold the other 15 balls except the cue ball
    public GameObject otherBalls;

    //Rigidbody of all the other balls
    Rigidbody[] otherBallsRB;

    //Elapsed time to enable rigidbody movement on other balls after the cue ball is 
    //placed properly in ball in hand view.
    float elapsedTime_After_Ball_In_Hand_Set = 0f;

    private void Awake()
    {
        //Get All GameObject with tag pocket and store it in the pockets array
        for (int i = 0; i < 6; i++)
        {
            Pockets[i] = GameObject.FindGameObjectWithTag("Pocket" + (i + 1));
        }

        //Disabling the mesh renderer and collider as the
        //player needs to see the holes on the table not the sphere
        foreach (GameObject pocket in Pockets)
        {
            pocket.GetComponent<MeshRenderer>().enabled = false;
            pocket.GetComponent<SphereCollider>().enabled = false;
        }

        //Get Main Game Controller Script from controller game object
        control = controller.GetComponent<MainGameController>();

        //Assign ball game objects to ballToPocketPlayerB objects array
        for (int i = 0; i < 7; i++)
        {
            ballToPocketPlayerB[i] = new BallPlayerB();
            string toFindBall = "Ball" + (i + 9);
            ballToPocketPlayerB[i].SetBall(GameObject.FindGameObjectWithTag(toFindBall));
        }

        //Radius of the ball gameobject set
        ballRadius = ballToPocketPlayerB[0].GetBall().GetComponent<SphereCollider>().radius;

        //Initial selected pocket and ball set to -1
        SELECTED_BALL_INDEX = -1;
        SELECTED_POCKET_INDEX = -1;

        //Initial selected ball and pocket when ball in hand set to -1 also
        SELECTED_BALL_BALLINHAND = -1;
        SELECTED_POCKET_BALLINHAND = -1;
    }
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        //If it's Player B's turn to play and hit is not yet complete, and ball is not in hand
        if (control.currentPlayerPlaying.Equals("B") && (!hitComplete) && (!ballInHand))
        {

            //If the selected ball and pocket are not found
            if (!ballPocketFound)
            {
                //Finding Distance From Each Pocket To Every Ball Which Player B Can Pocket
                find_Distance_From_Balls_To_Pockets();

                //Find number of other balls between ball and pockets
                find_number_of_collisions_between_ball_Pockets();

                //Make a priority array based on number of collisions
                assign_priorities_to_pockets();

                //Find Position To Hit Ball Into each Pocket, which is the position that the cueBall needs to reach(hit ppsition)
                find_position_to_hit_into_pockets();

                //check collisions behind cue ball in the vector from above, clear space to hit
                find_number_of_collisions_behind_cue_ball();

                //Find The Angle Between The Cue Ball To hit Position Vector and the hit position to pocket vector for each ball and each pocket
                find_angle_between_cueBall_hitPosition_and_hitPosition_pocket();

                //Distance from cue ball to hit position for each ball and each pocket
                find_Distance_From_hitPosition_to_Cue_Ball();

                //Find the number of other balls between hit position and cue ball for all balls and pockets
                find_Number_Of_Balls_Between_hitPosition_Cue_Ball();

                //Make Decision

                //Four Main Conditions 
                // Number Of collisions between ball and pocket should be 0
                // Number Of collisions behind cue ball in hit position should be 0
                // Angle should be < 125
                // Number of collisions between hit position and cue ball should be 0
                // All conditions are assesed for each ball and pocket and an array set to indicate whether the condition is satisfied or not for each ball.
                SetConditions();

                //Deviations are set for each ball and each pocket which is the difference
                //between the desired conditions above and actual values for all balls and pockets
                SetDeviations();

                //Summing all the deviations for each ball and each pocket and storing it in an array for each ball
                SumDeviations();


                //All Conditions True select the MIN ANGLE one
                for (int i = 0; i < ballToPocketPlayerB.Length; i++)
                {

                    for (int j = 0; j < Pockets.Length; j++)
                    {

                        if (ballToPocketPlayerB[i].getCondition1()[j] == true && ballToPocketPlayerB[i].getCondition2()[j] == true && ballToPocketPlayerB[i].getCondition3()[j] == true && ballToPocketPlayerB[i].getCondition4()[j] == true)
                        {
                            //If not even one selected yet
                            if (SELECTED_BALL_INDEX == -1 && SELECTED_POCKET_INDEX == -1)
                            {
                                SELECTED_BALL_INDEX = i;
                                SELECTED_POCKET_INDEX = j;
                            }
                            //Select the min angle
                            else if (ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_INDEX].getAngle()[SELECTED_POCKET_INDEX])
                            {                             
                                SELECTED_BALL_INDEX = i;
                                SELECTED_POCKET_INDEX = j;                           
                            }

                            //Selected ball and pocket found
                            ballPocketFound = true;
                        }

                    }
                }



                //Check Three Conditions ignoring condition 3, if none of the balls satisfy all conditions, Select min angle
                if (!ballPocketFound)
                {
                    for (int i = 0; i < ballToPocketPlayerB.Length; i++)
                    {
                        for (int j = 0; j < Pockets.Length; j++)
                        {
                            if (ballToPocketPlayerB[i].getCondition1()[j] == true && ballToPocketPlayerB[i].getCondition2()[j] == true && ballToPocketPlayerB[i].getCondition4()[j] == true)
                            {                             
                                if (SELECTED_BALL_INDEX == -1 && SELECTED_POCKET_INDEX == -1)
                                {
                                    
                                    SELECTED_BALL_INDEX = i;
                                    SELECTED_POCKET_INDEX = j;
                                }
                                else if (ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_INDEX].getAngle()[SELECTED_POCKET_INDEX])
                                {
                              
                                    SELECTED_BALL_INDEX = i;
                                    SELECTED_POCKET_INDEX = j;
                                    
                                }
                                //Ball and pocket to hit found
                                ballPocketFound = true;
                            }
                        }

                    }
                }


                //CHECK TWO CONDITIONS ignoring condition 3 and condition4 ,if none satisfied the above two, select Min Angle out of them
                if (!ballPocketFound)
                {
                    //Debug.Log("Two Entry");
                    for (int i = 0; i < ballToPocketPlayerB.Length; i++)
                    {
                        for (int j = 0; j < Pockets.Length; j++)
                        {
                            if (ballToPocketPlayerB[i].getCondition1()[j] == true && ballToPocketPlayerB[i].getCondition2()[j] == true)
                            {
                                
                                if (SELECTED_BALL_INDEX == -1 && SELECTED_POCKET_INDEX == -1)
                                {
                                    
                                    SELECTED_BALL_INDEX = i;
                                    SELECTED_POCKET_INDEX = j;
                                }
                                else if (ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_INDEX].getAngle()[SELECTED_POCKET_INDEX])
                                {
                                    
                                    
                                    SELECTED_BALL_INDEX = i;
                                    SELECTED_POCKET_INDEX = j;
                                    
                                }
                                ballPocketFound = true;
                            }
                        }

                    }
                }

                //If still not found, check only condition 2, select min angle if many satisfy this condition
                if (!ballPocketFound)
                {
                    for(int i = 0; i < ballToPocketPlayerB.Length; i++)
                    {
                        for(int j = 0; j < Pockets.Length; j++)
                        {
                            if(ballToPocketPlayerB[i].getCondition2()[j] == true)
                            {
                                if(SELECTED_BALL_INDEX == -1 && SELECTED_POCKET_INDEX == -1)
                                {
                                    SELECTED_BALL_INDEX = i;
                                    SELECTED_POCKET_INDEX = j;
                                }
                                else if(ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_INDEX].getAngle()[SELECTED_POCKET_INDEX])
                                {
                                    SELECTED_BALL_INDEX = i;
                                    SELECTED_POCKET_INDEX = j;
                                }
                                ballPocketFound = true;
                            }
                        }
                    }
                }

                //If none satisfied any of the conditions till now
                //Select the ball and pocket with minimum deviation
                if (!ballPocketFound)
                {
                    //Find min deviation
                    int[] temp = findMinDeviation();

                    //Assign selected ball and selected pocket from the array returned by the method
                    SELECTED_BALL_INDEX = temp[0];
                    SELECTED_POCKET_INDEX = temp[1];
                }
            }

            Debug.Log("Selected Ball : " + SELECTED_BALL_INDEX);
            Debug.Log("Selected Pocket : " + SELECTED_POCKET_INDEX);
          

            //Hit Position of the ball and pocket selected
            Vector3 hitPositionSelected = ballToPocketPlayerB[SELECTED_BALL_INDEX].Get_Position_To_Hit_Into_Pocket()[SELECTED_POCKET_INDEX];
            

            //Direction vector from hitposition to cue ball for finding out the players position to hit
            Vector3 Direction = new Vector3(cueBall.transform.position.x - hitPositionSelected.x, 0f, cueBall.transform.position.z - hitPositionSelected.z).normalized;
           

            //target position, from the cueball in the direction found above * 37 which is the distance found to be between player and cue ball when stick is close to the cue ball
            Vector3 target = new Vector3(cueBall.transform.position.x, 37.7f, cueBall.transform.position.z) + (Direction * 37);


            //If stick is not yet up
            if (!StickUp)
            {
                //Move Stick up before moving so it doesnt hit the balls on the table
                Stick2.transform.Rotate(new Vector3(5, 0, 0));

                StickUp = true;
            }

            //Set Destination of the agent
            agent.SetDestination(target);

            //elapsed Time
            elapsedTimeAferMovement += Time.fixedDeltaTime;

            //Check after 2 seconds, after the player starts moving whether the player has stopped
            if (agent.velocity == Vector3.zero && elapsedTimeAferMovement > 2.0f)
            {
                //If stick up and one round is of stick moving up and down again to hit is not complete
                if (StickUp && (!oneRoundStickUpComplete))
                {
                    //Move stick back down 
                    Stick2.transform.Rotate(new Vector3(-5, 0, 0));

                    oneRoundStickUpComplete = true;
                }

                //To look towards the cue ball
                Vector3 directionToLook = cueBall.transform.position- transform.position;

                //Look At the cue ball
                transform.rotation = Quaternion.LookRotation(directionToLook);
                transform.Rotate(new Vector3(0, -1, 0));

                //Player in position to hit
                playerInPosition = true;
            }

            //Vector from cue ball to hit position
            Vector3 directionCueBall = new Vector3(hitPositionSelected.x - cueBall.transform.position.x, 0f, hitPositionSelected.z - cueBall.transform.position.z);

            //Vector from ball to the pocket
            Vector3 ballPocket = new Vector3(Pockets[SELECTED_POCKET_INDEX].transform.position.x - ballToPocketPlayerB[SELECTED_BALL_INDEX].GetBall().transform.position.x, 0f, Pockets[SELECTED_POCKET_INDEX].transform.position.z - ballToPocketPlayerB[SELECTED_BALL_INDEX].GetBall().transform.position.z);
            
            //Number of times stick will move forward and backward
            //Set it relative to the distance between cue ball hitposition and ball pocket.
            int numberOfStickMovements = (int)(directionCueBall.magnitude + ballPocket.magnitude) * 10;

           
            //If player in position to hit , and stick movement for aim is not yet complete
            if (playerInPosition && (!stickMovementComplete))
            {
                //Increment countMousePressed
                countMousePressed++;

                //Same calulation as in cueContoller script to move stick back and forth
                var distance = Vector3.Distance(Stick2.transform.position, cueBall.transform.position);

                if (distance < minDistance || distance > maxDistance)
                {
                    cueDirection = cueDirection * -1;
                }
                Stick2.transform.Translate(Vector3.down * cueDirection * cueSpeed * Time.fixedDeltaTime);

                //Once the stick completed the movements exit
                if (countMousePressed >= numberOfStickMovements)
                {
                    stickMovementComplete = true;
                }

            }
            
            //If stick movement complete but hit is not yet done
            if (stickMovementComplete && (!hitComplete))
            {
                //Distance between stick and cue ball
                var distance = Vector3.Distance(Stick2.transform.position, cueBall.transform.position);

                //If stick is back, not close to the cue ball then
                if (distance > minDistance)
                {
                    //Move the stick forward towards the cue ball
                    Stick2.transform.Translate(Vector3.down * -1);
                }

                //Once stick is close to the cue ball
                if (distance < minDistance)
                { 
                    //Apply force to the cue ball in the directionCueBall
                    //Which is the direction from cue ball and hit position
                    //Where the cue ball needs to reach to pocket the ball,
                    //multiplied by magnitude(length) of ball pocket, vector from ball to the desired pocket
                    //ForceMode.Impulse to apply force depending on the mass

                    Vector3 force = directionCueBall * ballPocket.magnitude;

                    //if the force vector length is greater than 250.
                    //High force which means ball would fall off the table on collision with the edges
                    if (force.magnitude >= 250f)
                    {
                        //Normalize force vector and set its length to be 250.
                        force = force.normalized * 250f;
                        
                    }

                    //Similar in the negative axis
                    if (force.magnitude <= -250f)
                    {                   
                        force = force.normalized * 250f;               
                    }

                    //If force is less than 50 and greater than 0, which means force is too less
                    if(force.magnitude <= 50f && force.magnitude >= 0f)
                    {     
                        //Increase force vector's length to 50.
                        force = force.normalized * 50f;
                    }

                    //Similar in the negative axis
                    if(force.magnitude >= -50f && force.magnitude <= 0f)
                    {
                        force = force.normalized * 50f;
                    }
                   
                    //Adding Force
                    cueBall.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
                    
                    //Resetting the stick again
                    Stick2.transform.localPosition = new Vector3(0.0416f, -0.27f, -0.749f);

                    //Resetting count mouse pressed
                    countMousePressed = 0;

                    //Resetting elapsed time after movement
                    elapsedTimeAferMovement = 0;

                    //Resetting stick up bool
                    StickUp = false;

                    //Resetting one round stick up complete
                    oneRoundStickUpComplete = false;

                    //Resetting player in position to play
                    playerInPosition = false;

                    //Resetting selected ball index
                    SELECTED_BALL_INDEX = -1;

                    //Resetting selected pocket index
                    SELECTED_POCKET_INDEX = -1;

                    //Resetting ball pocket found
                    ballPocketFound = false;

                    //Resetting cue direction
                    cueDirection = -1;

                    //Resetting stick movement complete
                    stickMovementComplete = false;

                    //Hit is complete
                    hitComplete = true;
                }
            }

            //Once hit is complete
            if (hitComplete)
            {
                //Reset Camera to set player camera based on the balls pocketed
                StartCoroutine("resetCam");
            }

        }

        //If current player in B and ball is in hand
        if(control.currentPlayerPlaying.Equals("B") && ballInHand)
        {
            //If the selected ball and pocket are not yet found
            if (!ballPocketFound_BALLINHAND)
            {
                //Same calculations as in the non ball in hand case
                find_Distance_From_Balls_To_Pockets();
                find_number_of_collisions_between_ball_Pockets();
                assign_priorities_to_pockets();
                find_position_to_hit_into_pockets();
                find_number_of_collisions_behind_cue_ball();
                find_angle_between_cueBall_hitPosition_and_hitPosition_pocket();
                find_Distance_From_hitPosition_to_Cue_Ball();
                find_Number_Of_Balls_Between_hitPosition_Cue_Ball();
                SetConditions();
                SetDeviations();
                SumDeviations();

                for (int i = 0; i < ballToPocketPlayerB.Length; i++)
                {
                    for (int j = 0; j < Pockets.Length; j++)
                    {
                        if (ballToPocketPlayerB[i].getCondition1()[j] == true && ballToPocketPlayerB[i].getCondition2()[j] == true && ballToPocketPlayerB[i].getCondition3()[j] == true && ballToPocketPlayerB[i].getCondition4()[j] == true)
                        {
                            
                            if (SELECTED_BALL_BALLINHAND == -1 && SELECTED_POCKET_BALLINHAND == -1)
                            {
                                SELECTED_BALL_BALLINHAND = i;
                                SELECTED_POCKET_BALLINHAND = j;
                            }
                            else if (ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_BALLINHAND].getAngle()[SELECTED_POCKET_BALLINHAND])
                            {
                                SELECTED_BALL_BALLINHAND = i;
                                SELECTED_POCKET_BALLINHAND = j;
                            }
                            ballPocketFound_BALLINHAND = true;
                        }
                    }
                }

                if (!ballPocketFound_BALLINHAND)
                {
                    for (int i = 0; i < ballToPocketPlayerB.Length; i++)
                    {
                        for (int j = 0; j < Pockets.Length; j++)
                        {
                            if (ballToPocketPlayerB[i].getCondition1()[j] == true && ballToPocketPlayerB[i].getCondition2()[j] == true && ballToPocketPlayerB[i].getCondition4()[j] == true)
                            {
                               
                                if (SELECTED_BALL_BALLINHAND == -1 && SELECTED_POCKET_BALLINHAND == -1)
                                {
                                    SELECTED_BALL_BALLINHAND = i;
                                    SELECTED_POCKET_BALLINHAND = j;
                                }
                                else if (ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_BALLINHAND].getAngle()[SELECTED_POCKET_BALLINHAND])
                                {
                                    SELECTED_BALL_BALLINHAND = i;
                                    SELECTED_POCKET_BALLINHAND = j;
                                }
                                ballPocketFound_BALLINHAND = true;
                            }
                        }
                    }
                }

                if (!ballPocketFound_BALLINHAND)
                {
                    for (int i = 0; i < ballToPocketPlayerB.Length; i++)
                    {
                        for (int j = 0; j < Pockets.Length; j++)
                        {
                            if (ballToPocketPlayerB[i].getCondition1()[j] == true && ballToPocketPlayerB[i].getCondition2()[j] == true)
                            {
                                
                                if (SELECTED_BALL_BALLINHAND == -1 && SELECTED_POCKET_BALLINHAND == -1)
                                {
                                    SELECTED_BALL_BALLINHAND = i;
                                    SELECTED_POCKET_BALLINHAND = j;
                                }
                                else if (ballToPocketPlayerB[i].getAngle()[j] < ballToPocketPlayerB[SELECTED_BALL_BALLINHAND].getAngle()[SELECTED_POCKET_BALLINHAND])
                                {
                                    SELECTED_BALL_BALLINHAND = i;
                                    SELECTED_POCKET_BALLINHAND = j;
                                }
                                ballPocketFound_BALLINHAND = true;
                            }
                        }
                    }
                }

                if (!ballPocketFound_BALLINHAND)
                {
                    
                    int[] temp = new int[2];
                    temp = findMinDeviation();
                    SELECTED_BALL_BALLINHAND = temp[0];
                    SELECTED_POCKET_BALLINHAND = temp[1];
                }
            }

            Debug.Log("Ball In Hand : Selected Ball : " + SELECTED_BALL_BALLINHAND);
            Debug.Log("Ball In Hand : Selected Pocket : " + SELECTED_POCKET_BALLINHAND);

            //Hit Position, position where cue ball need to reach to pocket the ball
            Vector3 hitPosition = ballToPocketPlayerB[SELECTED_BALL_BALLINHAND].Get_Position_To_Hit_Into_Pocket()[SELECTED_POCKET_BALLINHAND];
            
            //vector from hit position to cue ball
            Vector3 hitPosition_To_CueBall = new Vector3(cueBall.transform.position.x - hitPosition.x, 0f, cueBall.transform.position.z - hitPosition.z).normalized;
            
            //Target position which is in the direction of hitposition to cue ball but 5 units away from the hit position.
            Vector3 targetPosition_CueBall = hitPosition + (hitPosition_To_CueBall * 5f);

            //Vector from cue ball to the target position
            Vector3 direction_cueBall_targetPosition = new Vector3(targetPosition_CueBall.x - cueBall.transform.position.x, 0f, targetPosition_CueBall.z - cueBall.transform.position.z);
            
            //If target position is not yet reached
            if(Vector3.Distance(targetPosition_CueBall,cueBall.transform.position) > 0)
            {
                //Freeze all the other balls
                //So that they do not move 
                otherBallsRB = otherBalls.GetComponentsInChildren<Rigidbody>();
                for(int i = 0; i < otherBallsRB.Length; i++)
                {
                    otherBallsRB[i].constraints = RigidbodyConstraints.FreezeAll;
                }

                //Move cue ball towards target position with speed of 20f.
                cueBall.transform.position = Vector3.MoveTowards(cueBall.transform.position, targetPosition_CueBall, cueSpeed * Time.fixedDeltaTime);
            }

            //If target position is reached
            if(Vector3.Distance(targetPosition_CueBall,cueBall.transform.position) <= 0)
            {
                //set cue ball velocity to 0, so it doesnt move anymore.
                cueBall.GetComponent<Rigidbody>().velocity = Vector3.zero;

                //Elapsed time
                elapsedTime_After_Ball_In_Hand_Set += Time.fixedDeltaTime;

                //After 3 seconds cue ball reached the position
                if (elapsedTime_After_Ball_In_Hand_Set >= 3f)
                {
                    //Reset other balls rigidbodies to allow movement
                    //that is set constraints to none from freezing all movement in all directions.
                    for (int i = 0; i < otherBallsRB.Length; i++)
                    {
                        otherBallsRB[i].constraints = RigidbodyConstraints.None;
                    }

                    //Resetting the variables.
                    ballPocketFound_BALLINHAND = false;
                    SELECTED_BALL_BALLINHAND = -1;
                    SELECTED_POCKET_BALLINHAND = -1;
                    elapsedTime_After_Ball_In_Hand_Set = 0f;
                    ballInHand = false;
                }
                
            }
        }

    }

    
    
    public void find_Distance_From_Balls_To_Pockets()
    {
        //Gets Distance from each ball to be pocketed by Player B
        //To each of the pocket and stores it in the distanceFromPockets array in
        //the respective array
        //Distance found only between X and Z positions
        //Since y axis doesnt matter in this case

        for (int i = 0; i < ballToPocketPlayerB.Length; i++)
        {
            float[] tempDistances = new float[6];
            for (int j = 0; j < Pockets.Length; j++)
            {

                Vector3 tempBall = new Vector3(ballToPocketPlayerB[i].GetBall().transform.position.x, 0f, ballToPocketPlayerB[i].GetBall().transform.position.z);
                Vector3 tempPocket = new Vector3(Pockets[j].transform.position.x, 0f, Pockets[j].transform.position.z);
                tempDistances[j] = Vector3.Distance(tempBall, tempPocket);
 
            }
            ballToPocketPlayerB[i].Set_Distance_From_Pockets(tempDistances);

        }
    }

    public void find_number_of_collisions_between_ball_Pockets()
    {
        foreach(BallPlayerB ball in ballToPocketPlayerB)
        {
            

            float[] distances = new float[6];
            distances = ball.Get_Distances_From_Pockets();
            //temp Array To Store The Collisions To Each Pocket
            int[] temp = new int[6];

            //For each Pocket
            for(int i = 0; i < Pockets.Length; i++)
            {
                

                //Direction to cast the ray in from the Pocket to the current ball object 
                Vector3 DirectionForRayCast = new Vector3(ball.GetBall().transform.position.x - Pockets[i].transform.position.x, 0f, ball.GetBall().transform.position.z - Pockets[i].transform.position.z).normalized;
                
                //To store the hit object 
                RaycastHit[] hits;

                //Drawing Line For Debugging Raycast
                //Pockets[i].GetComponent<LineRenderer>().SetPosition(0, Pockets[i].transform.position);

                //Cast the ray from pocket in the direction, max distance is the distance between pocket and ball.

                hits = Physics.SphereCastAll(Pockets[i].transform.position,ballRadius, DirectionForRayCast, distances[i]);
                //hits = Physics.RaycastAll(Pockets[i].transform.position, DirectionForRayCast, distances[i]);

                //Drawing Line For Debug
                //Vector3 toGoForLineCast = ((DirectionForRayCast * distances[i]) + Pockets[i].transform.position);
                //Pockets[i].GetComponent<LineRenderer>().SetPosition(1, toGoForLineCast);

                //count of number of collisions in between
                int count = 0;
                foreach (RaycastHit hit in hits)
                {
                    
                    //If any other ball in between the current ball and the pocket
                    if ((hit.collider.gameObject.name != ball.GetBall().name) && (hit.collider.gameObject.name != "CueBall") && (hit.collider.gameObject.name != "Table_Final") && (hit.collider.gameObject.name != "Table_Final") && (hit.collider.gameObject.name != "InnerWall1") && (hit.collider.gameObject.name != "InnerWall2") && (hit.collider.gameObject.name != "InnerWall3") && (hit.collider.gameObject.name != "InnerWall4") && (hit.collider.gameObject.name != "InnerWall5") && (hit.collider.gameObject.name != "InnerWall6") && (hit.collider.gameObject.name != "InnerWall1_1") && (hit.collider.gameObject.name != "InnerWall2_1") && (hit.collider.gameObject.name != "InnerWall3_1") && (hit.collider.gameObject.name != "InnerWall4_1") && (hit.collider.gameObject.name != "InnerWall5_1") && (hit.collider.gameObject.name != "InnerWall6_1") && (hit.collider.gameObject.name != "TopOfStick2") && (hit.collider.gameObject.name != "Stick2"))
                    {
                        
                        count++;
                    }
                }
                //Store the count in the temp array
                temp[i] = count;
                
            }
            //Assign temp array to the number of collisions array of the object
            ball.Set_Number_Of_Collisions_Between_Ball_Pockets(temp);
        }
            

            //Casting Ray from the Pocket closest to the ball,
            //In the direction of the ball
            //Till the distance it is away from the pocket
           

    }

    public void assign_priorities_to_pockets()
    {
        //Assigning priorities based on number of collisions between ball and pockets
        foreach(BallPlayerB ball in ballToPocketPlayerB)
        {
            //collision with each pocket
            int[] collisions = new int[6];
            collisions = ball.Get_Number_Of_Collisions_Between_Ball_Pockets();

            //Priorities Array
            int[] priorities = new int[6];

            //2D array to store pockets in first row and collisions in second row
            int[,] collisionsWithIndex = new int[2,6];

            //Initializing the 2D array values
            for(int i = 0; i < collisionsWithIndex.GetLength(1); i++)
            {
                collisionsWithIndex[0,i] = i;
                collisionsWithIndex[1, i] = collisions[i];
            }

            //Sorting the rows such that they are sorted as per the number of collisions
            //But the pockets also move along
            int temp;
            int temp2;
            for(int j = 0; j <= collisionsWithIndex.GetLength(1) - 2; j++)
            {
                for(int i = 0; i <= collisionsWithIndex.GetLength(1) - 2; i++)
                {
                    if(collisionsWithIndex[1,i] > collisionsWithIndex[1, i + 1])
                    {
                        temp = collisionsWithIndex[1, i + 1];
                        temp2 = collisionsWithIndex[0, i + 1];

                        collisionsWithIndex[1, i + 1] = collisionsWithIndex[1, i];
                        collisionsWithIndex[0, i + 1] = collisionsWithIndex[0, i];

                        collisionsWithIndex[1, i] = temp;
                        collisionsWithIndex[0, i] = temp2;
                    }
                }
            }

            //Assigning the priorites to the 1st row of 2D array, which are the pockets
            for(int i = 0; i < priorities.Length; i++)
            {
                priorities[i] = collisionsWithIndex[0, i];
            }
            
            //Setting the priorities
            ball.Set_Desirable_Pocket_Priorities(priorities);

        }
    }

    //Find desired position where cue ball needs to reach to hit the ball into the desired pocket
    public void find_position_to_hit_into_pockets()
    {
        //For each ball
        foreach(BallPlayerB ball in ballToPocketPlayerB)
        {
            Vector3[] tempPosition = new Vector3[6];
            for (int i = 0; i < Pockets.Length; i++)
            {

                //Direction from  the pocket to the ball
                Vector3 direction = new Vector3(ball.GetBall().transform.position.x - Pockets[i].transform.position.x, 0.0f, ball.GetBall().transform.position.z - Pockets[i].transform.position.z).normalized;

                //Get Diameter of the sphere game object
                float diameter = (ball.GetBall().GetComponent<SphereCollider>().radius) * 3.75f;

                //Desired pos is the direction + the current ball position + a 1,0,1 vector * diameter 
                Vector3 desiredPos = (direction * diameter) + ball.GetBall().transform.position;
                //Vector3 desiredPos = ((ball.GetBall().transform.position + direction + new Vector3(0.5f, 0f, 0.5f)) * diameter);
                tempPosition[i] = desiredPos;

            }
            ball.Set_Position_To_Hit_Into_Desired_Pocket(tempPosition);
        
           
        }
    }

    public void find_number_of_collisions_behind_cue_ball()
    {
        //for each ball
        foreach(BallPlayerB ball in ballToPocketPlayerB)
        {
            //Get position hit into each pocket
            Vector3[] tempDesiredPos = new Vector3[6];
            tempDesiredPos = ball.Get_Position_To_Hit_Into_Pocket();

            //temp array
            int[] tempCollisionsBehindCueBall = new int[6];

            //for each pocket
            for(int i = 0; i < tempDesiredPos.Length; i++)
            {
                //Direction for ray cast
                //From the position to hit to the cue ball
                Vector3 DirectionForRayCast = new Vector3(cueBall.transform.position.x - tempDesiredPos[i].x, 0f, cueBall.transform.position.z - tempDesiredPos[i].z).normalized;

                //cueBall.GetComponent<LineRenderer>().SetPosition(0, cueBall.transform.position);
               
                //To store the hits
                RaycastHit[] hits;

                //Radius of cue ball
                float cueBallRadius = cueBall.GetComponent<SphereCollider>().radius;

                //Cast a sphere from the cue ball in the direction 10 units back from the hit position direction.
                hits = Physics.SphereCastAll(cueBall.transform.position, cueBallRadius, DirectionForRayCast, 10);
                

                //Vector3 lineRenderer = (cueBall.transform.position + DirectionForRayCast * 10);
                //cueBall.GetComponent<LineRenderer>().SetPosition(1,lineRenderer);

                //Store count of hits
                int count = 0;
                foreach(RaycastHit hit in hits)
                {
                     //If not hit the table or the cue ball or the inner walls
                    if (hit.collider.gameObject.name != "Table_Final" && hit.collider.gameObject.name != "InnerWall1" && hit.collider.gameObject.name != "InnerWall2" && hit.collider.gameObject.name != "InnerWall3" && hit.collider.gameObject.name != "InnerWall4" && hit.collider.gameObject.name != "InnerWall5" && hit.collider.gameObject.name != "InnerWall6" && hit.collider.gameObject.name != ball.GetBall().name && hit.collider.gameObject.name != "CueBall" && hit.collider.gameObject.name != "InnerWall1_1" && hit.collider.gameObject.name != "InnerWall2_1" && hit.collider.gameObject.name != "InnerWall3_1" && hit.collider.gameObject.name != "InnerWall4_1" && hit.collider.gameObject.name != "InnerWall5_1" && hit.collider.gameObject.name != "InnerWall6_1" && hit.collider.gameObject.name != "TopOfStick2" && hit.collider.gameObject.name != "Stick2")
                    {
                        
                        count++;
                    }
                }
                //Store in temp array
                tempCollisionsBehindCueBall[i] = count;

            }
            //Assign into the main array for the object.
            ball.Set_Number_Of_Collisions_Behind_Cue_Ball(tempCollisionsBehindCueBall);
        }
    }

    public void find_angle_between_cueBall_hitPosition_and_hitPosition_pocket()
    {
        foreach(BallPlayerB ball in ballToPocketPlayerB)
        {
            Vector3[] tempDesiredPos = new Vector3[6];
            tempDesiredPos = ball.Get_Position_To_Hit_Into_Pocket();

            float[] tempAngles = new float[6];
            for(int i = 0; i < tempDesiredPos.Length; i++)
            {
                //Get Vector from cueBall to desired position
                Vector3 cueBallToHitPosition = new Vector3(tempDesiredPos[i].x - cueBall.transform.position.x, 0f, tempDesiredPos[i].z - cueBall.transform.position.z);

                //Get Vector from desired position to pocket 
                Vector3 HitPositionToPocket = new Vector3(Pockets[i].transform.position.x - tempDesiredPos[i].x, 0f, Pockets[i].transform.position.z - tempDesiredPos[i].z);

                float angle = Vector3.Angle(cueBallToHitPosition, HitPositionToPocket);
                tempAngles[i] = angle;
            }
            ball.setAngle(tempAngles);

        }
    }

    public void find_Distance_From_hitPosition_to_Cue_Ball()
    {
        Vector3 tempCueBall = new Vector3(cueBall.transform.position.x, 0f, cueBall.transform.position.z); 
        foreach(BallPlayerB ball in ballToPocketPlayerB)
            {
            Vector3[] tempDesirePos = new Vector3[6];
            tempDesirePos = ball.Get_Position_To_Hit_Into_Pocket();

            float[] tempDistances = new float[6];

            for(int i = 0; i < tempDesirePos.Length; i++)
            {
                Vector3 desiredPos = new Vector3(tempDesirePos[i].x, 0f, tempDesirePos[i].z);
                float Distance = Vector3.Distance(tempCueBall, desiredPos);
                tempDistances[i] = Distance;
            }

            ball.Set_Distance_From_Cue_Ball_To_HitPosition(tempDistances);
            }
    }

    public void find_Number_Of_Balls_Between_hitPosition_Cue_Ball()
    {
        foreach (BallPlayerB ball in ballToPocketPlayerB)
        {
            Vector3[] tempDesiredPos = new Vector3[6];
            tempDesiredPos = ball.Get_Position_To_Hit_Into_Pocket();

            int[] tempCollisions = new int[6];
            for(int i = 0; i < tempDesiredPos.Length; i++)
            {
                //Gets The Direction To Cast The Ray In, target - current
                Vector3 DirectionForRayCast = new Vector3(cueBall.transform.position.x - tempDesiredPos[i].x, 0f, cueBall.transform.position.z - tempDesiredPos[i].z).normalized;
                
                //To Store RayCast hits
                RaycastHit[] hits;

                // ball.GetBall().GetComponent<LineRenderer>().SetPosition(0, tempDesiredPos[i]);
                //Cast a ray, From the current ball, in the direction for raycast, max distance is the distance to the cue ball 
                float cueBallRadius = cueBall.GetComponent<SphereCollider>().radius;
                hits = Physics.SphereCastAll(tempDesiredPos[i], cueBallRadius, DirectionForRayCast, ball.Get_Distance_From_Cue_Ball_To_HitPosition()[i]);
               


               // Vector3 forLineDebug = ((DirectionForRayCast * ball.Get_Distance_From_Cue_Ball_To_HitPosition()[i]) + tempDesiredPos[i]);
               // ball.GetBall().GetComponent<LineRenderer>().SetPosition(1, forLineDebug);

                //Count to store the number of balls in between
                int count = 0;
                //for each hit
                foreach (RaycastHit hit in hits)
                {

                    if (hit.collider.gameObject.name != ball.GetBall().name && hit.collider.gameObject.name != "CueBall" && hit.collider.gameObject.name != "InnerWall1" && hit.collider.gameObject.name != "InnerWall2" && hit.collider.gameObject.name != "InnerWall13" && hit.collider.gameObject.name != "InnerWall4" && hit.collider.gameObject.name != "InnerWall5" && hit.collider.gameObject.name != "InnerWall6" && hit.collider.gameObject.name != "InnerWall1_1" && hit.collider.gameObject.name != "InnerWall2_1" && hit.collider.gameObject.name != "InnerWall3_1" && hit.collider.gameObject.name != "InnerWall4_1" && hit.collider.gameObject.name != "InnerWall5_1" && hit.collider.gameObject.name != "InnerWall6_1" && hit.collider.gameObject.name != "TopOfStick2" && hit.collider.gameObject.name != "Stick2" && hit.collider.gameObject.name != "Table_Final")
                    {
                        
                        count++;
                    }

                }
                tempCollisions[i] = count;
            }
            ball.Set_Number_Of_Collisions_Between_hitPosition_CueBall(tempCollisions);



           



           

        }
    }


  
    //Decide
    public void SetConditions()
    {
        foreach(BallPlayerB ball in ballToPocketPlayerB)
        {
            //Get all 4 condition values 
            int[] colsBallPockets = new int[6];
            colsBallPockets = ball.Get_Number_Of_Collisions_Between_Ball_Pockets();
            bool[] tempCondition1 = new bool[6];

            int[] colsBehindCue = new int[6];
            colsBehindCue = ball.Get_Number_Of_Collisions_Behind_Cue_Ball();
            bool[] tempCondition2 = new bool[6];

            float[] angles = new float[6];
            angles = ball.getAngle();
            bool[] tempCondition3 = new bool[6];

            int[] colsHitPosition_Cue = new int[6];
            colsHitPosition_Cue = ball.Get_Number_Of_Collisions_Between_hitPosition_CueBall();
            bool[] tempCondition4 = new bool[6];

            //Check if they satisfy and store in temp array
            //then transfer to the main object.
            for(int i = 0; i < Pockets.Length; i++)
            {
                if(colsBallPockets[i] == 0)
                {
                    tempCondition1[i] = true;
                }
                else
                {
                    tempCondition1[i] = false;
                }
                if(colsBehindCue[i] == 0)
                {
                    tempCondition2[i] = true;
                }
                else
                {
                    tempCondition2[i] = false;
                }
                if(angles[i] <= DESIRED_ANGLE)
                {
                    tempCondition3[i] = true;
                }
                else
                {
                    tempCondition3[i] = false;
                }
                if(colsHitPosition_Cue[i] == 0)
                {
                    tempCondition4[i] = true;
                }
                else
                {
                    tempCondition4[i] = false;
                }
            }
            ball.setCondition1(tempCondition1);
            ball.setCondition2(tempCondition2);
            ball.setCondition3(tempCondition3);
            ball.setCondition4(tempCondition4);
        }
    }
 
    public void SetDeviations()
    {
        //Similar to set condition but finding deviation from desired values
        foreach (BallPlayerB ball in ballToPocketPlayerB)
        {
            int[] colsBallPockets = new int[6];
            colsBallPockets = ball.Get_Number_Of_Collisions_Between_Ball_Pockets();
            int[] tempDeviation1 = new int[6];

            int[] colsBehindCue = new int[6];
            colsBehindCue = ball.Get_Number_Of_Collisions_Behind_Cue_Ball();
            int[] tempDeviation2 = new int[6];

            float[] angles = new float[6];
            angles = ball.getAngle();
            float[] tempDeviation3 = new float[6];

            int[] colsHitPosition_Cue = new int[6];
            colsHitPosition_Cue = ball.Get_Number_Of_Collisions_Between_hitPosition_CueBall();
            int[] tempDeviation4 = new int[6];

            for (int i = 0; i < Pockets.Length; i++)
            {
                tempDeviation1[i] = colsBallPockets[i] - 0;
                tempDeviation2[i] = colsBehindCue[i] - 0;
                tempDeviation3[i] = angles[i] - DESIRED_ANGLE;
                tempDeviation4[i] = colsHitPosition_Cue[i] - 0;
            }
            ball.setDeviation1(tempDeviation1);
            ball.setDeviation2(tempDeviation2);
            ball.setDeviation3(tempDeviation3);
            ball.setDeviation4(tempDeviation4);
    
        }
    }


    public void SumDeviations()
    {
        foreach(BallPlayerB ball in ballToPocketPlayerB) {

            float[] tempSum = new float[6];
            for(int i = 0; i < Pockets.Length; i++)
            {
                tempSum[i] = ball.getDeviation1()[i] + ball.getDeviation2()[i] + ball.getDeviation3()[i] + ball.getDeviation4()[i];
            }
            ball.setSumOfDeviations(tempSum);
        }
    }

    //To find the min deviation
    public int[] findMinDeviation()
    {
        int[] returnValues = new int[2];

        //Starting min set to ball 0 and pocket 0
        int minBallIndex = 0;
        int minPocketIndex = 0;

        //Starting from 1 for each ball
        for(int i = 1; i < ballToPocketPlayerB.Length; i++)
        {
            //for each pocket
            for(int j = 1; j < Pockets.Length; j++)
            {
                //if current min is less then the selected min deviation then switch
                if(ballToPocketPlayerB[i].getSumOfDeviations()[j] < ballToPocketPlayerB[minBallIndex].getSumOfDeviations()[minPocketIndex])
                {
                    minBallIndex = i;
                    minPocketIndex = j;
                }
            }
        }
        returnValues[0] = minBallIndex;
        returnValues[1] = minPocketIndex;

        return returnValues;
    }

    public IEnumerator resetCam()
    {
        //Set ready to play text
        ReadyToPlayText.text = "Calculating Pots";

        //Wait for 12 seconds
        yield return new WaitForSeconds(12f);
        
        //Set Camera in controller
        control.SetCam();

        //Hit complete and stick movement complete are reset
        hitComplete = false;

    }

    //To remove an element from the array
    private BallPlayerB[] RemoveIndices(BallPlayerB[] IndicesArray, int RemoveAt)
    {
        //New array set
        BallPlayerB[] newIndicesArray = new BallPlayerB[IndicesArray.Length - 1];

        int i = 0;
        int j = 0;
        
        //going through the current array
        while (i < IndicesArray.Length)
        {
            //if the index to remove at is not equal to the current index
            if (i != RemoveAt)
            {
                //Assign value
                newIndicesArray[j] = IndicesArray[i];
                //Increment j, new indices
                j++;
            }
            //Increment i, old indices
            i++;
        }

        return newIndicesArray;
    }

    //Find Index of ball number
    int findIndex(int ball_number)
    {
        string toSearch = "Ball" + ball_number;
        for(int i = 0; i < ballToPocketPlayerB.Length; i++)
        {

            if(ballToPocketPlayerB[i].GetBall().name == toSearch)
            {
                return i;
            }
        }
        return -1;
    }

    //Method called once in single player mode and ball pocketed
    public void ballPocketed(int ball_number)
    {
        //Find index
        int index = findIndex(ball_number);

        //If ball 8 is pocketed return since game over
        if(ball_number == 8)
        {
            return;
        }
        
        //Remove pocketed ball from the array
        ballToPocketPlayerB = RemoveIndices(ballToPocketPlayerB, index);


        //All Balls Pocketed, now to pocket the 8th ball
        if(ballToPocketPlayerB.Length == 0)
        {
            //Resize array to 1
            Array.Resize<BallPlayerB>(ref ballToPocketPlayerB, 1);

            //temp array, adding ball 8 to temp
            BallPlayerB[] temp = new BallPlayerB[1];
            temp[0] = new BallPlayerB();
            temp[0].SetBall(GameObject.FindGameObjectWithTag("Ball8"));

            //Storing in main from temp
            ballToPocketPlayerB = temp;
        }

    }


}
