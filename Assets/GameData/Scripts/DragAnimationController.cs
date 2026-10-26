using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
//using static UnityEditor.PlayerSettings;

public class DragAnimationController : MonoBehaviour
{
    public Animator animator;      // Animator with your animation
    public string animationName;   // Name of the animation clip
    public Slider progressSlider;
    public GameObject[] OnObjects;// UI Slider to sync
    public GameObject Cap,Phas4Obj,Fries;
    private AnimatorStateInfo stateInfo;
    private float normalizedTime;  // Animation progress [0..1]
     bool isDragging = false;
    private bool hasEnded = false; // To prevent multiple "end" prints
    Vector3 Pos;
    private Tween shakeTween;
    void Start()
    {
        Pos=GetComponent<Transform>().position;
        if (progressSlider != null)
        {
            progressSlider.minValue = 0f;
            progressSlider.maxValue = 1f;
        }

        // Start animation paused
        animator.speed = 0f;
    }

    void Update()
    {
        if (isDragging)
        {
            // Resume animation
            animator.speed = 1f;
        }
        else
        {
            // Pause animation
            animator.speed = 0f;
        }

        // Get animation state info
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Update normalized time
        normalizedTime = stateInfo.normalizedTime % 1f;

        // Sync slider
        if (progressSlider != null)
            progressSlider.value = normalizedTime;

        //print(normalizedTime);
        // Check for animation/slider complete
        if (normalizedTime >= 0.99f && !hasEnded)
        {
            //Debug.Log("Anim End");
            //SoundManager.instance.StopEffect(34);
            //FriesScene.Instance.Slider.SetActive(false);
            Destroy(GetComponent<BoxCollider2D>());
            animator.enabled = false;
            //Destroy(GetComponent<DragDropFries>());
            GetComponent<Transform>().DOMove(Pos, 0.5f);
            hasEnded = true;
            //FriesScene.Instance.MainCamera.DOOrthoSize(5.6f, 0.4f).OnComplete(() =>
            //{
            //    //FriesScene.Instance.MainCamera.DOOrthoSize(13f, 1f);
            //    //FriesScene.Instance.MainCamera.transform.DOMove(new Vector3(0f, -5f, -10), 1f)
            //    .OnComplete(() =>
            //    {
            //        Cap.transform.GetComponent<DOTweenAnimation>().DOPlay();
            //        Phas4Obj.transform.DOLocalMove(new Vector3(0f,-24f, 0f), 1f)
            //         .OnComplete(() =>
            //          {
            //              for (int i = 0; i < OnObjects.Length; i++)
            //              {
            //                  OnObjects[i].SetActive(true);
            //              }
            //              Fries.GetComponent<BoxCollider2D>().enabled=true;
            //    });
            //        Destroy(GetComponent<DragAnimationController>());

            //    });
            //});
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
       
        // Start shake rotation (if not already running)
        if (shakeTween == null || !shakeTween.IsActive())
        {
            //SoundManager.instance.PlayEffect_Loop(34);
            shakeTween = transform.DORotate(new Vector3(0, 0, 5f), 0.1f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        //SoundManager.instance.StopEffect(34);
        if (shakeTween != null && shakeTween.IsActive())
        {
            shakeTween.Kill();
            transform.rotation = Quaternion.identity; // reset back to normal
        }
    }
}