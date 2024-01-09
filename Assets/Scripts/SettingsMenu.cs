using UnityEngine.Events;

public class SettingsMenu : BaseMenu
{
	public UnityAction DefaultButtonClicked;
	public UnityAction MuteButtonCLicked;
	public UnityAction NoSoundButtonClicked;

	public void OnMuteClick()
	{
		MuteButtonCLicked.Invoke();
	}

	public void OnNoSoundClick()
	{
		NoSoundButtonClicked.Invoke();
	}

	public void OnDefaultClick()
	{
		DefaultButtonClicked.Invoke();
	}
}
