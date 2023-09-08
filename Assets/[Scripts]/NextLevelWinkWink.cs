using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelWinkWink : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // If the player collides with the object, load the next level
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the next level
            SceneManager.LoadScene(1);
        }
    }
}
