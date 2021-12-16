using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueBallCollider : MonoBehaviour
{
    //Balls to be detected for collision with cue ball
    ArrayList pocketBalls = new ArrayList();

    //GameObject to hold the inner walls
    public GameObject innerWall1;
    public GameObject innerWall2;
    public GameObject innerWall3;
    public GameObject innerWall4;
    public GameObject innerWall5;
    public GameObject innerWall6;

    Vector3 originalPositionCueBall;
    void Awake()
    {
        //Adding the ball gameobject names to the array
        pocketBalls.Add("Ball1");
        pocketBalls.Add("Ball2");
        pocketBalls.Add("Ball3");
        pocketBalls.Add("Ball4");
        pocketBalls.Add("Ball5");
        pocketBalls.Add("Ball6");
        pocketBalls.Add("Ball7");
        pocketBalls.Add("Ball9");
        pocketBalls.Add("Ball10");
        pocketBalls.Add("Ball11");
        pocketBalls.Add("Ball12");
        pocketBalls.Add("Ball13");
        pocketBalls.Add("Ball14");
        pocketBalls.Add("Ball15");

        //Setting the inner walls to be invisible
        innerWall1.GetComponent<MeshRenderer>().enabled = false;
        innerWall2.GetComponent<MeshRenderer>().enabled = false;
        innerWall3.GetComponent<MeshRenderer>().enabled = false;
        innerWall4.GetComponent<MeshRenderer>().enabled = false;
        innerWall5.GetComponent<MeshRenderer>().enabled = false;
        innerWall6.GetComponent<MeshRenderer>().enabled = false;

        //Getting the original Cue Ball position at the beginning of the game
        originalPositionCueBall = gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("CUE BALL COLLIDER SCRIPT");
       // If the collision happens with any of the balls to pocket
        if (pocketBalls.Contains(collision.gameObject.name))
        {
            //Debug.Log("CUE BALL COLLIDER , COLLIDED FROM : " + collision.gameObject.name);
            //Purpose so that the cueBall does not bounce up after hitting the other balls
            //Debug.Log("Collided from cueBall");
            //Getting the cue ball velocity
            Vector3 vel = GetComponent<Rigidbody>().velocity;
            //Getting the Horizontal direction of the ball
            Vector2 horizontal = new Vector2(vel.x, vel.z);
            horizontal = horizontal.normalized; // Normalizing it to get only direction without speed
            horizontal = vel.magnitude * horizontal; //Adding the force of the original vector to the horizontal direction
            GetComponent<Rigidbody>().velocity = new Vector3(horizontal.x, 0, horizontal.y);
        }
        else if (collision.gameObject.name=="InnerWall1" || collision.gameObject.name == "InnerWall2" || collision.gameObject.name == "InnerWall3" || collision.gameObject.name == "InnerWall4" || collision.gameObject.name == "InnerWall5" || collision.gameObject.name == "InnerWall6")
        {

            Vector3 currVelocity = GetComponent<Rigidbody>().velocity;
            Debug.Log("Old Velocity : " + currVelocity);
            Vector3 newVelocity = Vector3.Reflect(currVelocity, collision.contacts[0].normal);
            GetComponent<Rigidbody>().velocity = new Vector3(newVelocity.x, -20f, newVelocity.z);
            Debug.Log("New Vel : " + newVelocity);
            
        }
        //else if it hits the floor
        else if (collision.gameObject.name == "Floor")
        {
            //bring it back on the table
            transform.position = originalPositionCueBall;
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
