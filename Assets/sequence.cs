using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sequence : MonoBehaviour
{
    public GameObject logo;
    public Button clicktocontinue;
    //public Text howcan;
    public InputField name;
    public GameObject omegawolf;
    public GameObject background;
    public GameObject intro;
    public Text hey;
    public string Player = "Player";
    private void Start()
    {
        LeanTween.alphaText(hey.GetComponent<RectTransform>(), 0, 0);
        hey.gameObject.SetActive(false);
        omegawolf.SetActive(true);
        background.SetActive(true);
        LeanTween.alpha(omegawolf.GetComponent<RectTransform>(), 0, 0);
        LeanTween.alpha(background.GetComponent<RectTransform>(), 1, 0);

        StartCoroutine(timer());
       // LeanTween.alphaText(howcan.GetComponent<RectTransform>(), 0, 0f);
        setalpha(name.gameObject, 0, 0);
        //howcan.gameObject.SetActive(false);
        name.gameObject.SetActive(false);
        setalpha(logo.gameObject, 0, 0);
        setalpha(clicktocontinue.gameObject, 0, 0);

        

    }
    void setalpha(GameObject g, float a,float t)
    {
        LeanTween.alpha(g.GetComponent<RectTransform>(), a, t);
    }
    IEnumerator waitsecs(float time)
    {
        yield return new WaitForSeconds(time);
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        setalpha(omegawolf, 1, 2);
        yield return new WaitForSeconds(2);
        setalpha(omegawolf, 0, 2);
        yield return new WaitForSeconds(3);
        setalpha(background, 0, 1);
        yield return new WaitForSeconds(1);
        logo.SetActive(true);
        clicktocontinue.gameObject.SetActive(true);
        
        setalpha(logo.gameObject, 1, 2);
        yield return new WaitForSeconds(1);
        setalpha(clicktocontinue.gameObject, 1, 2);

    }
    IEnumerator loadscene()
    {
        setalpha(logo.gameObject, 0, 2);
        setalpha(clicktocontinue.gameObject, 0, 1);
        yield return new WaitForSeconds(2);
        name.gameObject.SetActive(true);
        setalpha(name.gameObject, 1, 1f);
        yield return new WaitForSeconds(2);
        
    }
    IEnumerator namer()
    {
        setalpha(name.gameObject, 0, 1f);
        yield return new WaitForSeconds(2);
        name.gameObject.SetActive(false);
        PlayerPrefs.SetString("playername", name.text);
        string playername = PlayerPrefs.GetString("playername");
        
        yield return new WaitForSeconds(1);
        hey.gameObject.SetActive(true);

        hey.text = hey.text + " " + playername + "!";
        LeanTween.alphaText(hey.GetComponent<RectTransform>(), 1, 1);
        yield return new WaitForSeconds(2);
        LeanTween.alphaText(hey.GetComponent<RectTransform>(), 0, 1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    public void clicker()
    {/*
        setalpha(logo.gameObject, 0, 1f);
        setalpha(clicktocontinue.gameObject, 0, 1f);
        waitsecs(1.5f);
        
        //howcan.gameObject.SetActive(true);
        name.gameObject.SetActive(true);

        //LeanTween.alphaText(howcan.GetComponent<RectTransform>(), 1, 2f);
        //setalpha(name.gameObject, 1, 2f);*/
        StartCoroutine(loadscene());

    }
    public void nameentered()
    {
        StartCoroutine(namer());
    }
}
