using System;
using System.IO;
using UnityEngine;

public class StreamSaver : ISave<GameSave>
{
	private const string fileName = "gameSave.txt";

	public void Save(GameSave data)
	{
		using var sw = new StreamWriter(Path.Combine(Application.persistentDataPath, fileName));
		sw.WriteLine(data.Health);
		sw.WriteLine(data.Position.x);
		sw.WriteLine(data.Position.y);
		sw.WriteLine(data.Position.z);
	}

	public GameSave Load()
	{
		var save = new GameSave();

		using var sr = new StreamReader(Path.Combine(Application.persistentDataPath, fileName));
		while (!sr.EndOfStream)
		{
			save.Health = Convert.ToInt32(sr.ReadLine());
			save.Position.x = Convert.ToSingle(sr.ReadLine());
			save.Position.y = Convert.ToSingle(sr.ReadLine());
			save.Position.z = Convert.ToSingle(sr.ReadLine());
		}

		return save;
	}
}
