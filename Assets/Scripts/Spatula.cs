using UnityEngine;

public class Spatula : MonoBehaviour
{
    public float capacity; // Capacity of the spatula in grams
    public GameObject substancePrefab; // Prefab for the salt

    private bool isHoldingSubstance = false;
    private GameObject heldSubstance;

    public Transform saltSpawnPointSpatula; // Transform point where salt appears on the spatula

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SaltBottle") && !isHoldingSubstance)
        {
            PickUpSalt();
        }
        else if (collision.gameObject.CompareTag("Dish") && isHoldingSubstance)
        {
            Dish dish = collision.gameObject.GetComponent<Dish>();
            if (dish != null)
            {
                dish.AddSalt(heldSubstance, capacity);
                isHoldingSubstance = false;
                heldSubstance = null;
            }
        }
    }

    public void PickUpSalt()
    {
        if (!isHoldingSubstance)
        {
            isHoldingSubstance = true;
            heldSubstance = Instantiate(substancePrefab, saltSpawnPointSpatula.position, saltSpawnPointSpatula.rotation);
            heldSubstance.transform.parent = saltSpawnPointSpatula;
        }
    }
}
