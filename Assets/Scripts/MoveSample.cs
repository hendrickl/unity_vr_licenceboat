using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private float _speed = 1;

    private void Awake()
    {
        _targetPosition = _targetPoint.transform.position;
    }

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", _targetPosition, "speed", _speed, "easetype", "linear"));
    }
}

