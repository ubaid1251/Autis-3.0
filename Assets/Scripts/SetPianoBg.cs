using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SetPianoBg : MonoBehaviour
{
    public static SetPianoBg ins;
    public List<GameObject> BGS;
    void Start()
    {
        ins = this;
    }

    // Update is called once per frame
     public void BgNew(int num)
    {
        print("aaaaaaa");
        for (int j = 0; j < BGS.Count; j++)
        {
            BGS[j].SetActive(false);
        }
        BGS[num].SetActive(true);
    }
}
