using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class LockedCards : MonoBehaviour, IPointerDownHandler
{
    public Animator eye1,eye2;
    private void Awake()
    {
       
        if (PlayerPrefs.GetInt("Purchased") == 1)
        {
           Destroy(gameObject);
        }
        else
        {
            Invoke("wait1", 0.1f);
        }
    }
    void wait1() 
    {
        transform.parent.GetComponent<DragDropUbaid>().enabled = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        DOTween.KillAll(false);
        PlayerPrefs.SetInt("FirstAnim", 0);
        SoundHandler.instance.PlayClick();
        PlayerPrefs.SetString("CameFrom", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Inapp_Scene");
    }
}

