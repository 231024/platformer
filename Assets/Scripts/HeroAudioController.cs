using UnityEngine;

public class HeroAudioController : MonoBehaviour
{
	[SerializeField] private HeroInputHandler _input;
	[SerializeField] private AudioSource _stepAudio;

	private void Update()
	{
		if (Mathf.Abs(_input.HAxisValue) > 0.0f && !_stepAudio.isPlaying)
		{
			_stepAudio.Play();
		}
		else if (_input.HAxisValue == 0.0f)
		{
			_stepAudio.Pause();
		}
	}
}
