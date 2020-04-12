using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorHand : MonoBehaviour
{
    public Transform pivot;
    public Transform original;

    public Transform leftHandLocalPos;
    public Transform rightHandLocalPos;

    //public GameObject leftHand;
    //public GameObject rightHand;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // rightHand.transform.position = -leftHand.transform.position;  doesn't work like this
        //rightHand.transform.position = new Vector3(-leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z); //this works

        //  rightHand.transform.rotation = new Quaternion(leftHand.transform.rotation.x, leftHand.transform.rotation.y, leftHand.transform.rotation.z, leftHand.transform.rotation.w);
        // removed -1 from .y and added -1 to .z;
        //rightHand.transform.rotation = Quaternion.Euler(leftHand.transform.eulerAngles.x , leftHand.transform.eulerAngles.y, leftHand.transform.eulerAngles.z * -1);

        Quaternion inverse = Quaternion.Inverse(pivot.rotation);

        Vector3 forward = original.forward;
        Vector3 up = original.up;

        forward = inverse * forward;
        up = inverse * up;

        forward.x = -forward.x;
        up.x = -up.x;

        transform.rotation = pivot.rotation * Quaternion.LookRotation(forward, up);
        //Vector3 position = original.localPosition;
        //position.x = -position.x;// * 5;
        ////position.y = -position.y;// * 5;
        //transform.localPosition = position;

        Vector3 movePos = leftHandLocalPos.localPosition;
        movePos.x = -movePos.x;// * 5;
        //position.y = -position.y;// * 5;
        rightHandLocalPos.localPosition = movePos;
    }

    private void LateUpdate()
    {
        Update();
    }
}

