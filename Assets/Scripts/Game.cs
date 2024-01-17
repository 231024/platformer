using Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera _cam;
	[SerializeField] private Hero _heroPrefab;

	private GameSave _save;
	private ISave<GameSave> _saver;

	public Hero Hero { get; private set; }

	private void Awake()
	{
		_saver = new JsonSaver();
		Load();

		if (_save == null)
		{
			_save = new GameSave();
			_save.Position = new Vector3(-75, 10, 0);
		}

		Hero = Instantiate(_heroPrefab, _save.Position, Quaternion.identity);

		_cam.Follow = Hero.transform;
	}

	public void StartNew()
	{
	}

	public void Save()
	{
		_save.Position = Hero.transform.position;
		_saver.Save(_save);
	}

	private void Load()
	{
		_save = _saver.Load();
	}
}
