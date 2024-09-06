using UnityEngine;

public class Dish : MonoBehaviour
{
    public Transform saltSpawnPoint;
    public GameObject saltPrefab;
    private float totalSaltWeight = 0f;

    public void AddSalt(float saltAmount)
    {
        totalSaltWeight += saltAmount;
        InstantiateSaltVisual(saltAmount);
    }

    private void InstantiateSaltVisual(float saltAmount)
    {
        if (saltPrefab != null && saltSpawnPoint != null)
        {
            GameObject saltVisual = Instantiate(saltPrefab, saltSpawnPoint.position, Quaternion.identity);
            float scaleMultiplier = saltAmount / 5f;
            saltVisual.transform.localScale *= scaleMultiplier;
            saltVisual.transform.SetParent(saltSpawnPoint);
        }
    }

    public float GetSaltWeight()
    {
        return totalSaltWeight;
    }
}
