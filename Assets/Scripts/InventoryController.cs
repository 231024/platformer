using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
	public int ApplesCount => _apples.Count;
	public UnityAction ApplesCountChanged;
	public UnityAction<int> OnAppleEat;

	private List<AppleTweener> _apples = new();
	public int MaxItemCount => 10;
	public void AddApples(AppleTweener apple)
	{
		if (_apples.Count >= MaxItemCount)
		{
			return;
		}
		_apples.Add(apple);
		ApplesCountChanged?.Invoke();
	}

	public void EatApple()
	{
		if (_apples.Count <= 0)
		{
			return;
		}
		
		var hp = _apples[0].HealthAmount;
		_apples.RemoveAt(0);
		ApplesCountChanged?.Invoke();
		OnAppleEat?.Invoke(hp);
	}
}