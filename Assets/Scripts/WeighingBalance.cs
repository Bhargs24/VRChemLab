using UnityEngine;
using UnityEngine.UI;

public class WeighingBalance : MonoBehaviour
{
    public Transform snapPosition;  
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
        
        tareButton.onClick.AddListener(TareScale);
        changeUnitButton.onClick.AddListener(ChangeUnit);
        onOffButton.onClick.AddListener(ToggleBalance);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Dish"))
        {
           
            other.transform.position = snapPosition.position;

            
            Dish dish = other.gameObject.GetComponent<Dish>();
            if (dish != null)
            {
                currentWeight = dish.GetSaltWeight() - tareWeight;
                UpdateWeightDisplay();
            }
        }
    }

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
