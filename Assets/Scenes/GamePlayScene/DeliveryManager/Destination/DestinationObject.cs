using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestinationObjectCode { PickUp, Delivery};

public class DestinationObject : MonoBehaviour
{
    public DestinationObjectCode code;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering");
        if(other.gameObject.name == "PlayerMotorBike" || other.gameObject.name == "Car")
        {
            if(code == DestinationObjectCode.PickUp)
            {
                if(GameObject.Find("PlayerState").GetComponent<PlayerStateScript>().GetDeliveryState() == DeliveryState.PICKING)
                {
                    DestinationShowerScript gmComponent = GameObject.Find("DestinationShower").GetComponent<DestinationShowerScript>();
                    gmComponent.EnterDestination();
                    Destroy(gameObject);
                }
            }
            else if(code == DestinationObjectCode.Delivery)
            {
                if (GameObject.Find("PlayerState").GetComponent<PlayerStateScript>().GetDeliveryState() == DeliveryState.DELIVERING)
                {
                    DestinationShowerScript gmComponent = GameObject.Find("DestinationShower").GetComponent<DestinationShowerScript>();
                    gmComponent.EnterDestination();
                    Destroy(gameObject);
                }
            }
               
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
