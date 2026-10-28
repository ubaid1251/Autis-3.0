using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;

public class SubSelection : MonoBehaviour
{
    //public Image BG;
   // public Sprite[] allbg;
    //public GameObject[] modes;
    //public LoadingHandler LOADING;
    public static string cameFrom = "MainSelection";
    public EventSystem eventSystem;
    RectTransform content;
    public RectTransform adult, setting,banner, Titleobj;
    //public RectTransform[] title;
    void FindSelected()
    {
        PlayerPrefs.SetInt("SelectedMode", 1);
        string s = PlayerPrefs.GetString("SelectedMode");
        //if (IntitializeAdmob.instance.IsStaticInterAvailable())//remove later
        //{
        //    LOADING.gameObject.SetActive(true);
        //    LOADING.staticInter = true;
        //    if (s == "ABCLearning")
        //    {
        //        LOADING.ActiveAfter = modes[0];
        //    }
        //    else if (s == "NumbersLearning")
        //    {
        //        LOADING.ActiveAfter = modes[1];
        //    }
        //    else if (s == "abcLearning")
        //    {
        //        LOADING.ActiveAfter = modes[2];
        //    }
        //}
        //else
        //{
            //if (PlayerPrefs.GetInt("RemoveAds") == 0)
            //{
            //    IntitializeAdmob.instance.ShowBanner();//remove later
            //}
            //if (s == "ABCLearning")
            //{
            //    modes[0].SetActive(true);
            //}
            //else if (s == "NumbersLearning")
            //{
            //    modes[1].SetActive(true);
            //}
            //else if (s == "abcLearning")
            //{
            //    modes[2].SetActive(true);
            //}
        //}
    }
    void Start()
    {
       // PlayerPrefs.SetInt("RemoveAdds", 1);
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            adult.DOAnchorPosY(-130, 0);
            setting.DOAnchorPosY(-130, 0);
            Titleobj.DOAnchorPosY(-150, 0);
            banner.gameObject.SetActive(false);
            //for (int i = 0; i < title.Length; i++)
            //{
            //    title[i].DOAnchorPosY(-130, 0);
            //}
        }
        if(PlaySoundAds.instance != null)
        {
            PlaySoundAds.instance.Off_Obj();
        }
        //BG.sprite = allbg[Random.Range(0, allbg.Length)];
        FindSelected();
    }
    public void Home()
    {
        //Vibration.Vibrate(50);
        PlayerPrefs.SetInt("Completed", 1);
        PlayerPrefs.SetInt("RateCounter", PlayerPrefs.GetInt("RateCounter") + 1);
        eventSystem.enabled = false;
        //InitializeFirebase_CB._Instance.LogFirebaseEvent("HomePressed_InSubSelection_On_" + PlayerPrefs.GetString("SelectedMode")+"_Mode");//remove later
        DOTween.KillAll(false);
        if (SoundHandle.instance.mySource.enabled == true)
        {
            SoundHandle.instance.PlaySource(SoundHandle.instance.selectCh);
        }
        Invoke(nameof(LoadH), SoundHandle.instance.selectCh.length);
    }
    public void SelectCharacter(AudioClip c)
    {
        PlayerPrefs.SetFloat("FillAmount", 0);
        PlayerPrefs.SetInt("TimePlayed", 0);
        var Alph = eventSystem.currentSelectedGameObject;
        PlayerPrefs.SetString("SelectedAlphabet", Alph.name);
        PlayerPrefs.SetString("PrevSelectedAlph", Alph.name);
        PlayerPrefs.SetFloat("ContentPos", Alph.transform.parent.GetComponent<RectTransform>().anchoredPosition.x);
        DOTween.KillAll(false);
        cameFrom = "ABCTrace";
        if (SoundHandle.instance.mySource.enabled == true)
        {
            SoundHandle.instance.PlaySource(c);
        }
        Invoke(nameof(LoadS), SoundHandle.instance.selectCh.length);
    
    }

    void LoadS()
    {
        //IntitializeAdmob.instance.ShowInterstitial();
        //if (RateUsHandler.Instance.rate.activeInHierarchy)
        //{
        //    RateUsHandler.Instance.Cross();
        //}
        //if (InappPanel.Instance)
        //{
        //    if (InappPanel.Instance.removeAdsPanel.activeInHierarchy)
        //    {
        //        InappPanel.Instance.RemoveInAppPanel();
        //    }
        //}
        SceneManager.LoadScene("ABCTrace");
    }
    void LoadH()
    {
        //IntitializeAdmob.instance.ShowInterstitial();
        //if (IntitializeAdmob.instance.IsStaticInterAvailable())
        //{
        //    LOADING.showBannerEnd = false;
        //    LOADING.loadNextScene = true;
        //    LOADING.staticInter = true;
        //    PlayerPrefs.SetString("ReloadScene", "MainSelection");
        //    LOADING.gameObject.SetActive(true);
        //}
        //else
        {
            //if (RateUsHandler.Instance.rate.activeInHierarchy)
            //{
            //    RateUsHandler.Instance.Cross();
            //}
            //if (InappPanel.Instance)
            //{
            //    if (InappPanel.Instance.removeAdsPanel.activeInHierarchy)
            //    {
            //        InappPanel.Instance.RemoveInAppPanel();
            //    }
            //}
            SceneManager.LoadScene("Selection");
        }
    }
}

