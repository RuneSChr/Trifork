using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinchZoom : MonoBehaviour
{
    [SerializeField]
    private TMP_Text touchTxt;

    private float distance, tempDistance, distanceDelta0, distanceDelta1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 2)
        {
            Vector2 touch0, touch1;
            touch0 = Input.GetTouch(0).position;
            touch1 = Input.GetTouch(1).position;
            print(touch0);
            distance = Vector2.Distance(touch0, touch1);
            if (distance > tempDistance)
            {

                float z = gameObject.transform.position.z;
                touchTxt.text = "Distance " + distance;
                gameObject.transform.position += new Vector3(0, 0, z / 100);
            }
        }
    }

}
