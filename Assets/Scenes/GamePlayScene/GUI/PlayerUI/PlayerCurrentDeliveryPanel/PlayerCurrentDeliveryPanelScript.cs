using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrentDeliveryPanelScript : MonoBehaviour
{
    public Text Information;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInformation(Order order)
    {
        Information.text = "- 상품명 : "  + order.food.Name + "\n" +
                           "- 가격 : " + order.food.FoodPrice + "\n" +
                           "- 배달비 : " + order.Reward;
    }

    public void SetInformationIndex(int index)
    {
        OrderManager orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();
        Order selectOrder = orderManager.GetListIndexOf(index);
        SetInformation(selectOrder);
    }

    public void NothingInformation()
    {
        Information.text = "없음";
    }
}
