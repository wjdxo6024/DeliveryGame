using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiniMapIconScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform PlayerPosition = GameObject.Find("Car").GetComponent<Transform>();
        transform.position = new Vector3(PlayerPosition.position.x, PlayerPosition.position.y + 80f, PlayerPosition.position.z);

        transform.rotation = Quaternion.Euler(90f, PlayerPosition.eulerAngles.y, 0f);
    }
}
