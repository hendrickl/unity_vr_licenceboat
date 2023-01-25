using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timer;

    private void Start()
    {
        _audioSource.volume = 1;
        Invoke("TriggerAudio", _timer);
    }

    private void TriggerAudio()
    {
        _audioSource.Play();
    }
}
