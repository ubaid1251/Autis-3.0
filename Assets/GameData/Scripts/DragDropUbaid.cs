using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class DragDropUbaid : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    private Canvas canvas, myCan;
    private CanvasGroup canvasgroup;
    private RectTransform rectTransform;
    private Sprite mySp;
    public bool canMoveInYOnly = false;
    bool triggerd=false;
    public AudioClip MySound;
    Vector3 Pos,startPos;
    bool startP = false;
    bool picked = false;

    public void Start()
    {
        myCan = GetComponent<Canvas>();
        GameObject obj = gameObject;
        mySp = GetComponent<Image>().sprite;

        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void Awake()

    {
        if (GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        if (canvas == null)
        {
            GameObject can = GameObject.Find("Canvas");
            canvas = can.GetComponent<Canvas>();
        }

        rectTransform = GetComponent<RectTransform>();
        
        canvasgroup = GetComponent<CanvasGroup>();
    }


    public void OnDrag(PointerEventData eventData)
    {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        canvasgroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundHandler.instance.PlaySource(0);
        myCan.sortingOrder = 10;
        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        picked = false;
        Pos =rectTransform.anchoredPosition;
        //if (startP == false)
        //{
        //    startP = true;
        //    startPos = Pos;
        //}
        //rectTransform.DOKill(false);
        rectTransform.DOScale(.65f, .25f).OnComplete(() =>
        {
            rectTransform.localScale = new Vector3(.65f, .65f, .65f);
        });
    }
   
    public void OnPointerUp(PointerEventData eventData)
    {
        SoundHandler.instance.PlaySource(1);

        if (gameObject.GetComponent<Collider2D>() != null)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }

        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        picked = true;
        //rectTransform.DOKill(false);
        if (picked)
        {
            GetComponent<DragDropUbaid>().enabled = false;
            rectTransform.DOJumpAnchorPos(Pos, 200, 1, .35f).OnComplete(()=> 
            {
                rectTransform.anchoredPosition = Pos;
                GetComponent<DragDropUbaid>().enabled = true;
            });
        }
        rectTransform.DOScale(0.52f, .25f).OnComplete(() =>
        {
            myCan.sortingOrder = 5;
            rectTransform.localScale = new Vector3(0.52f, 0.52f, 0.52f);
        });
        Destroy(GetComponent<Rigidbody2D>());

        if (triggerd)
        {
            if (ToyScript.ins.cardEntered)
            {
                ToyScript.ins.cardEntered.SetActive(true);
            }
            triggerd = false;
            ToyScript.ins.cardEntered=gameObject;
            ToyScript.ins.JumpDemoOnPlace(mySp,rectTransform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Machine")
        {
            triggerd = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        triggerd = false;
    }
}