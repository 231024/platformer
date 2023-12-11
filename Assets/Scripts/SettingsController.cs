using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
	private const string PrefsSnapshotKeyName = "SnapshotKeyName";
	private const string NoSoundSnapshotName = "NoSound";
	private const string MuteSnapshotName = "Mute";
	private const string DefaultSnapshotName = "Default";

	[SerializeField] private AudioMixer _mixer;
	[SerializeField] private MainMenuTweener _mainMenu;

	private void Start()
	{
		_mainMenu.DefaultButtonClicked += OnDefaultButtonClicked;
		_mainMenu.NoSoundButtonClicked += OnNoSoundButtonClicked;
		_mainMenu.MuteButtonCLicked += OnMuteButtonCLicked;

		if (PlayerPrefs.HasKey(PrefsSnapshotKeyName))
		{
			_mixer.FindSnapshot(PlayerPrefs.GetString(PrefsSnapshotKeyName)).TransitionTo(0.0f);
		}
	}

	private void OnDestroy()
	{
		_mainMenu.DefaultButtonClicked -= OnDefaultButtonClicked;
		_mainMenu.NoSoundButtonClicked -= OnNoSoundButtonClicked;
		_mainMenu.MuteButtonCLicked -= OnMuteButtonCLicked;
	}

	private void OnNoSoundButtonClicked()
	{
		_mixer.FindSnapshot(NoSoundSnapshotName).TransitionTo(0.0f);
		PlayerPrefs.SetString(PrefsSnapshotKeyName, NoSoundSnapshotName);
		PlayerPrefs.Save();
	}

	private void OnMuteButtonCLicked()
	{
		_mixer.FindSnapshot(MuteSnapshotName).TransitionTo(0.0f);
		PlayerPrefs.SetString(PrefsSnapshotKeyName, MuteSnapshotName);
		PlayerPrefs.Save();
	}

	private void OnDefaultButtonClicked()
	{
		_mixer.FindSnapshot(DefaultSnapshotName).TransitionTo(0.0f);
		PlayerPrefs.SetString(PrefsSnapshotKeyName, DefaultSnapshotName);
		PlayerPrefs.Save();
	}
}
