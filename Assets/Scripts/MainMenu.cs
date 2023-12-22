using DG.Tweening;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private RectTransform _menuButton;
	[SerializeField] private RectTransform[] _buttons;
	[SerializeField] private SettingsMenu _settings;
	[SerializeField] private float _animationTime;

	private void Start()
	{
		Hide();
	}

	private void Show(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.DOScale(Vector3.one, immediately ? 0.0f : _animationTime);
		}

		_menuButton.DOScale(Vector3.zero, immediately ? 0.0f : _animationTime);
	}

	private void Hide(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.DOScale(Vector3.zero, immediately ? 0.0f : _animationTime);
		}

		_menuButton.DOScale(Vector3.one, immediately ? 0.0f : _animationTime);
	}

	public void OnContinueGameClick()
	{
		Hide();
	}

	public void OnSettingsButtonClick()
	{
		if (_settings.Visible)
		{
			transform.DOMove(new Vector3(transform.position.x + Screen.width/2, transform.position.y, transform.position.z),
			_animationTime);
			_settings.Hide();
		}
		else
		{
			transform.DOMove(new Vector3(transform.position.x - Screen.width/2, transform.position.y, transform.position.z),
			_animationTime);
		_settings.Show();
		}
	}

	public void OnMenuButtonClick()
	{
		Show();
	}
}
