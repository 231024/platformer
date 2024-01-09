using DG.Tweening;
using UnityEngine;

public class Apple : MonoBehaviour
{
	[SerializeField] private float _animationTime;
	[SerializeField] private int _healthAmount;

	public int HealthAmount => _healthAmount;
	public Vector3 TargetPos { get; set; }

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			AppleFlight();
			var invCon = FindObjectOfType<InventoryController>();
			invCon.AddApples(this);
		}
	}

	private void AppleFlight()
	{
		var seq = DOTween.Sequence();
		seq.Append(transform.DOMove(TargetPos, _animationTime));
		seq.AppendCallback(() => { Destroy(gameObject); });
	}
}
