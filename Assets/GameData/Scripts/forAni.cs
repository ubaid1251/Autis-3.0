using UnityEngine;

public class forAni : MonoBehaviour
{
    public GameObject obj;

    // Update is called once per frame
    public void Animoff()
    {
        GetComponent<Animator>().enabled = false;
        obj.SetActive(false);
    }
    public void offAnimoff()
    {
        GetComponent<Animator>().enabled = false;

    }
}
