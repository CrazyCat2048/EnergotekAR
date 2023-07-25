using UnityEngine;

public class SubsectionWindow : MenuWithScrollPanelUI
{
	[Header("Lists Subtitles")]
	[SerializeField] private RectTransform[] _sections;

	public void Initialize(int sectionID)
	{
		DiactivteSections();

		_sections[sectionID].gameObject.SetActive(true);
	}

	private void DiactivteSections()
	{
		foreach (var section in _sections)
		{
			section.gameObject.SetActive(false);
		}
	}
}
