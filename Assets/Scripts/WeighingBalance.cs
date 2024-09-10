using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeighingBalance : MonoBehaviour
{
    private Vector3 snapPosition;
    public TextMeshProUGUI weightDisplay;
    public GameObject tareButton;
    public GameObject changeUnitButton;
    public GameObject onOffButton;
    private float currentWeight = 0f;
    private bool isBalanceOn = true;
    private float tareWeight = 0f;
    private string currentUnit = "g";

    private void Start()
    {
        snapPosition = new Vector3(0.139799997f, 0.647000015f, -3.68799996f);
    }

    void OnTriggerEnter(Collider other)
    {
        placeDishInMachine(other);
    }

    private void OnTriggerStay(Collider other)
    {
        placeDishInMachine(other);
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Dish")
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }

    void placeDishInMachine(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Dish")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            other.gameObject.transform.position = snapPosition;
            other.gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }
    public void TareScale()
    {

        tareWeight = currentWeight;
        UpdateWeightDisplay();
    }

    public void ChangeUnit()
    {

        switch (currentUnit)
        {
            case "g":
                currentUnit = "kg";
                currentWeight /= 1000f;
                break;
            case "kg":
                currentUnit = "mg";
                currentWeight *= 1000f * 1000f;
                break;
            case "mg":
                currentUnit = "g";
                currentWeight /= 1000f;
                break;
        }
        UpdateWeightDisplay();
    }

    private void ToggleBalance()
    {

        isBalanceOn = !isBalanceOn;
        weightDisplay.text = isBalanceOn ? currentWeight.ToString("F2") + " " + currentUnit : "0";
    }

    public void UpdateWeightDisplay()
    {

        if (isBalanceOn)
        {
            weightDisplay.text = currentWeight.ToString("F2") + " " + currentUnit;
        }
    }

    public void OnOffButton(bool b)
    {
        if(!b)
        {
            weightDisplay.gameObject.SetActive(false);
        }
        else
        {
            weightDisplay.gameObject.SetActive(true);
        }
    }
}
