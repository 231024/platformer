using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuTweener : MonoBehaviour
{
	[SerializeField] private RectTransform _newGameButton;
	[SerializeField] private RectTransform _continueButton;
	[SerializeField] private RectTransform _creditsButton;
	[SerializeField] private RectTransform _exitButton;
	[SerializeField] private RectTransform _settingsButton;
	[SerializeField] private float _offscreen;
	[SerializeField] private float _animationTime;

	public UnityAction DefaultButtonClicked;
	public UnityAction MenuHideAnimationComplete;
	public UnityAction MuteButtonCLicked;
	public UnityAction NoSoundButtonClicked;

	private void Awake()
	{
		_continueButton.DOMove(new Vector3(-_offscreen, _continueButton.position.y, _continueButton.position.z), 0);
		_creditsButton.DOMove(new Vector3(_creditsButton.position.x, Screen.height + _offscreen, _creditsButton.position.z), 0);
		_newGameButton.DOMove(new Vector3(-_offscreen, _newGameButton.position.y, _newGameButton.position.z), 0);
		_settingsButton.DOMove(new Vector3(Screen.width + _offscreen, _settingsButton.position.y, _settingsButton.position.z), 0);
		_exitButton.DOMove(new Vector3(_exitButton.position.x, -_offscreen, _exitButton.position.z), 0);

		Show();
	}

	private void Show()
	{
		var seq = DOTween.Sequence();
		seq.Append(_continueButton.DOMove(_continueButton.position, _animationTime));
		seq.Append(_creditsButton.DOMove(_creditsButton.position, _animationTime));
		seq.Append(_newGameButton.DOMove(_newGameButton.position, _animationTime));
		seq.Append(_settingsButton.DOMove(_settingsButton.position, _animationTime));
		seq.Append(_exitButton.DOMove(_exitButton.position, _animationTime));
	}

	private void Hide()
	{
		var seq = DOTween.Sequence();
		seq.Append(_exitButton.DOMove(new Vector3(_exitButton.position.x, -_offscreen, _exitButton.position.z),
			_animationTime));
		seq.Append(_settingsButton.DOMove(new Vector3(Screen.width + _offscreen, _settingsButton.position.y, _settingsButton.position.z),
			_animationTime));
		seq.Append(_newGameButton.DOMove(new Vector3(-_offscreen, _newGameButton.position.y, _newGameButton.position.z),
			_animationTime));
		seq.Append(_creditsButton.DOMove(new Vector3(_creditsButton.position.x, Screen.height + _offscreen, _creditsButton.position.z),
			_animationTime));
		seq.Append(_continueButton.DOMove(new Vector3(-_offscreen, _continueButton.position.y, _continueButton.position.z),
			_animationTime));
		seq.AppendCallback(MenuHideAnimationComplete.Invoke);
	}

	public void OnContinueGameClick()
	{
		Hide();
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
