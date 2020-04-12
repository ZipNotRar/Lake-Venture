using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimMovement : MonoBehaviour
{

    public Transform hand;
    public Transform forward;
    private Vector3 previousHandPosition;
    private CharacterController controller;
    public float speed = 5;
    private float lerpSpeed;
    public float minSpeed = .1f;

    // Start is called before the first frame update
    void Awake()
    {
        previousHandPosition = ReferencePosition();
        controller = GetComponent<CharacterController>();

    }

    private Vector3 ReferencePosition()
    {
        return hand.position;
    }

    private void MovePlayer()
    {
        Vector3 currentHandPosition = ReferencePosition();

        Vector3 controllerMovement = currentHandPosition - previousHandPosition;

        float forwardMovement = Vector3.Dot(-forward.transform.forward, controllerMovement);

        if (forwardMovement > 0)
        {
            lerpSpeed += forwardMovement * 1.5f;


        }

        if (lerpSpeed > 0)
        {
            controller.Move(forward.transform.forward * lerpSpeed * speed);
            lerpSpeed -= minSpeed;
            if (lerpSpeed < 0)
            {
                lerpSpeed = 0;
            }
        }

        previousHandPosition = currentHandPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
