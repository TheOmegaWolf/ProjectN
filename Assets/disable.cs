using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class disable : MonoBehaviour
{
    public GameObject Logo;
    public GameObject clicktocontinue;
    public GameObject Canvas;
    //public GameObject Canvas2;
    GameObject howcan;
    public GameObject textf;

    // Start is called before the first frame update
    void Start()
    {
        
        Canvas.SetActive(true);
        LeanTween.moveY(Logo.gameObject, Logo.transform.position.y + 0.5f, 2f);
        LeanTween.alpha(Logo.gameObject.GetComponent<RectTransform>(), 1f, 2f);
        howcan = GameObject.Find("Howcan");
        textf = GameObject.Find("entername");
        LeanTween.alpha(howcan, 0, 0);
        LeanTween.alpha(textf, 0, 0);
    }
    IEnumerator waitsecs1(float sec)
    {
        yield return new WaitForSeconds(sec);
        clicktocontinue.SetActive(false);
        Logo.SetActive(false);
        yield return new WaitForSeconds(sec);
        
        LeanTween.alpha(howcan, 1, 1f);
        LeanTween.alpha(textf, 1, 1f);
    }
    public void MovetoNewScreen()
    {
        LeanTween.alpha(Logo.gameObject.GetComponent<RectTransform>(), 0, 1f);
        LeanTween.alpha(clicktocontinue.gameObject.GetComponent<RectTransform>(), 0, 1f);
        StartCoroutine(waitsecs1(1.5f));
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
