using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCopy : MonoBehaviour
{
    public Transform original;
    public Transform mirror;
    public Transform trackingRotation;

    // Start is called before the first frame update
    public void LateUpdate()
    {
        //enable the line 14-18
        Mirror(original, mirror);
        Vector3 eulerAngle = trackingRotation.localRotation.eulerAngles;
        eulerAngle.y *= -1; 
        transform.localRotation = Quaternion.Euler(eulerAngle);

        //Vector3 scale = mirror.transform.localScale;
        //scale.x = -original.transform.localScale.x;
        //mirror.localScale = scale;
    }

    // Update is called once per frame
    private void Mirror(Transform original, Transform mirror)
    {
        mirror.localPosition = original.localPosition;
        mirror.localRotation = original.localRotation;
        mirror.localScale = original.localScale;

        //try disabling it
        //transform.localRotation = trackingRotation.localRotation;
        int childCount = original.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Mirror(original.GetChild(i), mirror.GetChild(i));
        }
    }
}
