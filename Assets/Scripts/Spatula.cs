using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spatula : MonoBehaviour
{
    public float capacity; 
    public GameObject substancePrefab; 

    private bool isHoldingSubstance = false;
    private GameObject heldSubstance;

    public Transform saltSpawnPointSpatula; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SaltBottle") && !isHoldingSubstance)
        {
            PickUpSalt();
        }
        else if (other.CompareTag("Dish") && isHoldingSubstance)
        {
            Dish dish = other.GetComponent<Dish>();
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
