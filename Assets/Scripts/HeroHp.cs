using System;
using UnityEngine;

public class HeroHp : MonoBehaviour
{
	[SerializeField] private int _heroMaxHp;
	[SerializeField] private InventoryController _inventoryController;
	
	private int _hp;

	private void Awake()
	{
		_inventoryController = FindObjectOfType<InventoryController>();
		_hp = _heroMaxHp;
	}

	private void OnEnable()
	{
		_inventoryController.OnAppleEat += IncreaseHp;
	}

	private void OnDestroy()
	{
		_inventoryController.OnAppleEat -= IncreaseHp;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		DecreaseHp(5);
	}

	private void IncreaseHp(int value)
	{
		_hp += value;

		if (_hp >= _heroMaxHp)
		{
			_hp = _heroMaxHp;
		}
	}

	private void DecreaseHp(int value)
	{
		_hp -= value;

		if (_hp <= 0)
		{
			_hp = 0;
		}
	}
}
