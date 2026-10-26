using UnityEngine;

public class CheckLock : MonoBehaviour
{
    public GameObject ParentPos,ObjRemove;
    void Start()
    {
      if(PlayerPrefs.GetInt("RemoveAds")==1)
      {
         ParentPos.transform.localPosition = new Vector3(0f, 112f, 0f);
         ObjRemove.SetActive(false);
      }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
