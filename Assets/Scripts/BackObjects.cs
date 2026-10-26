using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;
//using MoreMountains.NiceVibrations;
public class BackObjects : MonoBehaviour, IPointerUpHandler, IPointerDownHandler

{
    Vector3 Pos;
    bool picked = false;
    //public ParticleSystem Particl;
    //static int i = 0;
    public void OnPointerDown(PointerEventData eventData)
    {
        picked = false;
        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        Pos = GetComponent<RectTransform>().anchoredPosition;
        //if (GetComponent<Animator>() != null)
        //    {
        //        GetComponent<Animator>().enabled = false;
        //    }
    }
    private void Start()
    {
        //Pos = GetComponent<RectTransform>().position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        picked = true;
        Object.Destroy(GetComponent<Rigidbody2D>());
        if (picked)
        {
            GetComponent<RectTransform>().DOAnchorPos(Pos, .25f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Puzzle")
        {
            //if (PuzzleMake.ins.IsCollide)
            //{
                if (collision.gameObject.name == transform.GetComponent<DragDropObaid>().Shadow.gameObject.name)
                {
                    //print("yes");
                    Destroy(GetComponent<DragDropObaid>());
                    GetComponent<BackObjects>().enabled = false;
                    GetComponent<SetNewPos>().enabled = true;
                }
            //}
        }
        else
        {
            if (collision.gameObject.name == transform.GetComponent<DragDropObaid>().Shadow.gameObject.name)
            {
                //print("yes");
                Destroy(GetComponent<DragDropObaid>());
                GetComponent<BackObjects>().enabled = false;
                GetComponent<SetNewPos>().enabled = true;
            }
        }
    }


    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //}


}

