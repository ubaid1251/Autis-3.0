using UnityEngine;

public class SetModeTrace : MonoBehaviour
{
    public int SetInt = 1;
     void Start()
    {
        PlayerPrefs.SetInt("ModeTrace", SetInt);
        print(PlayerPrefs.GetInt("ModeTrace"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
