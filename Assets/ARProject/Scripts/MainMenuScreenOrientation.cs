using UnityEngine;

public class MainMenuScreenOrientation : ARScreenCustomizer
{
	[SerializeField] private WindowChanger _windowChanger;
	
	protected override void OnEnable()
	{
		base.OnEnable();

		_windowChanger.OnVieverModelWindowEnabled += orientionChanger.AllowAutoRotation;
		_windowChanger.OnVieverModelWindowDisabled += orientionChanger.ReturnToPortraitAndBlockAutoRotation;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		
		_windowChanger.OnVieverModelWindowEnabled -= orientionChanger.AllowAutoRotation;
		_windowChanger.OnVieverModelWindowDisabled -= orientionChanger.ReturnToPortraitAndBlockAutoRotation;
	}
}
