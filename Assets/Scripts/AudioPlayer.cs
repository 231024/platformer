using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	[SerializeField] private AudioClip[] _tracks;
	[SerializeField] private AudioSource _source;

	private void Awake()
	{
		PlayNextTrack();
	}

	private void PlayNextTrack()
	{
		_source.clip = _tracks[Random.Range(0, _tracks.Length)];
		_source.Play();
		Invoke(nameof(PlayNextTrack), _source.clip.length);
	}
}
