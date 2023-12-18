using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class InventoryController : MonoBehaviour
{
	public int ApplesCount => _applesCount;
	public UnityAction OnAppleEat;

	private int _applesCount;
	public int MaxItemCount => 10;

	private void Awake()
	{
		_applesCount = Random.Range(0, MaxItemCount);
	}

	public void AddApples(int count)
	{
		var applesToAdd = Math.Min(count, MaxItemCount - _applesCount);
		_applesCount += applesToAdd;
	}

	public void EatApple()
	{
		if (_applesCount > 0)
			_applesCount--;

		OnAppleEat?.Invoke();
	}
}