using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputHandler : MonoBehaviour
{
	[SerializeField] private HeroPhysicsController _physics;

	public float HAxisValue { get; private set; }
	public bool IsJumpPressed { get; private set; }

	private void Awake()
	{
		_physics.IsGroundedValueChanged += OnIsGroundedValueChanged;
	}

	private void OnDestroy()
	{
		_physics.IsGroundedValueChanged -= OnIsGroundedValueChanged;
	}

	private void OnIsGroundedValueChanged()
	{
		IsJumpPressed = false;
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
}
