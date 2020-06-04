using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using DentedPixel;
public class customnetworkmanager : NetworkManager
{
    public void Awake()
    { 
        Canvas1 = GetComponentInChildren<Canvas>();
        Canvas1.gameObject.SetActive(true);
    }
    public Canvas Canvas1;
    
    public void starthosting()
    {
        base.StartHost();
        CanvasManagerScript.instance.debug.text = PlayerPrefs.GetString("playername");
        Canvas1.gameObject.SetActive(false);
        //NetworkServer.Spawn(playerPrefab);

    }
    public void startClient()
    {
        base.StartClient();
        CanvasManagerScript.instance.debug.text = PlayerPrefs.GetString("playername");
        
        Canvas1.gameObject.SetActive(false);
    }

}


