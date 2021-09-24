using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioScript : MonoBehaviour
{
    public float audioPitch = 1;
    public float VelocityPitch;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = audioPitch;
    }

    // Update is called once per frame
    void Update()
    {
        CarControllerScript carController = GameObject.Find("Car").GetComponent<CarControllerScript>();
        audioSource.pitch = carController.GetVelocity() / VelocityPitch;
    }
}
