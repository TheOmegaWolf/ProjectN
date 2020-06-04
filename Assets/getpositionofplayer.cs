using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getpositionofplayer : MonoBehaviour
{
    GameObject hero;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(hero.transform.position.x,hero.transform.position.y);
        //cam.orthographicSize = 15f;
        cam.nearClipPlane = -0.22f;
    }
}
