using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class canvasmanager : NetworkBehaviour
{
    public static canvasmanager instance;
    public Joystick joystick;
    //public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
