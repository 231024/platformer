using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
	private static readonly int IsRun = Animator.StringToHash("IsRun");
	private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
	private static readonly int Jump = Animator.StringToHash("Jump");

	[SerializeField] private Animator _animator;
	[SerializeField] private HeroInputController _input;
	[SerializeField] private HeroPhysicsController _physics;
	[SerializeField] private SpriteRenderer _renderer;
	private static readonly int AirSpeed = Animator.StringToHash("AirSpeed");

	private void Awake()
	{
		_physics.OnIsGroundedValueChanged += () => { _animator.SetBool(IsGrounded, _physics.IsGrounded); };
	}

	private void Update()
	{
		_animator.SetFloat(AirSpeed, _physics.AirSpeed);
		_animator.SetBool(IsRun, Mathf.Abs(_input.HAxisValue) > float.Epsilon);
		_renderer.flipX = _input.HAxisValue < 0.0f;

		if (_input.IsJumpPressed)
		{
			_animator.SetTrigger(Jump);
		}
	}
}