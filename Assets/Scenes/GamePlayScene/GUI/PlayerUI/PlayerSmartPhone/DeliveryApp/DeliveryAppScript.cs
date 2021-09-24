using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryAppScript : MonoBehaviour
{
    PlayerStateScript PlayerState;
    DeliveryManagerScript DeliveryManager;
    OrderManager Order;
    GameObject Navigation;
    GameObject DeliveryList;

    // Start is called before the first frame update
    void Start()
    {
        Navigation = GameObject.Find("Navigation");
        DeliveryList = GameObject.Find("DeliveryList");
        DeliveryManager = GameObject.Find("DeliveryManager").GetComponent<DeliveryManagerScript>();
        PlayerState = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();

        // 초기화
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        PlayerState = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();
        if (PlayerState.GetDeliveryState() == DeliveryState.NOTHING) // 스크롤 뷰 보여주기
        {
            DeliveryList.SetActive(true);
            Navigation.SetActive(false);
        }
        else
        {
            DeliveryList.SetActive(false);
            Navigation.SetActive(true);
        }
    }

    public void Show(DeliveryState state)
    {
        PlayerState = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();
        if (state == DeliveryState.NOTHING) // 스크롤 뷰 보여주기
        {
            DeliveryList.SetActive(true);
            Navigation.SetActive(false);
        }
        else
        {
            DeliveryList.SetActive(false);
            Navigation.SetActive(true);
        }
    }
}
