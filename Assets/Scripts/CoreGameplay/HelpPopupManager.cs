using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HelpPopUp
{
	public int Id;
	public GameObject HelpObject;
}

public class HelpPopupManager : MonoBehaviour 
{
	[SerializeField]
	HelpPopUp[] _HelpPopUp;
	Dictionary<int, GameObject> _HelpPopUpData = new Dictionary<int, GameObject>();
	public List <int> RandomPeople = new List<int>();

	private void Start()
	{
		SetPeopleHelpPopUp ();
	}
		
	private void Awake()
	{
		EventManager.AddListener<HelpPeopleEvents>(HelpPeopleHandler);
		EventManager.AddListener<AddRandomPeopleEvents> (AddPeopleHelpPopUp);
		EventManager.AddListener<RemoveRandomPeopleEvents>(RemovePeopleHelpPopUp);

		for (int i = 0; i < _HelpPopUp.Length; i++) 
		{
			_HelpPopUpData.Add(_HelpPopUp[i].Id, _HelpPopUp[i].HelpObject);
		}
	}

	void SetPeopleHelpPopUp()
	{
		//Randomize Help Pop up At i-People without repeatation
		for (int i = 0; i < 3; i++) 
		{
			int RandomizePeople = Random.Range (1, _HelpPopUpData.Count-1);
			while (RandomPeople.Contains (RandomizePeople)) 
			{
				RandomizePeople = Random.Range (1, _HelpPopUpData.Count-1);
			}
			RandomPeople.Add (RandomizePeople);
			EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
		}
	}

	void AddPeopleHelpPopUp(AddRandomPeopleEvents e)
	{
		for (int i = 0; i < 1; i++) 
		{
			int RandomizePeople = Random.Range (1, _HelpPopUpData.Count-1);
			while (RandomPeople.Contains (RandomizePeople)) 
			{
				RandomizePeople = Random.Range (1, _HelpPopUpData.Count-1);
			}
			RandomPeople.Add (RandomizePeople);
			EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
		}	
	}

	void RemovePeopleHelpPopUp(RemoveRandomPeopleEvents e)
	{
		EventManager.TriggerEvent (new HelpPeopleEvents (e.Id,false));
		RandomPeople.Remove(e.Id);
	}
		

	void HelpPeopleHandler(HelpPeopleEvents e)
	{
		_HelpPopUpData [e.Id].SetActive(e.IsActive);
	}
		
}