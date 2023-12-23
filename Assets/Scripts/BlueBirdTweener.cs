using DG.Tweening;
using UnityEngine;

public class BlueBirdTweener : MonoBehaviour
{
	[SerializeField] private Transform _bird;
	[SerializeField] private Transform _target;
	[SerializeField] private float _moveTime;
	[SerializeField] private float _flipTime;

	private void Awake()
	{
		DOTween.Init();
		StartBirdFlight();
	}

	private void StartBirdFlight()
	{
		var seq = DOTween.Sequence();
		seq.Append(_bird.DOMove(_target.position, _moveTime));
		seq.Append(_bird.DOScaleX(_bird.localScale.x * -1, _flipTime));
		seq.Append(_bird.DOMove(_bird.position, _moveTime));
		seq.Append(_bird.DOScaleX(_bird.localScale.x * -1, _flipTime));
		seq.SetLoops(-1);
	}
}
