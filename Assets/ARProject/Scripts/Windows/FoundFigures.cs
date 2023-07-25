using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScrollLineSpawner))]
public class FoundFigures : MonoBehaviour
{
	[Header("Models Data")]
    [SerializeField] private ModelCard[] _cards;
	[SerializeField] private ModelCard _empty;

	private ScrollLineSpawner _lineSpawner;

	private List<ModelCard> _cardsToDisplay;

	private string _neededRequest;

	private void Awake()
	{
		_lineSpawner = GetComponent<ScrollLineSpawner>();
	}

	public bool InitScrollPanel(string request)
	{
		_neededRequest = request;
		
		int numModels = DetermineNeededModels();

		if (numModels == 0)
		{
			return false;
		}

		if (numModels % 2 == 1)
		{
			numModels++;

			_cardsToDisplay.Add(_empty);
		}
		
		return true;
	}

	private int DetermineNeededModels()
	{
		_cardsToDisplay = new List<ModelCard>();

		string cardName;

		foreach (var card in _cards)
		{
			cardName = card.Name;

			if (cardName.IndexOf(_neededRequest, StringComparison.CurrentCultureIgnoreCase) >= 0)
			{
				_cardsToDisplay.Add(card);
			}
		}

		return _cardsToDisplay.Count;
	}

	public void CreateLinesForPanels()
	{
		_lineSpawner.Init(_cardsToDisplay);
	}
}
