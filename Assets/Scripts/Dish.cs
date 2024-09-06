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
        /*if (saltPrefab != null && saltSpawnPoint != null)
        {
            GameObject saltVisual = Instantiate(saltPrefab, saltSpawnPoint.localPosition, Quaternion.identity);
            float scaleMultiplier = saltAmount / 5f;
            saltVisual.transform.localScale *= scaleMultiplier;
            saltVisual.transform.SetParent(saltSpawnPoint);
        }*/
        saltPrefab.SetActive(true);
        // float scaleFactor = totalSaltWeight;
        saltPrefab.transform.localScale *= totalSaltWeight;

    }

    public float GetSaltWeight()
    {
        return totalSaltWeight;
    }
}
