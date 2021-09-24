using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
                   DeliveryManager
                 /                I
        DestinationShower    DestinationObject
     
     
     
     */

public class DeliveryManagerScript : MonoBehaviour
{
    // 현재 수행 배달 정보
    public Order CurrentOrder;
    // 현재 배달 수행을 위한 목표지.
    public Vector3 m_pickUpPos;
    public Vector3 m_DeliveryDestination;

    // Start is called before the first frame update
    void Start()
    {
        DeliveryManagerScript gmComponent = GameObject.Find("DeliveryManager").GetComponent<DeliveryManagerScript>();
        // 테스트
        //Vector3 TestPickUp = new Vector3(0.0f, 0.0f, 100.0f);
        //Vector3 TestDelivery = new Vector3(0.0f, 0.0f, 200.0f);

        //gmComponent.StartDelivery(TestPickUp, TestDelivery);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 매개변수를 넘겨 줄 것.
    public void SetDeliveryInformation(Order selectOrder)
    {
        CurrentOrder = selectOrder;
        StartDelivery(CurrentOrder.getSrc(), CurrentOrder.getDst());
    }

    public void SetDeliveryToIndex(int index)
    {
        // 리스트로부터 하나 가져온다.
        OrderManager orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();
        SetDeliveryInformation(orderManager.SelectOrder(index));
    }

    public void StartDelivery(Vector3 pickUp, Vector3 delivery)
    {
        DestinationShowerScript destinationShowerComponent = GameObject.Find("DestinationShower").GetComponent<DestinationShowerScript>();
        PlayerStateScript stateComponent = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();

        stateComponent.SetDeliveryState(DeliveryState.PICKING);

        m_pickUpPos = pickUp;
        m_DeliveryDestination = delivery;

        destinationShowerComponent.SetDestinations(pickUp, delivery);
    }

    public void GetPickUpObject()
    {
        PlayerStateScript stateComponent = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();
        stateComponent.SetDeliveryState(DeliveryState.DELIVERING);
    }

    public void FinishDelivery()
    {
        // 정산
        WalletManagerScript walletManager = GameObject.Find("WalletManager").GetComponent<WalletManagerScript>();
        walletManager.AddCurrentMoney(CurrentOrder.Reward);

        CurrentOrder = null;

        PlayerStateScript stateComponent = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();
        stateComponent.SetDeliveryState(DeliveryState.NOTHING);

        PlayerCurrentDeliveryPanelScript playerCurrentDeliveryPanel = GameObject.Find("PlayerCurrentDeliveryPanel").GetComponent<PlayerCurrentDeliveryPanelScript>();
        playerCurrentDeliveryPanel.NothingInformation();
    }

    public bool IsDelivery()
    {
        PlayerStateScript m_StateComponent = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();

        if (m_StateComponent.GetDeliveryState() == DeliveryState.DELIVERING)
        {
            return true;
        }
        else
            return false;
    }

    public bool IsPicking()
    {
        PlayerStateScript m_StateComponent = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();

        if (m_StateComponent.GetDeliveryState() == DeliveryState.PICKING)
        {
            return true;
        }
        else
            return false;
    }

}
