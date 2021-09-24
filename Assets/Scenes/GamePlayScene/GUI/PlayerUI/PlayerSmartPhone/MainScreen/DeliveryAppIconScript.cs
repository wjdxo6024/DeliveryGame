using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryAppIconScript : MonoBehaviour
{
    public Button button;

    public void GoDeliveryApp()
    {
        PlayerSmartPhoneScript PlayerSmartPhone = GameObject.Find("PlayerSmartPhone").GetComponent<PlayerSmartPhoneScript>();
        PlayerSmartPhone.SetState(SmartPhoneState.DELIVERYAPP);
        Debug.Log("GoDelivery");
    }
}
