using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public AudioManagerScript audioManagerScript;

    public Transform SlotSamplePos;
    public Transform SlotInCartPos;

    public AnimationCurve TrajectoryCurve;

    public float ItemTimeToReachBasket;
    public float ItemHeightMultiplier;

    public int ItemRockingSpeed;
    public int ItemMaxRockingAngle;

    public GameObject TextHolder;

    public GameObject BasketVxf;

    public SkeletonAnimation skeletonAnimation;

    public List<GameObject> SlotSamples = new List<GameObject>();


    [HideInInspector]
    public int SlotsCollected;

    [HideInInspector]
    public static string CurrentSlotTag;


    bool HappyFinished;




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


    public void SetSampleSlot()
    {
        if (SlotSamples.Count > 0)
        {
            // changing target item is executing here
            GameObject obj = SlotSamples[0];
            obj.transform.position = SlotSamplePos.position;
            Instantiate(obj);
            CurrentSlotTag = obj.tag;
            SlotSamples.RemoveAt(0);
        }
        else
        {
            // finishing game action can be executed here
            print("Win");
            audioManagerScript.PlayFinishingSound();
            TextHolder.SetActive(true);
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




    public IEnumerator DelayItemChange()
    {

        yield return new WaitForSeconds(0.5f);

        audioManagerScript.PlayEvaluationSound();

        yield return new WaitForSeconds(audioManagerScript.EvaluationSound.length);

        print("change");
        audioManagerScript.PlayItemChangeSound();

        SetSampleSlot();

        BasketVxf.SetActive(false);
        BasketVxf.SetActive(true);

    }


    void Start()
    {

        ShufleList(SlotSamples);
        SetSampleSlot();
        
        // setting target framerate temporarely, can be removed in future
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        skeletonAnimation.AnimationState.Complete += OnAnimationComplete;
    }
}
