using UnityEngine;

public class playReply : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        ToyScript.ins.PlaySound();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
