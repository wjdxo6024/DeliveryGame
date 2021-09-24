using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public void GoHome()
    {
        PlayerSmartPhoneScript PlayerSmartPhone = GameObject.Find("PlayerSmartPhone").GetComponent<PlayerSmartPhoneScript>();
        PlayerSmartPhone.SetState(SmartPhoneState.MAINSCREEN);

        Debug.Log("GoHome");
    }
}
