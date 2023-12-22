using UnityEngine;
using UnityEngine.InputSystem;

public class HeroAudioController : MonoBehaviour
{
	[SerializeField] private HeroAnimationController _animation;
	[SerializeField] private HeroPhysicsController _physics;
	[SerializeField] private AudioSource _stepAudio;
	[SerializeField] private AudioSource _hitAudio;

	private void Update()
	{
		if (_animation.IsRunning && _physics.IsGrounded)
		{
			if (!_stepAudio.isPlaying)
			{
				_stepAudio.Play();
			}
		}
		else
		{
			_stepAudio.Pause();
		}

		if (Keyboard.current.fKey.isPressed)
		{
			_hitAudio.Play();
		}
	}
}
