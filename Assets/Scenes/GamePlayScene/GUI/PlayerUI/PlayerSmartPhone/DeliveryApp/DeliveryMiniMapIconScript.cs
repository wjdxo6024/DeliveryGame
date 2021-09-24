using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMiniMapIconScript : MonoBehaviour
{
    public Transform MinimapCam;
    public float MinimapSize;
    Vector3 TempV3;

    void Update()
    {
        // 배달 상태를 가져오고 표시
        PlayerStateScript playerState = GameObject.Find("PlayerState").GetComponent<PlayerStateScript>();
        if (playerState.GetDeliveryState() == DeliveryState.DELIVERING)
        {
            Transform DeliveryDestinationPosition = GameObject.Find("DeliveryDestinationShow(Clone)").GetComponent<Transform>();
            transform.position = new Vector3(DeliveryDestinationPosition.position.x, DeliveryDestinationPosition.position.y + 80f, DeliveryDestinationPosition.position.z);
        }
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
