using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoatBehaviour : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private float _speed;


    private void Awake()
    {
        _targetPosition = _targetPoint.transform.position;
    }

    private void Start()
    {
        MoveBoat();
    }

    private void MoveBoat()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", _targetPosition, "speed", _speed, "easetype", "linear"));
    }
}
