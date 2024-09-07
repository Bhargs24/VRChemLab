using UnityEngine;
using UnityEngine.UI;

public class WeighingBalance : MonoBehaviour
{
    private Vector3 snapPosition;
    public Text weightDisplay;
    public Button tareButton;
    public Button changeUnitButton;
    public Button onOffButton;
    private float currentWeight = 0f;
    private bool isBalanceOn = true;
    private float tareWeight = 0f;
    private string currentUnit = "g";

    private void Start()
    {
        snapPosition = new Vector3(0.139799997f, 0.647000015f, -3.68799996f);
        tareButton.onClick.AddListener(TareScale);
        changeUnitButton.onClick.AddListener(ChangeUnit);
        onOffButton.onClick.AddListener(ToggleBalance);
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Dish")
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            other.gameObject.transform.position = snapPosition;
        }
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

    // private void OnCollisionEnter(Collision other)
    // {

    //     if (other.gameObject.CompareTag("Dish"))
    //     {

    //         other.transform.position = snapPosition.position;


    //         Dish dish = other.gameObject.GetComponent<Dish>();
    //         if (dish != null)
    //         {
    //             currentWeight = dish.GetSaltWeight() - tareWeight;
    //             UpdateWeightDisplay();
    //         }
    //     }
    // }

    private void TareScale()
    {

        tareWeight = currentWeight;
        UpdateWeightDisplay();
    }

    private void ChangeUnit()
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

    private void UpdateWeightDisplay()
    {

        if (isBalanceOn)
        {
            weightDisplay.text = currentWeight.ToString("F2") + " " + currentUnit;
        }
    }
}
