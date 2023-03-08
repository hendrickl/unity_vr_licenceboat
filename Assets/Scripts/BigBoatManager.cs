using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoatManager : MonoBehaviour
{
    [SerializeField] private float _timerAudioKlaxoon;
    [SerializeField] private float _timerAudioKlaxoonRepeat;
    [SerializeField] private AudioSource _audioSource;

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

    private IEnumerator TriggerAudioKlaxoonCoroutine()
    {
        yield return new WaitForSeconds(_timerAudioKlaxoon);
        _audioSource.Play();

        yield return new WaitForSeconds(_timerAudioKlaxoonRepeat);
        _audioSource.Play();
    }
}
