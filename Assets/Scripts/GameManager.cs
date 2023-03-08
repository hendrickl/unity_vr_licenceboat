using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _instruction;
    [SerializeField] private AudioSource _audioSourceInstruction;
    [SerializeField] private AudioSource _audioSourceBadAnswer;
    [SerializeField] private AudioSource _audioSourceGoodAnswer;
    [SerializeField] private AudioClip _audioOnClick;
    [SerializeField] private AudioClip _audioOnExit;
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

    // * * * Logic to load the scene right after the click sound * * *
    public void LoadSceneOnClick(int index)
    {
        TriggerAudioOnClick();
        StartCoroutine(LoadSceneAfterAudioOnClickCoroutine(index, 0.35f));
    }

    private IEnumerator LoadSceneAfterAudioOnClickCoroutine(int index, float time)
    {
        yield return new WaitForSeconds(time);
        LoadScene(index);
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    // * * * Scene Management * * * 
    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitApplication()
    {
        TriggerAudioOnExit();
        Application.Quit();
    }

    // * * * Audio logic * * * 
    // Todo : refactoring
    private void TriggerAudioOnClick()
    {
        _audioSourceInstruction.clip = _audioOnClick;
        _audioSourceInstruction.volume = 1f;
        _audioSourceInstruction.Play();
    }

    private void TriggerAudioOnExit()
    {
        _audioSourceInstruction.clip = _audioOnExit;
        _audioSourceInstruction.volume = 1f;
        _audioSourceInstruction.Play();
    }

    public void TriggerAudioBadAnswer()
    {
        _audioSourceBadAnswer.volume = 1f;
        _audioSourceBadAnswer.Play();
    }

    public void TriggerAudioGoodAnswer()
    {
        _audioSourceGoodAnswer.volume = 1f;
        _audioSourceGoodAnswer.Play();
    }
}
