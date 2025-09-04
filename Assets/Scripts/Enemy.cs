using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float destroyThreshold = -0.707f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (ShouldDie(other))
        {
            Destroy(gameObject);
        }
    }

    private bool ShouldDie(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) return true;
        
        if (other.GetContact(0).normal.y < destroyThreshold) return true;

        return false;
    }
    
}
