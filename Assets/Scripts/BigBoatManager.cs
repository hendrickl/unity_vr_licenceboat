using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoatManager : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _timer;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _targetPosition = _targetPoint.transform.position;
    }

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", _targetPosition, "speed", _speed, "easetype", "linear"));

        if (!_audioSource)
        {
            throw new UnityException();
        }
        else
        {
            _audioSource.loop = false;
            _audioSource.volume = 1f;
            Invoke("TriggerAudio", _timer);
        }
    }

    private void TriggerAudio()
    {
        _audioSource.Play();
        Invoke("TriggerAudioAgain", _audioSource.clip.length);
    }

    private void TriggerAudioAgain()
    {
        _audioSource.Play();
    }
}
