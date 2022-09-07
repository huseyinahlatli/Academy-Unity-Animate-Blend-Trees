using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int IsWalkingHash = Animator.StringToHash("isWalking");
    private static readonly int IsRunningHash = Animator.StringToHash("isRunning");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var isWalking = _animator.GetBool(IsWalkingHash);
        var isRunning = _animator.GetBool(IsRunningHash);
        var forwardPressed = Input.GetKey(KeyCode.W);
        var runPressed = Input.GetKey(KeyCode.LeftShift);
        
        if (!isWalking && forwardPressed) // Walk True
        {
            _animator.SetBool(IsWalkingHash, true);
        }
        
        if(isWalking && !forwardPressed) // Walk False
        {
            _animator.SetBool(IsWalkingHash, false);
        }
        
        if (!isRunning && forwardPressed && runPressed) // Run True
        {
            _animator.SetBool(IsRunningHash, true);
        }
        
        if (isRunning && (!forwardPressed || !runPressed)) // Run False
        {
            _animator.SetBool(IsRunningHash,false);
        }
    }
}
