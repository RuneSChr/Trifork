using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinchZoom : MonoBehaviour
{
  
    [SerializeField]
    private Camera main;

    private float prevTouchDeltaMag, touchDeltaMag, deltaMagnitudeDiff;
    private float zoomSpeed = 0.5f;
    private Vector2 touch0PrevFrame, touch1PrevFrame, touchZeroPrevPos, touchOnePrevPos;
    private Touch touchZero, touchOne;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 2)
        {
            //Current touches
            Touch touch0ThisFrame = Input.GetTouch(0);
            Touch touch1ThisFrame = Input.GetTouch(1);

            //touches last frame
            touch0PrevFrame = touch0ThisFrame.position - touch0ThisFrame.deltaPosition;
            touch1PrevFrame = touch1ThisFrame.position - touch1ThisFrame.deltaPosition;

            //deltas
            float previousTouchDeltaMagnitude = (touch0PrevFrame - touch1PrevFrame).magnitude;
            float currFrameTouchDeltaMagnitude = (touch0ThisFrame.position - touch1ThisFrame.position).magnitude;

            float deltaMagnitudeDifference = previousTouchDeltaMagnitude - currFrameTouchDeltaMagnitude;

            main.fieldOfView += deltaMagnitudeDifference * zoomSpeed;
            main.fieldOfView = Mathf.Clamp(main.fieldOfView, .1f, 179.9f);
            

            //touchTxt.text = "is it negative? " + (distance - tempDistance);


            // If there are two touches on the device...
            //    if (Input.touchCount == 2)
            //{
            //    // Store both touches.
            //    touchZero = Input.GetTouch(0);
            //    touchOne = Input.GetTouch(1);

            //    // Find the position in the previous frame of each touch.
            //    touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            //    touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //    // Find the magnitude of the vector (the distance) between the touches in each frame.
            //    prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            //    touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //    // Find the difference in the distances between each frame.
            //    deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            //    main.fieldOfView += deltaMagnitudeDiff * zoomSpeed;
            //    main.fieldOfView = Mathf.Clamp(main.fieldOfView, .1f, 179.9f);
        }
    }
}
