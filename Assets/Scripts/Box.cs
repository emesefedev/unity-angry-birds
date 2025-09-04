using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private int contacts = 2;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            contacts--;
            if (ShouldDie()) Destroy(gameObject);
        }
    }

    private bool ShouldDie()
    {
        return contacts <= 0;
    }
}
