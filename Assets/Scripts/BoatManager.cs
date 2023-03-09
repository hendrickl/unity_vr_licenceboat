using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private CharacterController _cc;

    private void Update()
    {
        if (_cc.velocity.magnitude > 0.1f)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
