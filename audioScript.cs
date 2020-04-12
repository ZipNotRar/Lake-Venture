using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    public GameObject OVRplayer;
    public AudioSource sound;

    private void Sunet()
    {
        if(OVRplayer.transform.position.y < 4)
        {
            Debug.Log("Merge sunetul");
            sound.Play();
        }
    }
}
