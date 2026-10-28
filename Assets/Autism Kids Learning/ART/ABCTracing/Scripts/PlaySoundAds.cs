using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class PlaySoundAds : MonoBehaviour
{
    public static PlaySoundAds instance;
    public GameObject Obj;
    public GameObject PopUp;
    CanvasGroup cg;
    bool IsPopup=false;
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnEnable()
    {

    }
    void Start()
    {
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            Destroy(gameObject);
        }
        cg = PopUp.transform.parent.GetComponent<CanvasGroup>();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(IsPopup)
        {
            IsPopup=false;
            //IntitializeAdmob.instance.ShowBanner();
            PopUp.transform.DOScale(0.5f, .25f);
            cg.DOFade(0, .25f).OnComplete(() =>
           {
                PopUp.transform.parent.parent.gameObject.SetActive(false);
           });
        }
    }
    public void PlauSound()
    {
        SoundManager.instance.PlayEffect_Instance(4);
    }
    public void hidebanner()
    {
        //IntitializeAdmob.instance.HideBanner();
    }
    public void showbanner()
    {
        //IntitializeAdmob.instance.ShowBanner();
    }
    public void Off_Obj()
    {
        Obj.SetActive(false);
    }
    public void On_Obj()
    {
        if (PlayerPrefs.GetInt("RemoveAds") == 0)
        {
            Obj.SetActive(true);
        }
    }
    public void OpenPopUp()
    {
        SoundManager.instance.PlayEffect_Instance(4);
        IsPopup=true;
        //IntitializeAdmob.instance.HideBanner();
        PopUp.transform.parent.parent.gameObject.SetActive(true);
        PopUp.transform.DOScale(1, .25f);
        cg.DOFade(1, .25f);
    }
    public void ClosePopUp()
    {
        SoundManager.instance.PlayEffect_Instance(4);
        //IntitializeAdmob.instance.ShowBanner();
        IsPopup=false;
        PopUp.transform.DOScale(0.5f, .25f);
        cg.DOFade(0, .25f).OnComplete(() =>
        {
            PopUp.transform.parent.parent.gameObject.SetActive(false);
        });
    }
}
