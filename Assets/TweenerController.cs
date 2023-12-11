using DG.Tweening;
using UnityEngine;

public class TweenerController : MonoBehaviour
{
	[SerializeField] private Transform _bird;
	[SerializeField] private Transform _target;
	[SerializeField] private Transform _mainMenu;

	private void Awake()
	{
		DOTween.Init();
	}
	
	private void StartBirdFlight()
	{
		Sequence seq = DOTween.Sequence();
		seq.SetDelay(1.0f);
		seq.Append(_bird.DOMove(_target.position, 2.0f));
		seq.Append(_bird.DOScaleX(-5, 0.3f));
		seq.Append(_bird.DOMove(_bird.position, 2.0f));
		seq.Append(_bird.DOScaleX(5, 0.3f));
		seq.SetLoops(-1);
		seq.Play();
	}

	public void HideMenu()
	{
		var pos = _mainMenu.position;
		Sequence seq = DOTween.Sequence();
		seq.Append(_mainMenu.DOMove(new Vector3(pos.x, pos.y + 1000, pos.z), 3.0f));
		seq.AppendCallback(StartBirdFlight);
		seq.Play();
	}
}
