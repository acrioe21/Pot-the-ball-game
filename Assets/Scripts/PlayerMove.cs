using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Holds reference to the character contoller attached to the player
    public CharacterController controller;
    //Move Speed of the player
    float moveSpeed = 20f;

    //To freeze the movement of the player when the cueBall is hit , to wait for the balls to pocket
    public bool toFreezeMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!toFreezeMovement)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // transform.right and .forward take the direction where the player is facing and moves right and forward , it also considers rotation
            Vector3 move = transform.right * x + transform.forward * y; // Based on local coordinates
                                                                        //Vector3 move = new Vector3(x, 0f, y); Based on Global Coordinate cant use it since it doesnt account of where the player is facing
            controller.Move(move * moveSpeed * Time.deltaTime);
        }
    }
}
