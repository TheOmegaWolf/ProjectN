using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class MoveChar : NetworkBehaviour
{
    Rigidbody2D rb;
    bool moving = false;
    public float run = 500f;
    Animator anim;
    public Transform position;
    public float score = 0;
    // public Vector2 lowerbound, upperbound, center, rightcam, leftcam;
    public float Rotation = 360;
    public int number = 1;
    [SyncVar]
    int playnum;
    int counter = 0;
    public bool issurround = false;
    [SyncVar]
    public float maxhealth = 100f;
    [SyncVar]
    public float currhealth;
    public float minhealth = 0.15f;
    public GameObject[] zombie;
    //Slider healthb;
    public bool isnear = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            rb.isKinematic = false;
        }
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isLocalPlayer)
        {
            //Camera.main.transform.SetParent(transform);
            CanvasManagerScript.instance.localplayer = this;
            //Debug.Log(CanvasManagerScript.instance.localplayer.netIdentity);
            CanvasManagerScript.instance.ChangePlayerState(true);
            //transform.position = CanvasManagerScript.instance.position.transform.position;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, -10f);
            CanvasManagerScript.instance.cam.transform.position = pos;
            //printer();
            //float r = Rotation / number;
            //Vector3 rotator = new Vector3(0f, 0f, r);
            //CanvasManagerScript.instance.cam.transform.eulerAngles= rotator;
            //transform.eulerAngles = rotator;
            //number = Singleton.instance.playernumber;
            
            CanvasManagerScript.instance.HealthBar.value = maxhealth;
            //healthb.value = CanvasManagerScript.instance.HealthBar.value;
            CanvasManagerScript.instance.fill.color = new Color(0, 1, 0);
            //Singleton.instance.playernumber++;
            counter += 1;
            currhealth = maxhealth;
            minhealth = 0.15f;
            anim = GetComponent<Animator>();
            zombie = GameObject.FindGameObjectsWithTag("zombie");
        }
        
    }
    public void takedamage(float dam)
    {
       // Debug.Log(dam/100);
        
            currhealth -= dam;
            CanvasManagerScript.instance.HealthBar.value =(currhealth/maxhealth);
            Debug.Log(currhealth+ " " + dam);
            //healthb.value = CanvasManagerScript.instance.HealthBar.value;
            if ((currhealth / maxhealth) <= 0.5f && (currhealth / maxhealth) >= 0.2f )
            {
                CanvasManagerScript.instance.fill.color = new Color(1, 1, 0);
            }
            else if ((currhealth / maxhealth <= 0.2f ))
            {
                CanvasManagerScript.instance.fill.color = new Color(1, 0, 0);
            }
        
    }

    private void Awake()
    {
        
    }
  /*  void printer()
    {
        lowerbound = CanvasManagerScript.instance.cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        upperbound = CanvasManagerScript.instance.cam.ViewportToWorldPoint(new Vector2(1, 1));
        center = upperbound / 2;
        rightcam = upperbound + center / 2;
        leftcam = lowerbound + center / 2;
        
    }*/
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        //if(upperbound.y > transform.position.y && lowerbound.y < transform.position.y)
        MobileInput();
        // Debug.Log(Singleton.instance.playernumber);
        // Debug.Log(lowerbound + " " + upperbound + " " + center + " " + rightcam + " " + leftcam+ " " + transform.position);
        DoAnimation();
        //zombiecheck();
        CanvasManagerScript.instance.debug2.text = "Score: " + score+" ";
    }

    private void MobileInput()
    {
        Vector2 movement;
        movement.x = CanvasManagerScript.instance.movej.Horizontal * 100f;
        movement.y = CanvasManagerScript.instance.movej.Vertical * 100f;
        if (movement.sqrMagnitude > 0.01f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if ((CanvasManagerScript.instance.movej.Horizontal >= .2f || CanvasManagerScript.instance.movej.Horizontal <= .2f) ) 
        {
            transform.position = (rb.position + movement * run * Time.fixedDeltaTime);
            //Debug.Log(movement * run * Time.fixedDeltaTime);
        }
    }
    void changeanim(Vector2 pos)
    {
        anim.SetFloat("x", pos.x);
        anim.SetFloat("y", pos.y);
    }
  
    public void DoAnimation()
    {
        Vector2 movement = new Vector2(CanvasManagerScript.instance.movej.Horizontal * 100f, CanvasManagerScript.instance.movej.Vertical * 100f);
        Vector2 direction = new Vector2(CanvasManagerScript.instance.movej.Horizontal, CanvasManagerScript.instance.movej.Vertical);
        if (movement.magnitude > 0.01f)
        {
            anim.GetComponent<Animator>().SetFloat("speed",1);
            //Debug.Log(movement.magnitude);
        }
        else
        {
            anim.GetComponent<Animator>().SetFloat("speed", -1);
            //Debug.Log(movement.magnitude);
        }
        if (anim.GetBool("attack") == false)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    changeanim(Vector2.right);
                }
                else if (direction.x < 0)
                {
                    changeanim(Vector2.left);
                }
                else
                {
                    changeanim(new Vector2(0, 0));
                }
            }
            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                if (direction.y > 0)
                {
                    changeanim(Vector2.up);
                }
                else if (direction.y < 0)
                {
                    changeanim(Vector2.down);
                }
                else
                {
                    changeanim(new Vector2(0, 0));
                }
            }
        }
    }
}
