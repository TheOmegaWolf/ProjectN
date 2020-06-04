using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class HealthZombie : NetworkBehaviour
{
    public Slider hp;
    [SyncVar] public float maxhp = 100;
    [SyncVar] public float currhp;

    // Start is called before the first frame update
    void Start()
    {
        currhp = maxhp;
        hp.value = 1;
    }

    public void Cmdtakehit(float hit)
    {
        if (this.gameObject)
        {
            maxhp = 100;
            currhp -= hit;
            hp.value = currhp / maxhp;
           // Debug.Log(currhp / maxhp);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
