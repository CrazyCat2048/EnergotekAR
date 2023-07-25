using UnityEngine;
using Vuforia;

public class CameraFocus : MonoBehaviour
{
	private void OnEnable()
	{
		VuforiaApplication.Instance.OnVuforiaStarted += StartVuforiaFocus;
	}

	private void StartVuforiaFocus()
	{
		VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	private void OnDisable()
	{
		VuforiaApplication.Instance.OnVuforiaStarted -= StartVuforiaFocus;
	}
}
