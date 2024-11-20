using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{

    public GameObject obj;

    Camera Cam;

    Vector2 InitialPos;

    int width;
    int NewWidth;



    // Start is called before the first frame update
    void Start()
    {
       Cam = Camera.main;

       InitialPos = obj.transform.position;

    }




    // Update is called once per frame
    void Update()
    {

        float OurAspect = 1920f / 1080f;

        float CurrentAspect = (float)Cam.pixelWidth / (float)Cam.pixelHeight;

        float Coeff = CurrentAspect / OurAspect;


        width = Cam.pixelWidth;


        if (width != NewWidth)
        {
            obj.transform.position = new Vector2(InitialPos.x * Coeff, obj.transform.position.y);
        }


        NewWidth = Cam.pixelWidth;

    }
}
