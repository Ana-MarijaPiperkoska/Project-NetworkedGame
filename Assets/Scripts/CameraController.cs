using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform target;  
    public Vector3 offset;   

    public float smoothSpeed = 0.125f;  

    private void LateUpdate()
    {
       
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            
            transform.LookAt(target);
        }
    }

   
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
    
    
    
    
    
    
    
    
    
    
 
