using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followthechars : MonoBehaviour
{
    public GameObject[] targets;
    public Vector3 offset;
    Camera cam;
    private Vector3 velocity;
    public static followthechars instance;
    public float minzoom = 40f;
    public float maxzoom = 10f;
    public float zoomlimiter = 50f;
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        cam = GetComponent<Camera>();
        cam.nearClipPlane = -5f;
    }
    public void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");

    }
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (targets.Length == 0)
            return;
        Move();
        Zoom();
        
    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxzoom, minzoom, GetGreatestDistance()/zoomlimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,newZoom,Time.deltaTime);
    }

   float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i=0;i<targets.Length;i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }
        return bounds.size.x;
    }

    void Move()
    {
        Vector3 centerpoint = GetCenterPoint();
        Vector3 newpos = centerpoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, .5f);
    }
    Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
            return targets[0].transform.position;
        var bound = new Bounds(targets[0].transform.position, Vector3.zero);
        for(int i=0;i<targets.Length;i++)
        {
            bound.Encapsulate(targets[i].transform.position);
        }
        return bound.center;
        
    }
}
