using System;
using UnityEngine;
using Vuforia;

public class VuMarkTrackedBehaviour : MonoBehaviour
{
	[Serializable]
	private class VuMarkModelData
	{
		[SerializeField] private int _id;
		[SerializeField] private string _name;

		public int ID => _id;
		public string Name => _name;
	}

	[Header("Models")]
	[SerializeField] private VuMarkModelData[] _vuMarkModelsData;
	
	[Header("Refrences")]
	[SerializeField] private ModelSpawner _modelSpawner;
	[SerializeField] private PromptWindowUI _promptWindow;
	
	private void Start()
	{
		_promptWindow.OpenWindow();
	}

	public void OnVuMarkFound(VuMarkBehaviour vuMarkBehaviour)
	{
		Debug.Log($"<color=cyan>VuMark: {vuMarkBehaviour.TargetName}, ID:{vuMarkBehaviour.InstanceId} tracked</color>");
		
		var modelName = GetVuMarkModelData(vuMarkBehaviour.InstanceId.NumericValue);

		if (string.IsNullOrEmpty(modelName))
			return;

		_promptWindow.CloseWindow();

		_modelSpawner.CreateModel(modelName);
		
		_modelSpawner.CreatedModel.transform.SetParent(vuMarkBehaviour.transform);
	}

	public void OnVuMarkLost(VuMarkBehaviour vuMarkBehaviour)
	{
		Debug.Log($"<color=cyan>VuMark: {vuMarkBehaviour.TargetName}, ID:{vuMarkBehaviour.InstanceId} lost</color>");
	
		_modelSpawner.ClearWindow();
	}

	private string GetVuMarkModelData(ulong vuMarkId)
	{
		return _vuMarkModelsData[vuMarkId] != null ? _vuMarkModelsData[vuMarkId].Name : string.Empty;
	}
}
