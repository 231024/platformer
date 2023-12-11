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

	public UnityAction MenuHideAnimationComplete; 

	private void Awake()
	{
		Show();
	}

	private void Show()
	{
		var newGamePos = _newGameButton.position;
		var continuePos = _continueButton.position;
		var creditsPos = _creditsButton.position;
		var exitPos = _exitButton.position;
		var settingsPos = _settingsButton.position;

		var seq = DOTween.Sequence();
		seq.Append(_newGameButton.DOMove(new Vector3(newGamePos.x - _offscreen, newGamePos.y, newGamePos.z), 0));
		seq.Join(_continueButton.DOMove(new Vector3(continuePos.x - _offscreen, continuePos.y, continuePos.z), 0));
		seq.Join(_creditsButton.DOMove(new Vector3(creditsPos.x, creditsPos.y + _offscreen, creditsPos.z), 0));
		seq.Join(_exitButton.DOMove(new Vector3(exitPos.x, exitPos.y - _offscreen, exitPos.z), 0));
		seq.Join(_settingsButton.DOMove(new Vector3(settingsPos.x + _offscreen, settingsPos.y, settingsPos.z), 0));
		seq.Append(_newGameButton.DOMove(newGamePos, _animationTime));
		seq.Append(_continueButton.DOMove(continuePos, _animationTime));
		seq.Append(_creditsButton.DOMove(creditsPos, _animationTime));
		seq.Append(_exitButton.DOMove(exitPos, _animationTime));
		seq.Append(_settingsButton.DOMove(settingsPos, _animationTime));
	}

	private void Hide()
	{
		var newGamePos = _newGameButton.position;
		var continuePos = _continueButton.position;
		var creditsPos = _creditsButton.position;
		var exitPos = _exitButton.position;
		var settingsPos = _settingsButton.position;

		var seq = DOTween.Sequence();
		seq.Append(_newGameButton.DOMove(new Vector3(newGamePos.x - _offscreen, newGamePos.y, newGamePos.z),
			_animationTime));
		seq.Append(_continueButton.DOMove(new Vector3(continuePos.x - _offscreen, continuePos.y, continuePos.z),
			_animationTime));
		seq.Append(_creditsButton.DOMove(new Vector3(creditsPos.x, creditsPos.y + _offscreen, creditsPos.z),
			_animationTime));
		seq.Append(_exitButton.DOMove(new Vector3(exitPos.x, exitPos.y - _offscreen, exitPos.z),
			_animationTime));
		seq.Append(_settingsButton.DOMove(new Vector3(settingsPos.x + _offscreen, settingsPos.y, settingsPos.z),
			_animationTime));
		seq.AppendCallback(MenuHideAnimationComplete.Invoke);
	}

	public void OnContinueGameClick()
	{
		Hide();
	}
}
