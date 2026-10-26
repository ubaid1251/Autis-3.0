using UnityEngine;

public class EffectSound : MonoBehaviour
{
    public bool Is_Effct = true;
    public AudioClip EfctSound;
    public static EffectSound ins;
    void Start()
    {
        ins = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
