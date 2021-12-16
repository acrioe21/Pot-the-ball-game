using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PocketColliderScript : MonoBehaviour
{
    public GameObject controller;
    MainGameController control;

    //Player B game object
    public GameObject playerB;
    AIPlayerB aiScript;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        control = controller.GetComponent<MainGameController>();

        //If in single player
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            aiScript = playerB.GetComponent<AIPlayerB>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Ball1": Destroy(collision.gameObject); control.ballPocketed(1); control.scoreTracker(1);  break;
            case "Ball2": Destroy(collision.gameObject); control.ballPocketed(2); control.scoreTracker(2); break;
            case "Ball3": Destroy(collision.gameObject); control.ballPocketed(3); control.scoreTracker(3); break;
            case "Ball4": Destroy(collision.gameObject); control.ballPocketed(4); control.scoreTracker(4); break;
            case "Ball5": Destroy(collision.gameObject); control.ballPocketed(5); control.scoreTracker(5); break;
            case "Ball6": Destroy(collision.gameObject); control.ballPocketed(6); control.scoreTracker(6); break;
            case "Ball7": Destroy(collision.gameObject); control.ballPocketed(7); control.scoreTracker(7); break;
            case "Ball8": Destroy(collision.gameObject); control.scoreTracker(8); break;
            
            case "Ball9": 
                Destroy(collision.gameObject); control.ballPocketed(9); control.scoreTracker(9); 
                //If in single player then call function in AI Player B script
                if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(9);
                }
                break;
            case "Ball10": 
                Destroy(collision.gameObject); control.ballPocketed(10); control.scoreTracker(10);
                //If in single player then call function in AI Player B scipt
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(10);
                }
                break;
            case "Ball11": 
                Destroy(collision.gameObject); control.ballPocketed(11); control.scoreTracker(11);
                //If in single player then call function in AI Player B scipt
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(11);
                }
                break;
            case "Ball12": 
                Destroy(collision.gameObject); control.ballPocketed(12); control.scoreTracker(12);
                //If in single player then call function in AI Player B scipt
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(12);
                }
                break;
            case "Ball13": 
                Destroy(collision.gameObject); control.ballPocketed(13); control.scoreTracker(13);
                //If in single player then call function in AI Player B scipt
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(13);
                }
                break;
            case "Ball14":
                Destroy(collision.gameObject); control.ballPocketed(14); control.scoreTracker(14);
                //If in single player then call function in AI Player B scipt
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(14);
                }
                break;
            case "Ball15": 
                Destroy(collision.gameObject); control.ballPocketed(15); control.scoreTracker(15);
                //If in single player then call function in AI Player B scipt
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    aiScript.ballPocketed(15);
                }
                break;
            case "CueBall": control.ballPocketed(0); break;
        }
    }
}
