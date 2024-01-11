using DG.Tweening;
using UnityEngine;

public class MainMenu : BaseMenu
{
	[SerializeField] private RectTransform _menuButton;
	[SerializeField] private SettingsMenu _settings;
	[SerializeField] private Game _game;
	[SerializeField] private float _animationTime;

	public override void Show(bool immediately = false)
	{
		base.Show(immediately);
		_menuButton.DOScale(Vector3.zero, immediately ? 0.0f : _animationTime);
	}

	public override void Hide(bool immediately = false)
	{
		base.Hide(immediately);
		_menuButton.DOScale(Vector3.one, immediately ? 0.0f : _animationTime);
	}

	public void OnContinueGameClick()
	{
		Hide();
	}

	public void OnSettingsButtonClick()
	{
		var halfScreen = Screen.width / 2;
		var pos = transform.position;

		if (_settings.Visible)
		{
			transform.DOMove(
				new Vector3(pos.x + halfScreen, pos.y, pos.z),
				_animationTime);
			_settings.Hide();
		}
		else
		{
			transform.DOMove(
				new Vector3(pos.x - halfScreen, pos.y, pos.z),
				_animationTime);
			_settings.Show();
			// _settings.OnHideComplete = () => {  }
		}
	}

	public void OnSaveButtonClick()
	{
		_game.Save();
	}

	public void OnMenuButtonClick()
	{
		Show();
	}
}
