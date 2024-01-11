using System.IO;
using UnityEngine;

public class JsonSaver : ISave<GameSave>
{
	private const string fileName = "gameSave.json";

	public void Save(GameSave data)
	{
		var str = JsonUtility.ToJson(data);
		File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), str);
	}

	public GameSave Load()
	{
		if (!File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
		{
			return default;
		}

		var str = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName));
		return JsonUtility.FromJson<GameSave>(str);
	}
}
