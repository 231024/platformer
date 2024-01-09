using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableObject : MonoBehaviour
{
	[SerializeField] private TreeConfig _config;
	private Transform _targetTransform;
	[SerializeField] private Tilemap _map;

	private void Start()
	{
		_targetTransform = FindObjectOfType<HudController>().ApplesMagnet;
	}

	public void Interact()
	{
		transform.DOShakePosition(0.1f).SetEase(Ease.OutQuad);
		var hudPos = Camera.main.ScreenToWorldPoint(_targetTransform.position);
		Instantiate(_config.Apples[0].Prefab, transform.position, transform.rotation).TargetPos = hudPos;
	}
}
