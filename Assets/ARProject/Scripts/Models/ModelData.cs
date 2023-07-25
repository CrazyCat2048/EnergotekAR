using UnityEngine;

[CreateAssetMenu(fileName = "New ModelData", menuName = "ModelData/Data")]
public class ModelData : ScriptableObject
{
    [SerializeField] private Model _prefab;
    [SerializeField] private string _name;
    [SerializeField] private string _url;

    public Model Model => _prefab;
    public string Name => _name;
    public string URL => _url;
}
