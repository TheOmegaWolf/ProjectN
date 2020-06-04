using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class move : NetworkBehaviour
{
    public Joystick joystick;
    public float run = 500f;
    public Vector2 movement;
    public bool moving = false;
    public Rigidbody2D rb;
    public static move instance;
    public GameObject Player;
    // Start is called before the first frame update
    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    [Client]
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        joystick = canvasmanager.instance.joystick;
        rb = GetComponent<Rigidbody2D>();
        //Player =this.gameObject;
        //Player.name = Player.name + PlayerPrefs.GetInt("number");
        
    }
    

    [Client]
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        movement.x = joystick.Horizontal*100f;
        movement.y = joystick.Vertical*100f;
        if(movement.sqrMagnitude>0.01f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
    void FixedUpdate()
    {
        if (joystick.Horizontal >= .2f || joystick.Horizontal <= .2f)
        {
            rb.MovePosition(rb.position+movement * run * Time.fixedDeltaTime);
            //Debug.Log(movement * run * Time.fixedDeltaTime);
        }
       }
}
