using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using MoreMountains.NiceVibrations;
//using DG.Tweening;
//using MoreMountains.NiceVibrations;
public class DragDropObaid : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    private Canvas canvas;
    private CanvasGroup canvasgroup;
    private RectTransform rectTransform;
    public bool Bounds = false;
    public GameObject Shadow;
    //public GameObject objectToInstantiate, FirstStrwabry,hand,arrow; // The prefab to instantiate
    //public Transform parentTransform, ObjPosition; // The parent transform for the instantiated objects
    //public float delay = 0.02f; // Delay between instantiations

    //private bool isSpawning = true, firstTime = true, vibrateobj = false;
    public void Start()
    {

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

    public void OnBeginDrag(PointerEventData eventData)
    {
  
    }
    public Vector2 minBounds; // Minimum x and y positions
    public Vector2 maxBounds; // Maximum x and y positions
    public void OnDrag(PointerEventData eventData)
    {
        
        if (Bounds)
        {
            // Adjust the position based on drag
            Vector2 newPosition = rectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;

            float clampedX = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
            rectTransform.anchoredPosition = new Vector2(clampedX, clampedY);

        }
        else
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {

        canvasgroup.alpha = 1f;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundManager.instance.PlayEffect_Instance(6);
        transform.SetAsLastSibling();
        if (SceneManager.GetActiveScene().name == "Puzzle")
        {
            //PuzzleMake.ins.OnColiiders();
        }
    }
    //IEnumerator SpawnObjectWithDelay()
    //{
    //    isSpawning = false;

    //    while (Input.GetMouseButton(0)) // Continue spawning while the mouse button is held down
    //    {
    //        GameObject newObject = Instantiate(objectToInstantiate, ObjPosition.transform.position, Quaternion.identity, parentTransform);
    //        yield return new WaitForSeconds(0.35f); // Wait for the specified delay
    //    }
    //    //MMVibrationManager.Vibrate();
    //    //isSpawning = false;
    //}
    //IEnumerator firstObj()
    //{
    //    //print("strt");
    //    yield return new WaitForSeconds(0.2f);
    //    FirstStrwabry.SetActive(true);
    //    yield return new WaitForSeconds(0.35f);
    //    StartCoroutine(SpawnObjectWithDelay());
    //    // yield return new WaitForSeconds(1f);
    //    //isSpawning = false;

    //}
    public void OnPointerUp(PointerEventData eventData)
    {
        //vibrateobj = false;
        if (SceneManager.GetActiveScene().name == "Puzzle")
        {
            //PuzzleMake.ins.OffColiiders();
        }
    }
    
    public void PlaySoundLoop(int num)
    {
      //  SoundManager.instance.PlayEffect_Loop(num);
    }
    public void StopSoundLoop(int num)
    {
     //   SoundManager.instance.StopEffect(num);
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !isSpawning) // 0 is for left mouse button
        //{
        //    StartCoroutine(SpawnObjectWithDelay());
        //    //MMVibrationManager.Vibrate();
        //}
        //if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
        //{
        //    vibrateobj = true;
        //    if (firstTime)
        //    {
        //  //      print("strt");
        //        firstTime = false;
        //        StartCoroutine(firstObj());
        //    }
        //    //vibrateobj = true;
        //    hand.SetActive(false);
        //    arrow.SetActive(false);
        //}
        //if (Input.GetMouseButtonUp(0)) // 0 is for left mouse button
        //{
        //    vibrateobj = false;
        //}
        //if (vibrateobj) // 0 is for left mouse button
        //{
        //    MMVibrationManager.Vibrate();
        //}
    }

}
