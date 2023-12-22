using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{
	[SerializeField] private GameObject[] _buttons;

	private bool _visible;

	public bool Visible => _visible;

	public UnityAction DefaultButtonClicked;
	public UnityAction MuteButtonCLicked;
	public UnityAction NoSoundButtonClicked;

	private void Start()
	{
		Hide(true);
	}

	public void Show(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.transform.DOScale(Vector3.one, immediately ? 0.0f : 0.2f);
		}

		_visible = true;
	}

	public void Hide(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.transform.DOScale(Vector3.zero, immediately ? 0.0f : 0.2f);
		}

		_visible = false;
	}

	public void OnMuteClick()
	{
		MuteButtonCLicked.Invoke();
	}

	public void OnNoSoundClick()
	{
		NoSoundButtonClicked.Invoke();
	}

	public void OnDefaultClick()
	{
		DefaultButtonClicked.Invoke();
	}
}
