using System;
using DG.Tweening;
using UnityEngine;

public class BaseMenu : MonoBehaviour
{
	[SerializeField] private GameObject[] _buttons;

	protected Action OnHideComplete;

	public bool Visible { get; private set; }

	private void Start()
	{
		Hide(true);
	}

	public virtual void Show(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.transform.DOScale(Vector3.one, immediately ? 0.0f : 0.2f);
		}

		Visible = true;
	}

	public virtual void Hide(bool immediately = false)
	{
		foreach (var button in _buttons)
		{
			button.transform.DOScale(Vector3.zero, immediately ? 0.0f : 0.2f);
		}

		Visible = false;
	}
}
