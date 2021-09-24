using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManagerScript : MonoBehaviour
{
    public int InitialMoney;

    private int CurrentMoney;
    public int DayForExpenditure;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InitializeMoney();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeMoney()
    {
        CurrentMoney = InitialMoney;
    }

    public void ClosingForEndDay()
    {
        CurrentMoney -= DayForExpenditure;
    }

    public void AddExpenditure(int exp)
    {
        DayForExpenditure += exp;
    }

    public void RemoveExpenditure(int exp)
    {
        DayForExpenditure -= exp;
    }

    public void RemoveCurrentMoney(int money)
    {
        CurrentMoney -= money;
    }

    public void AddCurrentMoney(int money)
    {
        CurrentMoney += money;
    }

    public bool IsMoneyEmpty()
    {
        if (CurrentMoney < 0)
            return true;
        else
            return false;
    }

    public int GetCurrentMoney()
    {
        return CurrentMoney;
    }

    public int GetDayForExpenditure()
    {
        return DayForExpenditure;
    }
}