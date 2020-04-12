using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class swimmer : MonoBehaviour
{
   
    //CharacterController cc;
    //CharacterMotor cm;
    public OVRPlayerController oc;
    public Color underWaterColor;

    public float underWaterLevel = 15;
    //public bool isGrounded = true;
    //public float JumpForce = 0.10f;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = false;

        //cc = GetComponent<CharacterController>();
        oc = GetComponent<OVRPlayerController>();
        //cm = GetComponent<CharacterMotor>();
    }

    bool IsUnderwater()
    {
        return transform.position.y < underWaterLevel;
    }

    //public bool Jump()
    //{
    //    if (!oc.isGrounded)
    //        return false;

    //    if (Input.GetKeyDown(KeyCode.JoystickButton9))
    //        { 
    //        new Vector3(0, transform.lossyScale.y * JumpForce, 0);
    //    }
    //    return true;
    //}

    // Update is called once per frame
    void Update()
    {

        //cm.jumping.enabled = !IsUnderwater();

        if (IsUnderwater())
        {
            //cm.movement.maxForwardSpeed = 2; 
            //cm.movement.maxSidewaysSpeed = 2;
            //cm.movement.maxBackwardsSpeed = 2;
            //cm.movement.maxFallSpeed = 2;

            //oc.Acceleration = 2;
            //oc.BackAndSideDampen = 2;

            RenderSettings.fog = true;
            RenderSettings.fogColor = underWaterColor ;
            RenderSettings.fogDensity = 0.04f;

            //cm.SetVelocity(new Vector3(cc.velocity.x, 3, cc.velocity.z));
        }
        else
        {
            //oc.Acceleration = 3;
            //oc.BackAndSideDampen = 3;
            //cm.movement.maxForwardSpeed = 12;
            //cm.movement.maxSidewaysSpeed = 9;
            //cm.movement.maxBackwardsSpeed = 9;
            //cm.movement.maxFallSpeed = 20;
            RenderSettings.fog = false;
        }
    }
}
