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

        
        Vector3 baseScale = new Vector3(1f, 1f, 1f); 
        float scaleFactor = 1f + (saltAmount * 0.1f); 

        
        saltPrefab.transform.localScale = baseScale * scaleFactor;
    }

    public float GetSaltWeight()
    {
        return totalSaltWeight;
    }
}
