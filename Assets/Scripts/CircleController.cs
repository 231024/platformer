using UnityEngine;

public class CircleController : MonoBehaviour
{
	private const string HorizontalAxisName = "Horizontal";
	private const string LeftAnimationName = "MoveLeft";
	private const string RightAnimationName = "MoveRight";
	private const string IdleAnimationName = "Idle";

	[SerializeField] private float _jumpHeight;
	[SerializeField] private float _defaultForceMultiplier;
	[SerializeField] private float _maxForceMultiplier;

	private Animation _animation;
	private float _forceMultiplier;
	private float _hAxisValue;
	private Rigidbody2D _circleBody;

	private void Start()
	{
		_circleBody = GetComponent<Rigidbody2D>();
		_animation = GetComponent<Animation>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_circleBody.AddForce(new Vector2(0.0f, _jumpHeight));
		}

		_hAxisValue = Input.GetAxis(HorizontalAxisName);

		if (Input.GetKeyDown(KeyCode.A))
		{
			_animation.Play(LeftAnimationName);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			_animation.Play(RightAnimationName);
		}

		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		_circleBody.AddForce(new Vector2(-_hAxisValue * _forceMultiplier, 0.0f), ForceMode2D.Impulse);
		_forceMultiplier = _defaultForceMultiplier;
		_animation.Play(IdleAnimationName);
	}

	public void IncreaseMultiplier()
	{
		_forceMultiplier = _maxForceMultiplier;
	}
}
