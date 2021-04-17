using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinchZoom : MonoBehaviour
{
    [SerializeField]
    private TMP_Text touchTxt, distanceTxt;
    [SerializeField]
    private Camera main;

    private float distance, tempDistance, distanceDelta0, distanceDelta1, deltaDistance, deltaDistanceDiff;
    private float zoomSpeed = 0.5f;

    [SerializeField]
    private Vector2 touch0PrevFrame, touch1PrevFrame;

    // Start is called before the first frame update
    void Start()
    {
        distanceTxt.text = "start";
        touchTxt.text = "touchstart";
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount >= 2)
        //{
        //    //Current touches
        //    Touch touch0ThisFrame = Input.GetTouch(0);
        //    Touch touch1ThisFrame = Input.GetTouch(1);

        //    //touches last frame
        //    touch0PrevFrame = touch0ThisFrame.position - touch0ThisFrame.deltaPosition;
        //    touch1PrevFrame = touch1ThisFrame.position - touch1ThisFrame.deltaPosition;

        //    //deltas
        //    float previousTouchDeltaMagnitude = (touch0PrevFrame - touch1PrevFrame).magnitude;
        //    float currFrameTouchDeltaMagnitude = (touch1ThisFrame.position - touch1ThisFrame.position).magnitude;

        //    float deltaMagnitudeDifference = previousTouchDeltaMagnitude - currFrameTouchDeltaMagnitude;

        //    //main.fieldOfView += deltaMagnitudeDifference * .005f;
        //    //main.fieldOfView = Mathf.Clamp(main.fieldOfView, .1f, 179.9f);
        //    //deltaDistance = distance - tempDistance;

        //    distanceTxt.text = "is it ortho? " + deltaMagnitudeDifference;
        //    //touchTxt.text = "is it negative? " + (distance - tempDistance);



        //}
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            main.fieldOfView += deltaMagnitudeDiff * .05f;
            main.fieldOfView = Mathf.Clamp(main.fieldOfView, .1f, 179.9f);
        }
    }
}
