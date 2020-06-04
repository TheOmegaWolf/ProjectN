using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addpoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MoveChar>().score += 100;
            Destroy(transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
