using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAppIconScript : MonoBehaviour
{
    public Button button;

    public void GoBankApp()
    {
        PlayerSmartPhoneScript PlayerSmartPhone = GameObject.Find("PlayerSmartPhone").GetComponent<PlayerSmartPhoneScript>();
        PlayerSmartPhone.SetState(SmartPhoneState.BANKAPP);

        Debug.Log("GoBank");
    }
}
