using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class HeroAnimationController : MonoBehaviour
{
	private static readonly int IsRun = Animator.StringToHash("IsRun");
	private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
	private static readonly int Jump = Animator.StringToHash("Jump");
	private static readonly int Hit = Animator.StringToHash("Attack1");
	private static readonly int AirSpeed = Animator.StringToHash("AirSpeed");

	[SerializeField] private Animator _animator;
	[SerializeField] private HeroInputHandler _input;
	[SerializeField] private HeroPhysicsController _physics;
	[SerializeField] private SpriteRenderer _renderer;
	[SerializeField] private ParticleSystem _particles;
	[SerializeField] private Transform _capsule;
	[SerializeField] private Damage _damage;

	public UnityAction IsDamageObjectInstantiated;

	public bool IsRunning => _animator.GetBool(IsRun);

	private void Awake()
	{
		_physics.IsGroundedValueChanged += OnIsGroundedValueChanged;
	}

	private void Update()
	{
		_animator.SetFloat(AirSpeed, _physics.AirSpeed);
		_animator.SetBool(IsRun, Mathf.Abs(_input.HAxisValue) > float.Epsilon);

		if (_input.HAxisValue > 0.0f)
		{
			_renderer.flipX = false;
			_capsule.DOScaleX(1.0f, 0.0f);
		}
		else if (_input.HAxisValue < 0.0f)
		{
			_renderer.flipX = true;
			_capsule.DOScaleX(-1.0f, 0.0f);
		}

		if (_input.IsJumpPressed)
		{
			_animator.SetTrigger(Jump);
		}

		if (_input.IsAttackPressed)
		{
			_animator.SetTrigger(Hit);
			Instantiate(_damage, _capsule);
			IsDamageObjectInstantiated.Invoke();
		}
	}

	private void OnDestroy()
	{
		_physics.IsGroundedValueChanged -= OnIsGroundedValueChanged;
	}

	private void OnIsGroundedValueChanged()
	{
		if (_physics.IsGrounded)
		{
			_particles.Play();
		}

		_animator.SetBool(IsGrounded, _physics.IsGrounded);
	}
}
