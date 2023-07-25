using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScrollLineSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private ScrollLine _linePrefab;
    
    [Header("References On Components")]
    [SerializeField] private WindowChanger _windowChanger;

    private List<ScrollLine> _saveLines = new List<ScrollLine>();

    public void Init(List<ModelCard> models)
    {
        ClearLines();

        int countModels = models.Count;
        int countLines = countModels / 2;

        Queue<ScrollLine> queueLines = new Queue<ScrollLine>();

        for (int i = 0; i < countLines; i++)
        {
            ScrollLine line = Instantiate(_linePrefab, transform);

            _saveLines.Add(line);

            queueLines.Enqueue(line);
        }

		for (int i = 0; i < countModels; i = i + 2)
		{
            queueLines.Dequeue().Init(models[i], models[i + 1], _windowChanger);
		}
    }

    private void ClearLines()
    {
        foreach (var line in _saveLines)
        {
            Destroy(line.gameObject);
        }

        _saveLines.Clear();
    }
}
