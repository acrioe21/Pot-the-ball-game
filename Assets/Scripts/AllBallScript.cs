using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBallScript : MonoBehaviour
{
    //If the ball hits the floor reset its position
    //To store the position of the ball at the start of the game
    Vector3 originalPosition;
    private void Awake()
    {
        originalPosition = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //If the Ball Falls to the floor
       if(collision.gameObject.name == "Floor")
        {
            transform.position = new Vector3(originalPosition.x, 34.7f, originalPosition.z);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
       //If the balls hit the inner walls stop it from bouncing up
       else if(collision.gameObject.name == "InnerWall1" || collision.gameObject.name == "InnerWall2" || collision.gameObject.name == "InnerWall3" || collision.gameObject.name == "InnerWall4" || collision.gameObject.name == "InnerWall5" || collision.gameObject.name == "InnerWall6")
        {
            
            Vector3 vel = GetComponent<Rigidbody>().velocity;
            //Getting the Horizontal direction of the ball
            Vector2 horizontal = new Vector2(vel.x, vel.z);
            horizontal = horizontal.normalized; // Normalizing it to get only direction without speed
            horizontal = vel.magnitude * horizontal; //Adding the force of the original vector to the horizontal direction
            GetComponent<Rigidbody>().velocity = new Vector3(horizontal.x, 0, horizontal.y);
        }
    }
}
