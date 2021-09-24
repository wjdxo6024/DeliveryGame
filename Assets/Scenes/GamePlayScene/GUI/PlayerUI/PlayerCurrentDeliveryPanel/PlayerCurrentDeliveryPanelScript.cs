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
        Information.text = "- ��ǰ�� : "  + order.food.Name + "\n" +
                           "- ���� : " + order.food.FoodPrice + "\n" +
                           "- ��޺� : " + order.Reward;
    }

    public void SetInformationIndex(int index)
    {
        OrderManager orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();
        Order selectOrder = orderManager.GetListIndexOf(index);
        SetInformation(selectOrder);
    }

    public void NothingInformation()
    {
        Information.text = "����";
    }
}
