using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
   //Cache Ref
    
    Rigidbody rocketbody;
    AudioSource audioSource;

    //Parameters

    [SerializeField] AudioClip mainEngine;
    [SerializeField] float ThrustValue = 1f;
    [SerializeField] float RotateValue = 1f;
    [SerializeField] ParticleSystem mainbooster;
    [SerializeField] ParticleSystem rightsidebooster;
    [SerializeField] ParticleSystem leftsidebooster;

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }
        else
        {
            StopRotation();
        }
    }

//Thrusting
    private void StartThrusting()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainEngine);
            mainbooster.Play();
        }
        rocketbody.AddRelativeForce(Vector3.up * Time.deltaTime * ThrustValue);
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainbooster.Stop();
    }

   
//Rotating
 

    private void RotateLeft()
    {
        if (!leftsidebooster.isPlaying)
        {
            leftsidebooster.Play();
        }
        ApplyRotation(RotateValue);
    }
    private void RotateRight()
    {
        if (!rightsidebooster.isPlaying)
        {
            rightsidebooster.Play();
        }
        ApplyRotation(-RotateValue);
    }

    private void StopRotation()
    {
        leftsidebooster.Stop();
        rightsidebooster.Stop();
    }

    private void ApplyRotation(float RotationThisFrame)
    {
        rocketbody.freezeRotation = true; //freezing rotation so that we can rotate manually
        transform.Rotate(Vector3.forward * Time.deltaTime * RotationThisFrame);
        rocketbody.freezeRotation = false;//freezing rotation so that physics system can take over;
    }
}
