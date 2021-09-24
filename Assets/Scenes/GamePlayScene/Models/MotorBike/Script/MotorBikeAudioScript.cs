using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorBikeAudioScript : MonoBehaviour
{
    public float audioPitch = 1;
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
        
    }
}
