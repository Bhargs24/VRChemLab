using UnityEngine;

public class SaltTransfer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spatula"))
        {
            Spatula spatula = collision.gameObject.GetComponent<Spatula>();
            if (spatula != null)
            {
                spatula.PickUpSalt();
            }
        }
    }
}
