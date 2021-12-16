using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
