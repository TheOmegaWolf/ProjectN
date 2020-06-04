using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class SearchandDestroy : NetworkBehaviour
{
    public GameObject[] hero;
    public MoveChar guy;
    private Animator anim;
    public GameObject target;
    private float time = 0.0f;
    public float interpolationPeriod = 3f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        guy = CanvasManagerScript.instance.localplayer.GetComponent<MoveChar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hero = GameObject.FindGameObjectsWithTag("Player");
        Follow();
        
    }
    void changeanim(Vector2 pos)
    {
        anim.SetFloat("horizontal", pos.x);
        anim.SetFloat("vertical", pos.y);
    }
    void Follow()
    {

        Vector2 min = hero[0].transform.position;
        target = hero[0];
        
        for (int i = 0; i < hero.Length; i++)
        {
            if(Vector2.Distance(transform.position,hero[i].transform.position)<Vector2.Distance(min,transform.position))
            {
                min = hero[i].transform.position;
                target = hero[i];
                guy = target.GetComponent<MoveChar>();
            }
            
            
            //attack(hero[i].GetComponent<NetworkIdentity>());
        }
        if (target.gameObject!=null)
        {
            if (Vector2.Distance(min, transform.position) > 10f)
            {
                anim.SetBool("punch", false);
                anim.SetFloat("speed", -1);
                changeanimationcheck(new Vector2(0, 0));
            }
            else if (Vector2.Distance(min, transform.position) < 10f && Vector2.Distance(min, transform.position) > 2f)
            {
                anim.SetBool("punch", false);
                anim.SetFloat("speed", 1);
                Vector2 temp = Vector2.MoveTowards(transform.position, min, 3f * Time.deltaTime);
                changeanimationcheck(temp - new Vector2(transform.position.x, transform.position.y));
                transform.position = temp;
                //Debug.Log(Vector2.Distance(min, transform.position));
            }
            else if (Vector2.Distance(min, transform.position) <= 2.5f)
            {
                anim.SetBool("punch", true);
                anim.SetFloat("speed", 1);
                Vector2 temp = Vector2.MoveTowards(transform.position, min, 3f * Time.deltaTime);
                changeanimationcheck(temp - new Vector2(transform.position.x, transform.position.y));
                
                CanvasManagerScript.instance.debug1.text = guy.currhealth.ToString();
                time += Time.deltaTime;

                if (time >= interpolationPeriod && guy.currhealth > 0)
                {
                    time = 0.0f;

                    guy.takedamage(10);
                }
                else if (guy.currhealth <= 0)
                {
                    Destroy(guy.gameObject);
                }
            }
        }
    }
    IEnumerator hit()
    {
        yield return new WaitForSeconds(3f);
        
        yield return new WaitForSeconds(3f);
    }
    void changeanimationcheck(Vector2 direction)
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
    //[TargetRpc]
    //void attack(NetworkIdentity netid)
    //{
    //    Debug.Log("hit");
    //}
}
