using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;
public class zombiekicker : MonoBehaviour
{
    public GameObject[] zombie;
    public GameObject hero;
    public float hitpoint = 10;
    public ParticleSystem blood;
    public ParticleSystem bloodtemp;
    Animator anim;
    public Sprite sword;
    public Sprite normal;
    

    // Start is called before the first frame update
    void Start()
    {
        
        hero = GameObject.FindGameObjectWithTag("Player");
        anim = hero.GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        zombie = GameObject.FindGameObjectsWithTag("zombie");
    }
    public void changeanim(Vector2 v)
    {
        if (v == new Vector2(0f, 1f))
        {
            anim.Play("swordup");
        }
        else if (v == new Vector2(1.0f, 0f))
        {
            anim.Play("swordright");
        }
        else if (v == new Vector2(0, -1.0f))
        {
            anim.Play("sworddown");
        }
        else if (v == new Vector2(-1.0f, 0f))
        {
            anim.Play("swordleft");
        }
        else
            return;
    }
    public void hitem()
    {
        Vector2 heading = Nearby().transform.position - hero.transform.position;
        var distance = heading.magnitude;
        Vector2 direction = heading / distance; // This is now the normalized direction.
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
    IEnumerator bloodspill(GameObject nearzom)
    {
        nearzom.GetComponent<Rigidbody2D>().isKinematic = false;
        nearzom.GetComponent<Animator>().Play("dead");
        yield return new WaitForSeconds(1.7f);
        Destroy(nearzom.GetComponent<HealthZombie>().gameObject);
        
        //Destroy(bloodtemp.gameObject);
    }
    public void hit()
    {
        
        GameObject nearzom = Nearby();
        if (Vector2.Distance(nearzom.transform.position, hero.transform.position) < 3f)
        {
            nearzom.GetComponent<HealthZombie>().Cmdtakehit(hitpoint);
            //GetComponent<Image>().sprite = sword;
            
           
       
        }
        if (nearzom.GetComponent<HealthZombie>().currhp<=0)
        {
            //bloodtemp = Instantiate(blood, nearzom.transform.position, Quaternion.identity);
            StartCoroutine(bloodspill(nearzom));
           // GetComponent<Image>().sprite = normal;
        }
        hitem();
        
    }
    
    public GameObject Nearby()
    {
        GameObject nearbyzom;
        nearbyzom = zombie[0];
        for(int i=0;i<zombie.Length;i++)
        {
            if(Vector2.Distance(nearbyzom.transform.position,hero.transform.position)> Vector2.Distance(zombie[i].transform.position, hero.transform.position))
            {
                nearbyzom = zombie[i];
            }
        }
        return nearbyzom;
    }

}
