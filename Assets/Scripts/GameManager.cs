using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _instruction;

    // * * * Variables related to audio * * *
    [SerializeField] private AudioSource _audioSourceInstruction;
    [SerializeField] private AudioClip _audioOnClick;
    [SerializeField] private AudioClip _audioOnExit;
    [SerializeField] private AudioClip _audioBadAnswer;
    [SerializeField] private AudioClip _audioGoodAnswer;

    // * * * Variables related to time
    [SerializeField] private float _timer = 10f;
    [SerializeField] private float _timerAudioInstruction;
    [SerializeField] private float _timerPannelInstruction;

    private void Start()
    {
        StartCoroutine("TriggerAudioInstructionCoroutine");
        StartCoroutine("DisplayInstructionCoroutine");
    }

    private void Update()
    {
        Timer();
    }

    // * * * Logic for instructions management
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
        TriggerAudio(_audioOnClick);
        StartCoroutine(LoadSceneAfterAudioOnClickCoroutine(index, 0.35f));
    }

    private IEnumerator LoadSceneAfterAudioOnClickCoroutine(int index, float time)
    {
        yield return new WaitForSeconds(time);
        LoadScene(index);
    }

    // * * * Level Management * * * 
    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitApplication()
    {
        TriggerAudio(_audioOnExit);
        Application.Quit();
    }

    // * * * Audio logic * * * 
    public void TriggerAudio(AudioClip audioClip)
    {
        _audioSourceInstruction.clip = audioClip;
        _audioSourceInstruction.volume = 1f;
        _audioSourceInstruction.Play();
    }

    // * * * Timer * * *
    private void Timer()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            print("time is over");
        }
    }
}
