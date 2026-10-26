using UnityEngine;

public class DestroyScripts : MonoBehaviour
{
    public GameObject[] LockObj;
    void Start()
    {
        for(int i=0; i< LockObj.Length;i++)
        {
           Destroy(LockObj[i].GetComponent<LockedCards>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
