using UnityEngine;

[CreateAssetMenu(fileName = "New ModelDataBundle", menuName = "ModelDataBundle", order = 0)]
public class ModelDataBundle : ScriptableObject
{
	[SerializeField] private ModelData[] _models;

	public ModelData[] Models => _models;
}
