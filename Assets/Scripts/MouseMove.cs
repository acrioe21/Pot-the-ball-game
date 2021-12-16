using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 100f; // speed of the mouse
    public Transform player; // Getting the capsule player
    private float xRotation = 0f;// To rotate up and down around x axis
    //To freeze movement between the time when a shot is done
    //And the time to check if a ball has been pocketed
    public bool toFreezeMovement = false;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //locking the cursor so that the mouse is not seen when playing the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!toFreezeMovement)
        {
            float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // Gets the mouse movement in the X axis
            float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; //Gets the mouse movement in the Y axis
            player.Rotate(Vector3.up * x); // Rotate around y axis
            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, -90f, -0.4f); //Limiting the rotation
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotating around x axis
                                                                           //transform.Rotate(new Vector3(1, 0, 0) * y); Rotates it around x axis but player can look behind all the way also
        }
        }
}
