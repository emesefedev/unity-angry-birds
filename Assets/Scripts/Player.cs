using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camera;
    
    private Vector3 startPosition = new Vector3(-13, -2, 0);
    private Rigidbody2D rigidbody2D;

    private float maxLaunchRadius = 3f;
    private Vector3 launchDirection;
    
    private float launchForce = 25f;
    private float launchForceMultiplier;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        transform.position = startPosition;
        rigidbody2D.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        
        launchDirection = (startPosition - mousePosition).normalized;

        if (Vector3.Distance(mousePosition, startPosition) >= maxLaunchRadius)
        {
            transform.position = startPosition - launchDirection * maxLaunchRadius;
        }
        else
        {
            transform.position = mousePosition;    
        }
    }

    private void OnMouseUp()
    {
        rigidbody2D.isKinematic = false;
        
        launchForceMultiplier = Vector3.Distance(transform.position, startPosition) / maxLaunchRadius;
        rigidbody2D.velocity = launchDirection * launchForce * launchForceMultiplier;
    }
}
