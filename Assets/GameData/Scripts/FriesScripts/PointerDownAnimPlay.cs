using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDownAnimPlay : MonoBehaviour
{
    public string animationName = "MyAnim"; // Set in Inspector
     Animation anim;
    public GameObject AnimationObject;
    public bool OtherThings= false; // Set in Inspector
    void Start()
    {
        
    }

    void Awake()
    {
        anim = AnimationObject.GetComponent<Animation>();
        if (anim == null)
        {
            Debug.LogWarning("No Animator found on " + gameObject.name);
        }
    }

    void OnMouseDown()
    {
        if (anim != null && !string.IsNullOrEmpty(animationName))
        {
            anim.Play(animationName);
        }

        GetComponent<Collider2D>().enabled = false; // Disable collider on mouse down
    }
    void Update()
    {
        
    }
}
