using UnityEngine;

public class AnimationStateBlendTree : MonoBehaviour
{
    private Animator _animator;
    private float _velocity;
    public float acceleration = .1f; // hizlanma
    public float deceleration = .1f; // yavaslama
    private static readonly int VelocityHash = Animator.StringToHash("Velocity");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var forwardPressed = Input.GetKey(KeyCode.W);
        var runPressed = Input.GetKey(KeyCode.LeftShift);

        if (forwardPressed && _velocity < 1f)
            _velocity += Time.deltaTime * acceleration;

        if (!forwardPressed && _velocity > 0f)
            _velocity -= Time.deltaTime * deceleration;

        if (!forwardPressed && _velocity < 0f)
            _velocity = 0f;
        
        _animator.SetFloat(VelocityHash, _velocity);        
    }
}
