using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ȩ��ư�̳� �ڷ� ��ư�� ������ ���� ȭ������ ������ �ϱ�.

public class WindowScript : MonoBehaviour
{
    GameObject BankApp;
    GameObject DeliveryApp;
    GameObject MainScreen;

    private void Awake()
    {
        BankApp = GameObject.Find("BankApp");
        DeliveryApp = GameObject.Find("DeliveryApp");
        MainScreen = GameObject.Find("MainScreen");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        
    }

    //
    public void Show()
    {
        PlayerSmartPhoneScript smComponent = GameObject.Find("PlayerSmartPhone").GetComponent<PlayerSmartPhoneScript>();
        switch (smComponent.GetState())
        {
            case SmartPhoneState.MAINSCREEN:
            {
                    MainScreen.SetActive(true);
                    BankApp.SetActive(false);
                    DeliveryApp.SetActive(false);
                    break;
            }
            case SmartPhoneState.BANKAPP:
            {
                    MainScreen.SetActive(false);
                    BankApp.SetActive(true);
                    DeliveryApp.SetActive(false);
                    break;
            }
            case SmartPhoneState.DELIVERYAPP:
            {
                    MainScreen.SetActive(false);
                    BankApp.SetActive(false);
                    DeliveryApp.SetActive(true);
                    break;
            }
        }
    }
}
