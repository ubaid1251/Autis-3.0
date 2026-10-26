using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MainSelection : MonoBehaviour
{
    public GameObject BG_Img, Scroller;
    public GameObject[] selected, notSelected,allCategories ;
    int preSelected=0;
    public Sprite[] Bgs;
    int Categorynum;
    private void Start()
    {
        //IntitializeAdmob.instance.ShowInterstitial();
    }
    private void Awake()
    {
        Categorynum = PlayerPrefs.GetInt("CardCategory");
        notSelected[Categorynum].SetActive(false);
        selected[Categorynum].SetActive(true);
        allCategories[Categorynum].SetActive(true);
        BG_Img.GetComponent<Image>().sprite = Bgs[Categorynum];
        SetScrollerPos();
    }
    void SetScrollerPos()
    {
        float new_YPos = 0;
        if (Categorynum == 2)
        {
            new_YPos = 230;
        }
        else if (Categorynum == 3)
        {
            new_YPos = 423;
        }
        else if (Categorynum == 4)
        {
            new_YPos = 637;
        }
        else if (Categorynum == 5)
        {
            new_YPos = 837;
        }
        else if (Categorynum == 6)
        {
            new_YPos = 1052;
        }
        else if (Categorynum == 7)
        {
            new_YPos = 1065;
        }
        Scroller.transform.localPosition = new Vector3(0, new_YPos, 0);
    }
    public void SelectCategory(int catIndex)
    {
        SoundHandler.instance.PlayClick();
                //IntitializeAdmob.instance.ShowInterstitial();
        //InitializeFirebase_CB.instance.LogFirebaseEvent("Category_Number_" + catIndex);
        BG_Img.GetComponent<Image>().sprite = Bgs[catIndex];
        notSelected[preSelected].SetActive(true);
        notSelected[Categorynum].SetActive(true);
        selected[Categorynum].SetActive(false);
        selected[preSelected].SetActive(false);
        preSelected=catIndex;
        notSelected[preSelected].SetActive(false);
        selected[catIndex].SetActive(true);
        foreach (var item in allCategories)
        {
            item.SetActive(false);
        }
        allCategories[catIndex].SetActive(true);
        DO_ScrollerPos();
    }
    void DO_ScrollerPos()
    {
        float Set_YPos = 0;
        if (preSelected == 0 || preSelected == 1)
        {
            Set_YPos = 0;
        }
        if (preSelected == 2)
        {
            Set_YPos = 230;
        }
        else if (preSelected == 3)
        {
            Set_YPos = 423;
        }
        else if (preSelected == 4)
        {
            Set_YPos = 637;
        }
        else if (preSelected == 5)
        {
            Set_YPos = 837;
        }
        else if (preSelected == 6)
        {
            Set_YPos = 1052;
        }
        else if (preSelected == 7)
        {
            Set_YPos = 1065;
        }

        Scroller.transform.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, Set_YPos, 0), .25f);
    }
}