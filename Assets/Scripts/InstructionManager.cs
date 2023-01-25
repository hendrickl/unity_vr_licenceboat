using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionVocal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timer;

    private void Start()
    {
        Invoke("TriggerAudio", _timer);
    }

    private void TriggerAudio()
    {
        _audioSource.Play();
    }
}
