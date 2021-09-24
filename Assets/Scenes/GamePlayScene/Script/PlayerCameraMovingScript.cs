using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovingScript : MonoBehaviour
{
    GameObject PlayerMotorBike;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMotorBike = GameObject.Find("PlayerMotorBike");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerMotorBike.transform.position.x,
            PlayerMotorBike.transform.position.y + 10,
            PlayerMotorBike.transform.position.z - 10);
    }
}
