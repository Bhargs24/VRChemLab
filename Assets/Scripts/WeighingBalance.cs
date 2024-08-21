using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class WeighingBalance : MonoBehaviour
{
    public Transform snapPosition; // Where the dish snaps to on the balance
    public Text weightDisplay; // Display for the weight
    public Button tareButton; // Button to tare the balance
    public Button changeUnitButton; // Button to change the unit
    public Button onOffButton; // Button to turn the balance on/off

    private float currentWeight = 0f;
    private float tareWeight = 0f;
    private XRGrabInteractable dishGrabInteractable;
    private string currentUnit = "g";
    private bool isOn = false;

    private void Start()
    {
        tareButton.onClick.AddListener(TareScale);
        changeUnitButton.onClick.AddListener(ChangeUnit);
        onOffButton.onClick.AddListener(ToggleOnOff);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dish") && isOn)
        {
            SnapDish(collision.gameObject);
            dishGrabInteractable = collision.gameObject.GetComponent<XRGrabInteractable>();
            if (dishGrabInteractable != null)
            {
                dishGrabInteractable.selectExited.AddListener(ReleaseDish);
            }
            Dish dish = collision.gameObject.GetComponent<Dish>();
            if (dish != null)
            {
                UpdateWeight(dish);
            }
        }
    }

    private void SnapDish(GameObject dish)
    {
        dish.transform.position = snapPosition.position;
        dish.transform.rotation = snapPosition.rotation;
        dish.transform.parent = snapPosition;
    }

    private void ReleaseDish(SelectExitEventArgs args)
    {
        if (dishGrabInteractable != null)
        {
            dishGrabInteractable.selectExited.RemoveListener(ReleaseDish);
        }
        args.interactorObject.transform.position = snapPosition.position;
        args.interactorObject.transform.rotation = snapPosition.rotation;
    }

    private void UpdateWeight(Dish dish)
    {
        if (isOn)
        {
            currentWeight = dish.GetTotalSaltWeight() - tareWeight;
            UpdateWeightDisplay();
        }
    }

    private void UpdateWeightDisplay()
    {
        float displayWeight = currentWeight;

        switch (currentUnit)
        {
            case "kg":
                displayWeight = currentWeight / 1000f;
                weightDisplay.text = displayWeight.ToString("F3") + " kg";
                break;
            case "mg":
                displayWeight = currentWeight * 1000f;
                weightDisplay.text = displayWeight.ToString("F0") + " mg";
                break;
            default:
                weightDisplay.text = currentWeight.ToString("F2") + " g";
                break;
        }
    }

    public void TareScale()
    {
        if (isOn)
        {
            tareWeight = currentWeight;
            UpdateWeightDisplay();
        }
    }

    public void ChangeUnit()
    {
        if (isOn)
        {
            switch (currentUnit)
            {
                case "g":
                    currentUnit = "kg";
                    break;
                case "kg":
                    currentUnit = "mg";
                    break;
                case "mg":
                    currentUnit = "g";
                    break;
            }
            UpdateWeightDisplay();
        }
    }

    public void ToggleOnOff()
    {
        isOn = !isOn;
        ResetDisplay();
    }

    private void ResetDisplay()
    {
        currentWeight = 0f;
        tareWeight = 0f;
        UpdateWeightDisplay();
    }
}
