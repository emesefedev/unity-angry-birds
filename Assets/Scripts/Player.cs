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

    private float maxDistance = 3f;
    private Vector3 launchDirection;

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

        if (Vector3.Distance(mousePosition, startPosition) >= maxDistance)
        {
            transform.position = startPosition - launchDirection * maxDistance;
        }
        else
        {
            transform.position = mousePosition;    
        }
        
        
    }
}
