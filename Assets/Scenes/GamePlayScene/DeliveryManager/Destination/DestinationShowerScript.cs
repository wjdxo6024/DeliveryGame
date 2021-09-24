using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestinationShower는 현재 픽업장소와 배달 장소에 대한 표시를 보여준다.

public class DestinationShowerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_PickUpDestinationDisplay; // 모델
    [SerializeField]
    private GameObject m_DeliveryDestinationDisplay; // 모델

    private Vector3 m_PickupDestination; // 픽업 목적지
    private Vector3 m_DeliveryDestination; // 배달 목적지

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeliveryManagerScript m_DeliveryManagerComponent = GameObject.Find("DeliveryManager").GetComponent<DeliveryManagerScript>();
        if (m_DeliveryManagerComponent.IsPicking())
        {
            ShowPickUpDestination(m_PickupDestination);
        }
        else if(m_DeliveryManagerComponent.IsDelivery())
        {
            ShowDeliveryDestination(m_DeliveryDestination);
        }
    }

    void ShowPickUpDestination(Vector3 destination)
    {
        m_PickUpDestinationDisplay.transform.position = destination;
        AnimateShowDestination();
    }

    void ShowDeliveryDestination(Vector3 destination)
    {
        m_DeliveryDestinationDisplay.transform.position = destination;
        AnimateShowDestination();
    }

    private void AnimateShowDestination()
    {
        m_PickUpDestinationDisplay.transform.rotation = new Quaternion(m_PickUpDestinationDisplay.transform.rotation.x,
            m_PickUpDestinationDisplay.transform.rotation.y + 0.3f,
            m_PickUpDestinationDisplay.transform.rotation.z,
            1.0f);

        m_DeliveryDestinationDisplay.transform.rotation = new Quaternion(m_DeliveryDestinationDisplay.transform.rotation.x,
            m_DeliveryDestinationDisplay.transform.rotation.y + 0.3f,
            m_DeliveryDestinationDisplay.transform.rotation.z,
            1.0f);
    }

    public void EnterDestination()
    {
        DeliveryManagerScript m_DeliveryManagerComponent = GameObject.Find("DeliveryManager").GetComponent<DeliveryManagerScript>();

        Debug.Log("EnterDestination!");

        if (m_DeliveryManagerComponent.IsPicking())
        {
            m_DeliveryManagerComponent.GetPickUpObject();
            Debug.Log("Shower Picking False");
        }
        else if(m_DeliveryManagerComponent.IsDelivery())
        {
            m_DeliveryManagerComponent.FinishDelivery();
            Debug.Log("Shower Delivering Success!");
        }
    }

    public void SetDestinations(Vector3 pickUp, Vector3 deliveryDestination)
    { 
        Debug.Log("Create Objects(Shower)");
        m_PickupDestination = pickUp;
        m_DeliveryDestination = deliveryDestination;

        Instantiate(m_PickUpDestinationDisplay, pickUp, Quaternion.identity); // 픽업 목적지 표시 생성
        Instantiate(m_DeliveryDestinationDisplay, deliveryDestination, Quaternion.identity); // 최종 목적지 표시 생성 
    }
}
