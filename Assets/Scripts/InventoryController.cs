using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
	private readonly List<Apple> _apples = new();

	public int ApplesCount => _apples.Count;
	public int MaxItemCount => 10;

	public event UnityAction ApplesCountChanged;
	public event UnityAction<int> OnAppleEat;

	public void AddApples(Apple apple)
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
