using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    //All the balls are stored in this array
    ArrayList AllBalls = new ArrayList();
    //Getting the game controller gameobject
    public GameObject controller;
    //To hold the main game controller script
    MainGameController control;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the script component from MainGameController gameobject
        control = controller.GetComponent<MainGameController>();
        //Adding the balls to the array
        AllBalls.Add("Ball1");
        AllBalls.Add("Ball2");
        AllBalls.Add("Ball3");
        AllBalls.Add("Ball4");
        AllBalls.Add("Ball5");
        AllBalls.Add("Ball6");
        AllBalls.Add("Ball7");
        AllBalls.Add("Ball9");
        AllBalls.Add("Ball10");
        AllBalls.Add("Ball11");
        AllBalls.Add("Ball12");
        AllBalls.Add("Ball13");
        AllBalls.Add("Ball14");
        AllBalls.Add("Ball15");
        AllBalls.Add("CueBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //If the player moves the stick to move the balls
        // that is the player moves the ball by sliding the stick 
        //then the fault function is called in the main game controller
        if (AllBalls.Contains(collision.gameObject.name))
        {
            Debug.Log("Fault");
            collision.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            control.fault();
            collision.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
