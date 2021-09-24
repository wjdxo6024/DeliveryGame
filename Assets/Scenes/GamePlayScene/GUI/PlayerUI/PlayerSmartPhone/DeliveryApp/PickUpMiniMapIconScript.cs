using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMiniMapIconScript : MonoBehaviour
{
    public Transform MinimapCam;
    public float MinimapSize;
    Vector3 TempV3;

    void Update()
    {
        // 배달 상태를 가져오고 표시
        PlayerStateScript playerState = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();
        if (playerState.GetDeliveryState() == DeliveryState.PICKING)
        {
            Transform PickUpPosition = GameObject.Find("PickUpDestinationShow(Clone)").GetComponent<Transform>();
            transform.position = new Vector3(PickUpPosition.position.x, PickUpPosition.position.y + 80f, PickUpPosition.position.z);
        }

        //TempV3 = transform.parent.transform.position;
        //TempV3.y = transform.position.y;
        //transform.position = TempV3;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, MinimapCam.position.x - MinimapSize, MinimapSize + MinimapCam.position.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, MinimapCam.position.z - MinimapSize, MinimapSize + MinimapCam.position.z)
        );
    }
}
