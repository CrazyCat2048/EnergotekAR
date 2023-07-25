using System.Collections.Generic;
using UnityEngine;

public class ModelSpawner : MonoBehaviour
{
	[Header("Models")]
	[SerializeField] private ModelDataBundle _modelBundle;
	
	[Header("Spawn Settings")]
	[SerializeField] private Transform _parent;
	[SerializeField] private Vector3 _startPosition;
	[SerializeField] private float _scaleMultiplier;

	[Header("References To Models Extenders")]
	[SerializeField] private ViewerWindow _viewerWindow;
	[SerializeField] private ModelAnalyzer _modelAnalyzer;
	[SerializeField] private ModelCleaningButtonUI _clearButton;
	[SerializeField] private PlayerInput _input;

	[Header("Initialize Scene Type")]
	[SerializeField] private bool _isARScene = false;

	private Model _createdModel;
	public Model CreatedModel => _createdModel;

	public ModelData[] ModelsData => _modelBundle.Models;

	public void CreateModel(string modelName)
	{
		DeleteModel();

		ModelData model = GiveModelFromBundle(modelName);

		if (!model)
			return;

		_viewerWindow.ActivateMenu(model.URL);

		Model createdModel = Instantiate(model.Model, _parent);

		createdModel.MultiplyScale(_scaleMultiplier);

		createdModel.transform.position = _startPosition;

		_input.OnTouched += createdModel.Rotate;

		_createdModel = createdModel;

		if (_isARScene)
		{
			_clearButton.Activate(this);
		}

		_modelAnalyzer.Analyze(createdModel);
	}

	public void ClearWindow()
	{
		DeleteModel();
		
		_viewerWindow.DiactivateMenu();
	}
	
	private void DeleteModel()
	{
		if (!_createdModel)
			return;
		
		_input.OnTouched -= _createdModel.Rotate;

		Destroy(_createdModel.gameObject);
	}

	private ModelData GiveModelFromBundle(string name)
	{
		foreach (var model in ModelsData)
		{
			if (model.Name.Equals(name))
				return model;
		}
		
		return null;
	}
}
