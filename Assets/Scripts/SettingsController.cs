using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
	private const string PrefsSnapshotKeyName = "SnapshotKeyName";
	private const string NoSoundSnapshotName = "NoSound";
	private const string MuteSnapshotName = "Mute";
	private const string DefaultSnapshotName = "Default";

	[SerializeField] private AudioMixer _mixer;
	[SerializeField] private SettingsMenu _settings;

	private void Start()
	{
		_settings.DefaultButtonClicked += OnDefaultButtonClicked;
		_settings.NoSoundButtonClicked += OnNoSoundButtonClicked;
		_settings.MuteButtonCLicked += OnMuteButtonCLicked;

		if (PlayerPrefs.HasKey(PrefsSnapshotKeyName))
		{
			_mixer.FindSnapshot(PlayerPrefs.GetString(PrefsSnapshotKeyName)).TransitionTo(0.0f);
		}
	}

	private void OnDestroy()
	{
		_settings.DefaultButtonClicked -= OnDefaultButtonClicked;
		_settings.NoSoundButtonClicked -= OnNoSoundButtonClicked;
		_settings.MuteButtonCLicked -= OnMuteButtonCLicked;
	}

	private void OnNoSoundButtonClicked()
	{
		SetSnapshotAndSave(NoSoundSnapshotName);
	}

	private void OnMuteButtonCLicked()
	{
		SetSnapshotAndSave(MuteSnapshotName);
	}

	private void OnDefaultButtonClicked()
	{
		SetSnapshotAndSave(DefaultSnapshotName);
	}

	private void SetSnapshotAndSave(string snapshotName)
	{
		_mixer.FindSnapshot(snapshotName).TransitionTo(0.0f);
		PlayerPrefs.SetString(PrefsSnapshotKeyName, snapshotName);
		PlayerPrefs.Save();
	}
}
