using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class CanvasManagerScript : NetworkBehaviour
{
    public static CanvasManagerScript instance;
    public MoveChar localplayer;
    [SerializeField] GameObject Alive;
    [SerializeField] GameObject Dead;
    public Joystick movej;
    public Text debug;
    public Text debug1;
    public Text name;
    public Slider HealthBar;
    public Image fill;
    //public Transform []pos;
    public Transform position;
    public Camera cam;
    public Text debug2;
    //int p;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        debug = GameObject.Find("DebugText").GetComponent<Text>();
        debug1 = GameObject.Find("DebugText (1)").GetComponent<Text>();
        debug2 = GameObject.Find("DebugText (2)").GetComponent<Text>();
        name = GameObject.Find("NameUI").GetComponent<Text>();
        instance = this;
        DontDestroyOnLoad(gameObject);
        HideUI();
        
        name.text = PlayerPrefs.GetString("playername").ToString();
    }
    public void HideUI()
    {
        Alive.SetActive(false);
        Dead.SetActive(false);
    }
    public void ChangePlayerState(bool isAlive)
    {
        Alive.SetActive(isAlive);
        Dead.SetActive(isAlive);
    }
    public void FixedUpdate()
    {
       
    }
}
