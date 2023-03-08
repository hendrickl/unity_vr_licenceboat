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
    [SerializeField] private float _timerAudioInstruction;
    [SerializeField] private float _timerPannelInstruction;

    private void Start()
    {
        StartCoroutine("TriggerAudioInstructionCoroutine");
        StartCoroutine("DisplayInstructionCoroutine");
    }

    private IEnumerator DisplayInstructionCoroutine()
    {
        yield return new WaitForSeconds(_timerPannelInstruction);
        _instruction.SetActive(true);
    }

    private IEnumerator TriggerAudioInstructionCoroutine()
    {
        yield return new WaitForSeconds(_timerAudioInstruction);
        _audioSourceInstruction.Play();
    }

    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void TriggerAudioBadAnswer()
    {
        _audioSourceBad.volume = 1;
        _audioSourceBad.Play();
    }

    public void TriggerAudioGoodAnswer()
    {
        _audioSourceGood.volume = 1;
        _audioSourceGood.Play();
    }
}
