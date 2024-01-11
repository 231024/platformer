using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XmlSaver : ISave<GameSave>
{
	private const string fileName = "gameSave.xml";
	private static XmlSerializer _formatter;

	public XmlSaver()
	{
		_formatter = new XmlSerializer(typeof(GameSave));
	}


	public void Save(GameSave data)
	{
		if (data == null && !string.IsNullOrEmpty(Path.Combine(Application.persistentDataPath, fileName)))
		{
			return;
		}

		using var fs = new FileStream(Path.Combine(Application.persistentDataPath, fileName), FileMode.Create);
		_formatter.Serialize(fs, data);
	}

	public GameSave Load()
	{
		if (!File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
		{
			return default;
		}

		using var fs = new FileStream(Path.Combine(Application.persistentDataPath, fileName), FileMode.Open);
		return (GameSave)_formatter.Deserialize(fs);
	}
}
