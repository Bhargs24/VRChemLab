using UnityEngine;

public class Dish : MonoBehaviour
{
    public Transform saltSpawnPoint;
    private GameObject saltPrefab;
    private float totalSaltWeight = 0f;

    private void Awake()
    {
        saltPrefab = this.transform.Find("salt").gameObject;
    }
    public void AddSalt(float saltAmount)
    {
        totalSaltWeight += saltAmount;
        InstantiateSaltVisual(totalSaltWeight);
    }

    private void InstantiateSaltVisual(float saltAmount)
    {
        
        saltPrefab.SetActive(true);
        
        saltPrefab.transform.localScale *= totalSaltWeight;

    }

    public float GetSaltWeight()
    {
        return totalSaltWeight;
    }
}
