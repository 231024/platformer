using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputHandler : MonoBehaviour
{
	[SerializeField] private HeroPhysicsController _physics;
	[SerializeField] private HeroAnimationController _animation;

	public float HAxisValue { get; private set; }
	public bool IsJumpPressed { get; private set; }
	public bool IsAttackPressed { get; private set; }

	private void Awake()
	{
		_physics.IsGroundedValueChanged += OnIsGroundedValueChanged;
		_animation.IsDamageObjectInstantiated += OnIsDamageObjectInstantiated;
	}

	private void OnDestroy()
	{
		_physics.IsGroundedValueChanged -= OnIsGroundedValueChanged;
		_animation.IsDamageObjectInstantiated -= OnIsDamageObjectInstantiated;
	}

	private void OnIsGroundedValueChanged()
	{
		IsJumpPressed = false;
	}

	private void OnIsDamageObjectInstantiated()
	{
		IsAttackPressed = false;
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		HAxisValue = context.ReadValue<Vector2>().x;
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed && _physics.IsGrounded)
		{
			IsJumpPressed = true;
		}
	}

	public void OnAttack(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			IsAttackPressed = true;
		}
	}
}
