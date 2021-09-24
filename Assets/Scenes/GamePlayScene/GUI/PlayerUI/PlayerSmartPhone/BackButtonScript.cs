using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
    public void GoBack()
    {
        PlayerSmartPhoneScript PlayerSmartPhone = GameObject.Find("PlayerSmartPhone").GetComponent<PlayerSmartPhoneScript>();
        PlayerSmartPhone.SetState(SmartPhoneState.MAINSCREEN);
    }
}
