using System;
using UnityEngine;

[CreateAssetMenu(menuName = "1024/Tree Config")]
public class TreeConfig : ScriptableObject
{
	[SerializeField] private AppleInstance[] _apples;

	public AppleInstance[] Apples => _apples;
}

[Serializable]
public class AppleInstance
{
	[SerializeField] private AppleKind _kind;
	[SerializeField] private int _hp;
	[SerializeField] private Color _color;
	[SerializeField] private Apple _prefab;

	public Apple Prefab
	{
		get
		{
			_prefab.GetComponent<SpriteRenderer>().color = _color;
			return _prefab;
		}
	}
}

public enum AppleKind
{
	Macintosh,
	WhiteWave,
	Antony
}
