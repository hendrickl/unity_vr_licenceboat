using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _instruction;
    [SerializeField] private float _timerAudio;
    [SerializeField] private float _timerInstruction;

    private void Start()
    {
        Invoke("TriggerAudio", _timerAudio);
        Invoke("DisplayInstruction", _timerInstruction);
    }

    private void TriggerAudio()
    {
        _audioSource.Play();
    }

    private void DisplayInstruction()
    {
        _instruction.SetActive(true);
    }
}
