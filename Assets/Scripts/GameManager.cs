using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _instruction;
    [SerializeField] private AudioSource _audioSourceInstruction;
    [SerializeField] private AudioSource _audioSourceBad;
    [SerializeField] private AudioSource _audioSourceGood;
    [SerializeField] private float _timerAudio;
    [SerializeField] private float _timerInstruction;

    private void Start()
    {
        Invoke("TriggerAudioInstruction", _timerAudio);
        Invoke("DisplayInstruction", _timerInstruction);
    }

    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void TriggerAudioInstruction()
    {
        _audioSourceInstruction.Play();
    }

    private void DisplayInstruction()
    {
        _instruction.SetActive(true);
    }

    public void BadAnswer()
    {
        _audioSourceBad.volume = 1;
        _audioSourceBad.Play();
    }

    public void GoodAnswer()
    {
        _audioSourceGood.volume = 1;
        _audioSourceGood.Play();
    }
}
