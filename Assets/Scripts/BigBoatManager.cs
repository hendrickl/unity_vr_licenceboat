using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoatManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    // * * * Variables related to time * * *
    [SerializeField] private float _timerAudioKlaxoon;
    [SerializeField] private float _timerAudioKlaxoonRepeat;

    private void Start()
    {
        if (!_audioSource)
        {
            throw new UnityException("The audiosource is not initialized");
        }
        else
        {
            _audioSource.loop = false;
            _audioSource.volume = 1f;
            StartCoroutine("TriggerAudioKlaxoonCoroutine");
        }
    }

    // * * * Logic to trigger the klaxoon 2 times * * *    
    private IEnumerator TriggerAudioKlaxoonCoroutine()
    {
        yield return new WaitForSeconds(_timerAudioKlaxoon);
        _audioSource.Play();

        yield return new WaitForSeconds(_timerAudioKlaxoonRepeat);
        _audioSource.Play();
    }
}
