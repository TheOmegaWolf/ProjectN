using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Singleton : NetworkBehaviour
{
    //public int playernumber = 1;
    public static Singleton instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
