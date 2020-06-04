using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class SpawnZombies : NetworkBehaviour
{
    public GameObject Zombie;
    int number = 3;
    int num2 = 2;
    public GameObject[] player;
    float currCountdownValue;
    public GameObject heart;
    public GameObject coins;
    public bool spawn = false;
    IEnumerator waiter(int num2)
    {
        yield return new WaitForSeconds(num2);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(waiter());
        StartCoroutine(Starter());
        for(int i=0;i<10;i++)
            Instantiate(heart, new Vector3(Random.Range(-40.6f, 19.1f), Random.Range(43.5f, -32.7f), 0f), Quaternion.identity);
        for(int i=0;i<10;i++)
            Instantiate(coins, new Vector3(Random.Range(-40.6f, 19.1f), Random.Range(43.5f, -32.7f), 0f), Quaternion.identity);
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        // yield return new WaitForSeconds(2);
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            CanvasManagerScript.instance.debug.text = currCountdownValue.ToString();
            currCountdownValue--;            
        }      
    }
    WaitForSeconds waitForSeconds = new WaitForSeconds(10f);

    IEnumerator Starter()
    {
        while (true)
        {
            spawn = true;
            StartCoroutine(StartCountdown(10));
            // Place your method calls
            yield return waitForSeconds;
            number += 2;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // if (NetworkManagerHUD.instance.npint < 3)
        // Debug.Log("3");
        // player = GameObject.FindGameObjectsWithTag("Player");
        //if( CanvasManagerScript.instance.localplayer.issurround == false)
        //{
        //   Transform position = CanvasManagerScript.instance.localplayer.transform;
        // }
        //Transform lp = CanvasManagerScript.instance.localplayer.transform;
        GameObject[] zomb = GameObject.FindGameObjectsWithTag("zombie");
        
       
            
       
        if (spawn==true)
        {
            
            if (zomb.Length < 20)
            {
                for (int i = 0; i < number; i++)
                {
                    Debug.Log("helo");
                    GameObject zom = Instantiate(Zombie, new Vector3(Random.Range(-40.6f, 19.1f), Random.Range(43.5f, -32.7f), 0f), Quaternion.identity);
                    NetworkServer.Spawn(zom);
                }
                
                spawn = false;
                StartCoroutine(waiter(num2 += 4));
                
            }
            else
                return;
        }
    }
}

