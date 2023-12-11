using System;
using UnityEngine;
using UnityEngine.Events;

public class HeroPhysicsController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _circleBody;
	[SerializeField] private HeroInputHandler _input;
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpHeight;

	private bool _isGrounded;

	public UnityAction IsGroundedValueChanged;

	public float AirSpeed => _circleBody.velocity.y;

	public bool IsGrounded
	{
		get => _isGrounded;
		private set
		{
			if (_isGrounded == value)
			{
				return;
			}

			_isGrounded = value;
			IsGroundedValueChanged.Invoke();
		}
	}

	private void FixedUpdate()
	{
		_circleBody.velocity = new Vector2(_input.HAxisValue * _speed, _circleBody.velocity.y);

		if (_input.IsJumpPressed && IsGrounded)
		{
			_circleBody.velocity = new Vector2(_circleBody.velocity.x, _jumpHeight);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		IsGrounded = true;
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		IsGrounded = false;
	}
}
