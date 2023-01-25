using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceBad;
    [SerializeField] private AudioSource _audioSourceGood;

    public void RestarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
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
