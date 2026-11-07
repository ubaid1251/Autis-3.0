using KidsItemsSort;
using UnityEngine;

public class LoadTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnEnable()
    {
        //IntitializeAdmob.Instance.ShowBanner();
        //IntitializeAdmob.Instance.HideBigBanner();
        GameManager.instance.Ui_Off();
        if (GameManager.instance.IsHomePress == false)
        {
            GameManager.instance.LoadingPanel.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
