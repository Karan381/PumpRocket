using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rocketbody;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float ThrustValue = 1f;
    [SerializeField] float RotateValue = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rocketbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(mainEngine);
            }    
            rocketbody.AddRelativeForce(Vector3.up * Time.deltaTime * ThrustValue);
        }
        else
        {
            audioSource.Stop();
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
        rocketbody.freezeRotation = true; //freezing rotation so that we can rotate manually
        transform.Rotate(Vector3.forward * Time.deltaTime * RotationThisFrame);
        rocketbody.freezeRotation = false;//freezing rotation so that physics system can take over;
    }
}
