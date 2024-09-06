using UnityEngine;

public class Spatula : MonoBehaviour
{
    public GameObject saltPrefab;
    public Transform saltSpawnPoint;
    public float saltAmount = 5f;
    private bool hasSalt = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SaltBottle" && !hasSalt)
        {
            PickupSalt();
        }
        else if (collision.gameObject.name == "Dish" && hasSalt)
        {
            TransferSaltToDish(collision.gameObject);
        }
    }

    private void PickupSalt()
    {
        if (saltPrefab != null && saltSpawnPoint != null)
        {
            Instantiate(saltPrefab, saltSpawnPoint.position, Quaternion.identity, transform);
            hasSalt = true;
        }
    }

    private void TransferSaltToDish(GameObject dish)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Salt")
            {
                Destroy(child.gameObject);
                hasSalt = false;
                if (dish.TryGetComponent<Dish>(out Dish dishScript))
                {
                    dishScript.AddSalt(saltAmount);
                }
                break;
            }
        }
    }
}
