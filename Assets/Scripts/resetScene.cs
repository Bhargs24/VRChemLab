using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class resetScene : MonoBehaviour
{
    public float pressThreshold = 0.05f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }
    void Update()
    {
        // Check if the button is pressed
        if (Mathf.Abs(transform.localPosition.z - initialPosition.z) > pressThreshold)
        {
            ResetCurrentScene();
        }
    }

    void ResetCurrentScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
