using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectionCards : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //IntitializeAdmob.instance.ShowInterstitial();
    }

    public void PlayClick()
    {
        SoundHandler.instance.PlayClick();

        //unityInAppPurchase_CB.instance.RestorePurchases();
    }
    public void LoadGameplay(int CardNum)
    {
                SoundHandler.instance.PlayClick();
        InitializeFirebase_CB.instance.LogFirebaseEvent("Selection_Category_Number_" + CardNum);
        PlayerPrefs.SetInt("CardCategory", CardNum);
        SceneManager.LoadScene("Gameplay");
    }
}
