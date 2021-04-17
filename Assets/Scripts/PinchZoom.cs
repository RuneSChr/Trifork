using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinchZoom : MonoBehaviour
{
    [SerializeField]
    private TMP_Text touchTxt,distanceTxt;
    [SerializeField]
    private Camera main;

    private float distance, tempDistance, distanceDelta0, distanceDelta1,deltaDistance,deltaDistanceDiff;
    private float zoomSpeed = 0.5f;

    [SerializeField]
    private Vector2 touch0ThisFrame, touch1ThisFrame, touch0PrevFrame,touch1PrevFrame;

    // Start is called before the first frame update
    void Start()
    {
        distanceTxt.text = "start";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 2)
        {

            touch0ThisFrame = Input.GetTouch(0).position;
            touch1ThisFrame = Input.GetTouch(1).position;
            distance = Vector2.Distance(touch0ThisFrame, touch1ThisFrame);
            touch0PrevFrame = Input.GetTouch(0).deltaPosition;
            touch1PrevFrame = Input.GetTouch(1).deltaPosition;
            tempDistance = Vector2.Distance(touch0PrevFrame, touch1PrevFrame);

            deltaDistance = tempDistance - distance;

            distanceTxt.text = deltaDistance + "";

            main.fieldOfView += deltaDistance * .05f;
            if (distance > tempDistance)
            {

                //distanceTxt.text = distance - tempDistance + "";
                
            }
            
        }
    }

}
