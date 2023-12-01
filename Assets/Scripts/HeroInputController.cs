using UnityEngine;

public class HeroInputController : MonoBehaviour
{
	private const string HorizontalAxisName = "Horizontal";

	[SerializeField] private HeroPhysicsController _physics;

	public float HAxisValue { get; private set; }
	public bool IsJumpPressed { get; private set; }

	private void Awake()
	{
		_physics.OnIsGroundedValueChanged += () => { IsJumpPressed = false; };
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _physics.IsGrounded)
		{
			IsJumpPressed = true;
		}

		HAxisValue = Input.GetAxis(HorizontalAxisName);
	}
}
