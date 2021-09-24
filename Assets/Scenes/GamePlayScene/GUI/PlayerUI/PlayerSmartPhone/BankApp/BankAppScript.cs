using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAppScript : MonoBehaviour
{
    // BankInformation
    WalletManagerScript WalletManager;
    int DayForExpenditure;
    int CurrentMoney;
    // Start is called before the first frame update
    void Start()
    {
        WalletManager = GameObject.Find("WalletManager").GetComponent<WalletManagerScript>();
        DayForExpenditure = WalletManager.GetDayForExpenditure();
        CurrentMoney = WalletManager.GetCurrentMoney();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� �� ���� �ڱ� ����
        DayForExpenditure = WalletManager.GetDayForExpenditure();
        CurrentMoney = WalletManager.GetCurrentMoney();

        UpdateText();
    }

    void UpdateText()
    {
        Text MyMoneyText = GameObject.Find("MyMoneyText").transform.GetChild(0).GetComponent<Text>();
        Text MyExpenditureText = GameObject.Find("MyExpenditure").transform.GetChild(0).GetComponent<Text>();
        MyMoneyText.text = CurrentMoney + " ��";
        MyExpenditureText.text = DayForExpenditure + " ��";
    }

    void ShowApp()
    {

    }
}
