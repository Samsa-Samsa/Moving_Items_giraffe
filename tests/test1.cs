using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{


    public int MaxAngle;
    public int Speed;

    float Angle;

    bool Rocking;
    bool LeftFinished;
    bool RightFinished;


    void HandleRocking()
    {
        if (Rocking)
        {
            if (Angle < MaxAngle && !LeftFinished)
            {
                Angle = Mathf.Lerp(Angle, Angle + 5, Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, Angle);
            }
            else if (Angle >= MaxAngle)
            {
                LeftFinished = true;
            }


            if (Angle > -MaxAngle && !RightFinished && LeftFinished)
            {
                Angle = Mathf.Lerp(Angle, Angle - 5, Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, Angle);
            }
            else if (Angle <= -MaxAngle)
            {
                RightFinished = true;
            }


            if (Angle < 0 && LeftFinished && RightFinished)
            {
                Angle = Mathf.Lerp(Angle, Angle + 5, Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, Angle);
            }
            else if (LeftFinished && RightFinished)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                LeftFinished = false;
                RightFinished = false;
                Rocking = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        HandleRocking();

        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rocking = true;
        }
        
    }
}
