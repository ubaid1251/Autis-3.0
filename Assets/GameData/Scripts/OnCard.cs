using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnCard : MonoBehaviour
{
    public static OnCard instance;
    void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag($"card"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            
            collision.GetComponent<Image>().enabled = false;
        }
    }
}
