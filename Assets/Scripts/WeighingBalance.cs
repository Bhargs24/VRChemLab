using UnityEngine;
using TMPro;

public class WeighingBalance : MonoBehaviour
{
    private Vector3 snapPosition;
    public GameObject weightDisplay;
    private float currentWeight = 0f;
    private float dishWeight = 25f;
    private bool isBalanceOn = false, tared = false;
    private float tareWeight = 0f;
    private string currentUnit = "g";
    private TextMeshProUGUI textComponent;
    public Dish dishScript;

    private void Start()
    {
        snapPosition = new Vector3(0.139799997f, 0.647000015f, -3.68799996f);
        textComponent = weightDisplay.GetComponent<TextMeshProUGUI>();
        weightDisplay.SetActive(false);
    }

    private void Update()
    {
        if (isBalanceOn)
        {
            UpdateWeightDisplay(tared);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        placeDishInMachine(other);
    }

    private void OnTriggerStay(Collider other)
    {
        placeDishInMachine(other);
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Dish")
        {
            currentWeight = 0f;
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    private void placeDishInMachine(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Dish")
        {
            currentWeight = dishScript.GetSaltWeight() + dishWeight;
            rb.useGravity = false;
            rb.isKinematic = true;
            other.gameObject.transform.position = snapPosition;
            other.gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }

    public void TareScale()
    {
        tared = !tared;
        UpdateWeightDisplay(tared);
    }

    public void ChangeUnit()
    {
        switch (currentUnit)
        {
            case "g":
                currentUnit = "kg";
                currentWeight /= 1000f;
                tareWeight /= 1000f;
                break;
            case "kg":
                currentUnit = "mg";
                currentWeight *= 1000f * 1000f;
                tareWeight *= 1000f * 1000f;
                break;
            case "mg":
                currentUnit = "g";
                currentWeight /= 1000f * 1000f;
                tareWeight /= 1000f * 1000f;
                break;
        }
        UpdateWeightDisplay(tared);
    }

    public void UpdateWeightDisplay(bool tared)
    {
        if (currentWeight == 0f)
        {
            textComponent.text = "0.00 " + currentUnit;
            return;
        }
        tareWeight = currentWeight - dishWeight;
        if (isBalanceOn)
        {
            if (tared)
                textComponent.text = tareWeight.ToString("F2") + " " + currentUnit;
            else
                textComponent.text = currentWeight.ToString("F2") + " " + currentUnit;
        }
    }

    public void OnOffButton(bool b)
    {
        weightDisplay.SetActive(b);
        isBalanceOn = b;
    }
}