using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoatManager : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _timerAudioKlaxoon;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _targetPosition = _targetPoint.transform.position;
    }

    void Start()
    {
        MoveBoat();

        if (!_audioSource)
        {
            throw new UnityException("The audiosource is not initialized");
        }
        else
        {
            _audioSource.loop = false;
            _audioSource.volume = 1f;
            Invoke("TriggerAudioKlaxoon", _timerAudioKlaxoon);
        }
    }

    private void MoveBoat()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", _targetPosition, "speed", _speed, "easetype", "linear"));

    }

    private void TriggerAudioKlaxoon()
    {
        _audioSource.Play();
        Invoke("TriggerAudioKlaxoonAgain", _audioSource.clip.length);
    }

    private void TriggerAudioKlaxoonAgain()
    {
        _audioSource.Play();
    }
}
