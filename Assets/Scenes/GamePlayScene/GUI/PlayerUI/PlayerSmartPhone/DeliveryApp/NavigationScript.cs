using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationScript : MonoBehaviour
{
    public GameObject PickUpIcon;
    public GameObject DeliveryIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpIconShow()
    {
        PickUpIcon.SetActive(true);
        DeliveryIcon.SetActive(false);
    }

    public void DeliveryIconShow()
    {
        PickUpIcon.SetActive(false);
        DeliveryIcon.SetActive(true);
    }

    public void DoNotShowIcon()
    {
        PickUpIcon.SetActive(false);
        DeliveryIcon.SetActive(false);
    }
}
