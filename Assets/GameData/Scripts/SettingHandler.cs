using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingHandler : MonoBehaviour
{
    public static SettingHandler instance;
    public RectTransform panel;
    CanvasGroup cg;
    public Slider sfxSlider, bgmSlider;
    public SoundHandler soundHandler;
    public bool isUiActive = false;
    private void Start()
    {
        if(PlayerPrefs.GetInt("firstT")==0)
        {
            PlayerPrefs.SetInt("firstT",1);
            PlayerPrefs.SetFloat("sfxVolume",1f);
            PlayerPrefs.SetFloat("bgmVolume",.05f);
        }
        var sfxV = PlayerPrefs.GetFloat("sfxVolume");
        var bgmV = PlayerPrefs.GetFloat("bgmVolume");
        soundHandler.mySource.volume = sfxV;
        soundHandler.bgm.volume = bgmV;
        soundHandler.SetAllSfx(sfxV);
        cg = panel.GetComponent<CanvasGroup>();
        sfxSlider.value = sfxV;
        bgmSlider.value = bgmV;
        instance = this;
    }
    public void ShowPanel()
    {
        isUiActive = true;
        soundHandler.PlayTap();
        panel.transform.parent.gameObject.SetActive(true);
        panel.DOScale(1, .25f);
        cg.DOFade(1, .25f);
    }
    public void Cross()
    {
        soundHandler.PlayTap();
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("bgmVolume",bgmSlider.value);
        
        panel.DOScale(.5f, .25f);
        cg.DOFade(0, .25f).OnComplete(()=>
        {
            isUiActive = false;
            panel.transform.parent.gameObject.SetActive(false);
        });
    }
    public void ChangeBgm()
    {
        soundHandler.bgm.volume = bgmSlider.value;
    }
    public void ChangeSfx()
    {
        soundHandler.mySource.volume = sfxSlider.value;
        soundHandler.SetAllSfx(sfxSlider.value);
    }
    public void VisitLink(string link)
    {
        soundHandler.PlayClick();
        Application.OpenURL(link);
    }
}
