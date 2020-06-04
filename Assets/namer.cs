using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class namer : MonoBehaviour
{
    public Text name;

    // Start is called before the first frame update
    void Start()
    {
        name.text = PlayerPrefs.GetString("playername");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
