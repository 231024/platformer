using DG.Tweening;
using UnityEngine;

public class TweenerController : MonoBehaviour
{
	[SerializeField] private Transform _bird;
	[SerializeField] private Transform _target;
	[SerializeField] private MainMenuTweener _mainMenu;

	private void Awake()
	{
		DOTween.Init();
		_mainMenu.MenuHideAnimationComplete += OnMenuHideAnimationComplete;
	}

	private void OnDestroy()
	{
		_mainMenu.MenuHideAnimationComplete -= OnMenuHideAnimationComplete;
	}

	private void OnMenuHideAnimationComplete()
	{
		StartBirdFlight();
	}

	private void StartBirdFlight()
	{
		var seq = DOTween.Sequence();
		seq.Append(_bird.DOMove(_target.position, 2.0f));
		seq.Append(_bird.DOScaleX(_bird.localScale.x * -1, 0.3f));
		seq.Append(_bird.DOMove(_bird.position, 2.0f));
		seq.Append(_bird.DOScaleX(_bird.localScale.x, 0.3f));
		seq.SetLoops(-1);
	}
}
