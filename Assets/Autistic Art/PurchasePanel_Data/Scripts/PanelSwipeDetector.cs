using System;
using DG.Tweening;
//using Firebase.Analytics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelSwipeDetector : MonoBehaviour
{
    public GameObject[] panels;
    int curr = 0;
    //public AudioClip[] clips;
    //public string[] animName,idleAnim;
    //public InAppCalling_CB inApp;
    public GameObject ParentalControllPanel;

    public RectTransform canvas;

    private float PanelWidth;
    public float delayTime = 1;
    public GameObject[] PurchasePanels,allSelected,inApps;

    
    private void OnEnable()
    {
        canvas = GetComponent<RectTransform>();
        PanelWidth = canvas.rect.width;
        Debug.Log("Anchored Position: " + canvas.rect.width);
        for (int i = 0; i < inApps.Length; i++)
        {
            if (PlayerPrefs.GetInt(inApps[i].name) == 1)
            {
                inApps[i].SetActive(false);
            }
        }
    }
    public void soundbtn()
    {
        SoundHandler.instance.PlayClick();
    }
    private void Start()
    {
        curr = 0;
        Invoke(nameof(OnSwipeLeft),delayTime);
    }
    
    void OnSwipeLeft()
    {
        if (curr + 1 < panels.Length)
        {
            panels[curr + 1].GetComponent<RectTransform>().DOAnchorPosX(PanelWidth, 0);
            panels[curr].GetComponent<RectTransform>().DOAnchorPosX(-PanelWidth, .5f).OnComplete(delegate
            {
                panels[curr].SetActive(false);
            });
            panels[curr + 1].SetActive(true);
            panels[curr + 1].GetComponent<RectTransform>().DOAnchorPosX(0, .5f).OnComplete(delegate
            {
                curr++;
            });
        }
        else
        {
            panels[0].GetComponent<RectTransform>().DOAnchorPosX(PanelWidth, 0);
            panels[panels.Length-1].GetComponent<RectTransform>().DOAnchorPosX(-PanelWidth, .5f).OnComplete(delegate
            {
                panels[panels.Length - 1].SetActive(false);
            });
            panels[0].SetActive(true);
            panels[0].GetComponent<RectTransform>().DOAnchorPosX(0, .5f).OnComplete(delegate
            {

                curr=0;
            });
        }
        Invoke(nameof(OnSwipeLeft),delayTime);
    }

    
    public void CrossClick()
    {
        
        DOTween.KillAll(false);
        SoundHandler.instance.PlayClick();

        if (PlayerPrefs.GetInt("CameFromSplash") == 0)
        {
            PlayerPrefs.SetInt("CameFromSplash", 1);
            SceneManager.LoadScene("Selection");
           
        }
        else
        {
            Debug.Log("Causing Issue"+ PlayerPrefs.GetString("CameFrom"));
            SceneManager.LoadScene(PlayerPrefs.GetString("CameFrom"));
        }
    }

    public void PurchasePanel()
    {
        if (PlayerPrefs.GetInt("ShowParentalPanel") == 0)
        {
            //inApp.BuyInApp();
        }
        else
        {
            //PlayerPrefs.SetInt("ShowParentalPanel", 0);
            ParentalControllPanel.SetActive(true);
        }
    }


    public void Terms()
    {
        Application.OpenURL("https://muhammadubaidprivacy.blogspot.com/2025/06/terms-of-use.html");
    }

    public void Privacy()
    {
        Application.OpenURL("https://muhammadubaidprivacy.blogspot.com/2025/06/privacy-policy.html");
    }
    
}