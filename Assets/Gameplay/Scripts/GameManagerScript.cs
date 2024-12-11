using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public AudioManagerScript audioManagerScript;

    public ResponsivePosition responsivePosition;

    public Transform SlotSamplePos;
    public Transform SlotInCartPos;

    public AnimationCurve TrajectoryCurve;

    public float ItemTimeToReachBasket;
    public float ItemHeightMultiplier;

    public float GuidingTimer;
    public float GuidingDuration;

    public int ItemRockingSpeed;
    public int ItemMaxRockingAngle;

    public GameObject TextHolder;

    public GameObject BasketVxf;
    public GameObject KonfetiVfx;
    public GameObject[] FireWorkVfxes;
    public GameObject Guider;
    //public Animator GuiderAnimator;

    public SkeletonAnimation skeletonAnimation;

    public List<GameObject> SlotSamples = new List<GameObject>();
    public GameObject[] Slots;


    [HideInInspector]
    public int SlotsCollected;

    [HideInInspector]
    public float ScreenRatioNum;


    [HideInInspector]
    public static string CurrentSlotTag;

    //[HideInInspector]
    //public List<GameObject> VisibleSlots = new List<GameObject>();


    Coroutine Co;

    bool HappyFinished;
    bool GuidingStarted;


    void ShufleList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public float FireworkExplosionInterval;




    IEnumerator HandleFireworks()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < FireWorkVfxes.Length; i++)
        {
            FireWorkVfxes[i].SetActive(true);
            audioManagerScript.PlayFireworksSound();
            yield return new WaitForSeconds(FireworkExplosionInterval);
        }
    }


    void PlayWiningAction()
    {
        KonfetiVfx.SetActive(true);
        StartCoroutine(HandleFireworks());

    }


    public void SetSampleSlot()
    {
        if (SlotSamples.Count > 0)
        {
            // changing target item is executing here
            GameObject obj = Instantiate(SlotSamples[0]);
            obj.transform.position = SlotSamplePos.position;

            obj.transform.localScale = new Vector2(obj.transform.localScale.x * responsivePosition.GetScreenRatio(),
                obj.transform.localScale.y * responsivePosition.GetScreenRatio());

            obj.transform.parent = null;

            CurrentSlotTag = obj.tag;
            SlotSamples.RemoveAt(0);
        }
        else
        {
            // finishing game action can be executed here
            //print("Win");
            PlayWiningAction();
            //TextHolder.SetActive(true);
        }
    }



    public void ChangeAnimation()
    {
        HappyFinished = false;
        skeletonAnimation.loop = false;
        skeletonAnimation.AnimationName = "Happy";
    }


    void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (!HappyFinished)
        {
            //print("ehee");
            skeletonAnimation.loop = true;
            skeletonAnimation.AnimationName = "Idle";

            HappyFinished = true;
        }

    }




    GameObject TargetedSlot;

    void GetActiveSlot()
    {
        if (!GuidingStarted) 
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].tag == CurrentSlotTag)
                {
                    TargetedSlot = Slots[i];
                    GuidingStarted = true;
                }
            }
        }
    }


    public void DeactivateGuiding()
    {
        Guider.SetActive(false);
        GuidingStarted = false;

        if(Co != null)
        {
            StopCoroutine(Co);
        }

        Co = StartCoroutine(InactivityTimer());
    }

    IEnumerator InactivityTimer()
    {

        yield return new WaitForSeconds(GuidingTimer);

        GetActiveSlot();
    }
     
    IEnumerator GuiderTimer()
    {

        yield return new WaitForSeconds(GuidingDuration);

        DeactivateGuiding();
    }



    public IEnumerator DelayItemChange()
    {
        BasketVxf.SetActive(false);
        BasketVxf.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        audioManagerScript.PlayEvaluationSound();

        // yield return new WaitForSeconds(audioManagerScript.EvaluationSound.length);
        yield return new WaitForSeconds(0);

        print("change");
        audioManagerScript.PlayItemChangeSound();

        SetSampleSlot();

        // BasketVxf.SetActive(false);
        // BasketVxf.SetActive(true);

    }

    void HandleGuiding()
    {
        if (GuidingStarted)
        {

            Guider.transform.position = TargetedSlot.transform.position;

            if (TargetedSlot.GetComponent<SlotScript>().IsVisible && !Guider.activeSelf)
            {
                StartCoroutine(GuiderTimer());
                Guider.SetActive(true);
                //Guider.transform.parent = TargetedSlot.transform;
                //Guider.transform.localPosition = new Vector2(0, 0);

                //GuiderAnimator.SetTrigger("Bounce");

                print("guiding");
            }
        }
    }


    void Start()
    {

        ShufleList(SlotSamples);
        SetSampleSlot();

        Co = StartCoroutine(InactivityTimer());

        // setting target framerate temporarely, can be removed in future
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        skeletonAnimation.AnimationState.Complete += OnAnimationComplete;

        HandleGuiding();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //PlayWiningAction();

            //StartCoroutine(InactivityTimer());

        }
    }
}
