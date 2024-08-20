using UnityEngine;
using System.Collections; 

public class RespawnManager : MonoBehaviour
{
    public Transform respawnPoint; 
    public float respawnDelay = 2f; 

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isRespawning = false;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void Respawn()
    {
        if (!isRespawning)
        {
            isRespawning = true;
            StartCoroutine(RespawnCoroutine());
        }
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        isRespawning = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RespawnArea"))
        {
            Respawn();
        }
    }
}
