using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class BackObject : MonoBehaviour//, IPointerUpHandler, IPointerDownHandler
{
    //Vector3 Pos;
    //bool picked = false;
    //bool IS_Down = false;

    Canvas myCan;

    //private void Start()
    //{
    //    myCan = GetComponent<Canvas>();
    //}
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    picked = false;
    //    if (IS_Down == false)
    //    {
    //        Pos = GetComponent<RectTransform>().anchoredPosition;
    //        IS_Down = true;
    //    }
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    picked = true;
    //    if (picked)
    //    {
    //        GetComponent<RectTransform>().DOJumpAnchorPos(Pos, 200, 1, .35f).OnComplete(() =>
    //        {
    //            myCan.sortingOrder = 5;
    //            IS_Down = false;
    //        });
    //    }
    //}

}

