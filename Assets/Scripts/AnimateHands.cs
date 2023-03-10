using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    [SerializeField] private InputActionProperty _pinchAction;
    [SerializeField] private InputActionReference _gripAction;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        float triggerVal = _pinchAction.action.ReadValue<float>();
        _animator.SetFloat("Trigger", triggerVal);

        float gripVal = _gripAction.action.ReadValue<float>();
        _animator.SetFloat("Grip", gripVal);
    }
}