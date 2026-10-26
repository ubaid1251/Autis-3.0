using UnityEngine;

public class soundBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        ToyScript.ins.PlayEffectButtonSound();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
