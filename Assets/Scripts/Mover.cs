using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rocketbody;
    [SerializeField] float ThrustValue = 1f;
    [SerializeField] float RotateValue = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rocketbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

   void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketbody.AddRelativeForce(Vector3.up * Time.deltaTime * ThrustValue);
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(RotateValue);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-RotateValue);
        }
    }

    private void ApplyRotation(float RotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotationThisFrame);
    }
}
