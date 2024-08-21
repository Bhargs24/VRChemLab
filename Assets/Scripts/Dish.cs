using UnityEngine;

public class Dish : MonoBehaviour
{
    private float totalSaltWeight = 0f; // Total weight of salt in the dish
    public Transform saltSpawnPointDish; // Transform point where salt appears in the dish

    public void AddSalt(GameObject salt, float weight)
    {
        totalSaltWeight += weight;
        Debug.Log("Total salt in dish: " + totalSaltWeight + " g");
        SnapSaltToPosition(salt);
    }

    public float GetTotalSaltWeight()
    {
        return totalSaltWeight;
    }

    private void SnapSaltToPosition(GameObject salt)
    {
        salt.transform.position = saltSpawnPointDish.position;
        salt.transform.rotation = saltSpawnPointDish.rotation;
        salt.transform.parent = saltSpawnPointDish;
    }
}
