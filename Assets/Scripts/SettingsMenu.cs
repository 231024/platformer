using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{
	[SerializeField] private GameObject[] _buttons;

	public UnityAction DefaultButtonClicked;
	public UnityAction MuteButtonCLicked;
	public UnityAction NoSoundButtonClicked;

	public bool Visible { get; private set; }

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

		Visible = true;
	}

	public void Hide(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.transform.DOScale(Vector3.zero, immediately ? 0.0f : 0.2f);
		}

		Visible = false;
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