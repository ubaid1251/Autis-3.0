using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingHandle : MonoBehaviour
{
    public static SettingHandle instance;
    [HideInInspector]
    public GameObject panel;

    private void Start()
    {
        panel = transform.GetChild(0).gameObject;
        instance = this;
    }
    
    public void Cross()
    {
       transform.GetChild(0).GetComponent<Animator>().Play("PanelOut");
    }
}
