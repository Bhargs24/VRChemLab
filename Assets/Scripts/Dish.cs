using UnityEngine;

public class Dish : MonoBehaviour
{
    private float totalSalt = 0f;
    public Transform saltSpawnPointDish; 

    public void AddSalt(GameObject salt, float weight)
    {
        totalSalt += weight;
        Debug.Log("Total salt in dish: " + totalSalt + " g");
        SnapSaltToPosition(salt);
    }

    public float GetSaltWeight()
    {
        return totalSalt;
    }

    private void SnapSaltToPosition(GameObject salt)
    {
        salt.transform.position = saltSpawnPointDish.position;
        salt.transform.rotation = saltSpawnPointDish.rotation;
        salt.transform.parent = saltSpawnPointDish; 
    }
}
