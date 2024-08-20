using UnityEngine;

public class SaltTransfer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spatula"))
        {
            Spatula spatula = other.GetComponent<Spatula>();
            if (spatula != null)
            {
                spatula.PickUpSalt();
            }
        }
    }
}
