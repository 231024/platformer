using UnityEngine;
using UnityEngine.InputSystem;

public class HeroAudioController : MonoBehaviour
{
	[SerializeField] private HeroInputHandler _input;
	[SerializeField] private HeroPhysicsController _physics;

	[SerializeField] private AudioSource _stepAudio;
	[SerializeField] private AudioSource _hitAudio;

	private void Update()
	{
		if (Mathf.Abs(_input.HAxisValue) > 0.0f && _physics.IsGrounded && !_stepAudio.isPlaying)
		{
			_stepAudio.Play();
		}
		else if (_input.HAxisValue == 0.0f)
		{
			_stepAudio.Pause();
		}

		if (Keyboard.current.fKey.isPressed)
		{
			_hitAudio.Play();
		}
	}
}
