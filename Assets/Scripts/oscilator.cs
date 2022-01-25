using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilator : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    
    
    void Start()
    {
        startPos = transform.position;
        Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave + 1f) / 2f; 
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPos + offset;
    }
}
