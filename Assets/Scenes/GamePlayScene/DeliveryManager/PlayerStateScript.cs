using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateScript : MonoBehaviour
{
    private DeliveryState m_deliveryState;
    // Start is called before the first frame update
    void Start()
    {
        m_deliveryState = DeliveryState.NOTHING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DeliveryState GetDeliveryState()
    {
        return m_deliveryState;
    }

    public void SetDeliveryState(DeliveryState state)
    {
        m_deliveryState = state;
        // App�� ���� ��ȯ
        Debug.Log("m_deliveryState : " + m_deliveryState);
        /*deliveryApp.Show();*/ // ������ : ������ Navigation�� ��Ȱ��ȭ �Ǿ ���� �߻�
        //------------------------------------------------------------
        // ���¿� ���� ���� ����
        //------------------------------------------------------------

        if (state == DeliveryState.PICKING)
        {
            DeliveryAppScript deliveryApp = GameObject.Find("DeliveryApp").GetComponent<DeliveryAppScript>();
            deliveryApp.Show(m_deliveryState);
            NavigationScript navigation = GameObject.Find("Navigation").GetComponent<NavigationScript>();
            navigation.PickUpIconShow();
        }
        else if(state == DeliveryState.DELIVERING)
        {
            DeliveryAppScript deliveryApp = GameObject.Find("DeliveryApp").GetComponent<DeliveryAppScript>();
            deliveryApp.Show(m_deliveryState);
            NavigationScript navigation = GameObject.Find("Navigation").GetComponent<NavigationScript>();
            navigation.DeliveryIconShow();
        }
        else if(state == DeliveryState.NOTHING) // ���� NOTHING���� ��ȯ �� ����Ʈ �ʱ�ȭ
        {
            OrderManager orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();
            orderManager.MakeList();
            NavigationScript navigation = GameObject.Find("Navigation").GetComponent<NavigationScript>();
            navigation.DoNotShowIcon();
            DeliveryAppScript deliveryApp = GameObject.Find("DeliveryApp").GetComponent<DeliveryAppScript>();
            deliveryApp.Show(m_deliveryState);
            DeliveryScrollViewScript deliveryScrollView = GameObject.Find("Scroll View").GetComponent<DeliveryScrollViewScript>();
            deliveryScrollView.InitScrollView();
        }
    }
}

public enum DeliveryState { NOTHING = 0, PICKING, DELIVERING };
