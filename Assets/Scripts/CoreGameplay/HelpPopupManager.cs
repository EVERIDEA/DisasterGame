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
	HelpPopUp[] _HelpPopUpLV1;
	Dictionary<int, GameObject> _HelpPopUpDataLV1 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV2;
	Dictionary<int, GameObject> _HelpPopUpDataLV2 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV3;
	Dictionary<int, GameObject> _HelpPopUpDataLV3 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV4;
	Dictionary<int, GameObject> _HelpPopUpDataLV4 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV5;
	Dictionary<int, GameObject> _HelpPopUpDataLV5 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV6;
	Dictionary<int, GameObject> _HelpPopUpDataLV6 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV7;
	Dictionary<int, GameObject> _HelpPopUpDataLV7 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV8;
	Dictionary<int, GameObject> _HelpPopUpDataLV8 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV9;
	Dictionary<int, GameObject> _HelpPopUpDataLV9 = new Dictionary<int, GameObject>();

	[SerializeField]
	HelpPopUp[] _HelpPopUpLV10;
	Dictionary<int, GameObject> _HelpPopUpDataLV10 = new Dictionary<int, GameObject>();

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

		//LV1

		for (int i = 0; i < _HelpPopUpLV1.Length; i++) 
		{
			_HelpPopUpDataLV1.Add(_HelpPopUpLV1[i].Id, _HelpPopUpLV1[i].HelpObject);
		}

		//Lv2

		for (int i = 0; i < _HelpPopUpLV2.Length; i++) 
		{
			_HelpPopUpDataLV2.Add(_HelpPopUpLV2[i].Id, _HelpPopUpLV2[i].HelpObject);
		}

		//LV3

		for (int i = 0; i < _HelpPopUpLV3.Length; i++) 
		{
			_HelpPopUpDataLV3.Add(_HelpPopUpLV3[i].Id, _HelpPopUpLV3[i].HelpObject);
		}

		//LV4

		for (int i = 0; i < _HelpPopUpLV4.Length; i++) 
		{
			_HelpPopUpDataLV4.Add(_HelpPopUpLV4[i].Id, _HelpPopUpLV4[i].HelpObject);
		}

		//LV5

		for (int i = 0; i < _HelpPopUpLV5.Length; i++) 
		{
			_HelpPopUpDataLV5.Add(_HelpPopUpLV5[i].Id, _HelpPopUpLV5[i].HelpObject);
		}

		//LV6

		for (int i = 0; i < _HelpPopUpLV6.Length; i++) 
		{
			_HelpPopUpDataLV6.Add(_HelpPopUpLV6[i].Id, _HelpPopUpLV6[i].HelpObject);
		}

		//LV7

		for (int i = 0; i < _HelpPopUpLV7.Length; i++) 
		{
			_HelpPopUpDataLV7.Add(_HelpPopUpLV7[i].Id, _HelpPopUpLV7[i].HelpObject);
		}

		//LV8

		for (int i = 0; i < _HelpPopUpLV8.Length; i++) 
		{
			_HelpPopUpDataLV8.Add(_HelpPopUpLV8[i].Id, _HelpPopUpLV8[i].HelpObject);
		}

		//LV9

		for (int i = 0; i < _HelpPopUpLV9.Length; i++) 
		{
			_HelpPopUpDataLV9.Add(_HelpPopUpLV9[i].Id, _HelpPopUpLV9[i].HelpObject);
		}

		//LV10

		for (int i = 0; i < _HelpPopUpLV10.Length; i++) 
		{
			_HelpPopUpDataLV10.Add(_HelpPopUpLV10[i].Id, _HelpPopUpLV10[i].HelpObject);
		}
	}

	void SetPeopleHelpPopUp()
	{
		//Randomize Set Help Pop up At i-People without repeatation
		for (int i = 0; i < 3; i++) 
		{
			if (Global.LevelSelect==1) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV1.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV1.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==2) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV2.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV2.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==3) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV3.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV3.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==4) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV4.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV4.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==5) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV5.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV5.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==6) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV6.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV6.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==7) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV7.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV7.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==8) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV8.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV8.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==9) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV9.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV9.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==10) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV10.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV10.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}
		}
	}

	void AddPeopleHelpPopUp(AddRandomPeopleEvents e)
	{
		//Randomize Add Help Pop up At i-People without repeatation
		for (int i = 0; i < 1; i++) 
		{
			if (Global.LevelSelect==1) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV1.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV1.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==2) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV2.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV2.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==3) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV3.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV3.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==4) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV4.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV4.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==5) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV5.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV5.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==6) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV6.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV6.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==7) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV7.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV7.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==8) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV8.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV8.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==9) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV9.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV9.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}

			if (Global.LevelSelect==10) 
			{
				int RandomizePeople = Random.Range (1, _HelpPopUpDataLV10.Count-1);
				while (RandomPeople.Contains (RandomizePeople)) 
				{
					RandomizePeople = Random.Range (1, _HelpPopUpDataLV10.Count-1);
				}
				RandomPeople.Add (RandomizePeople);
				EventManager.TriggerEvent (new HelpPeopleEvents (RandomizePeople,true));
			}
		}	
	}

	void RemovePeopleHelpPopUp(RemoveRandomPeopleEvents e)
	{
		//Remove i-People when has been helped
		EventManager.TriggerEvent (new HelpPeopleEvents (e.Id,false));
		RandomPeople.Remove(e.Id);
	}
		

	void HelpPeopleHandler(HelpPeopleEvents e)
	{
		if (Global.LevelSelect==1) 
		{
			_HelpPopUpDataLV1 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==2) 
		{
			_HelpPopUpDataLV2 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==3) 
		{
			_HelpPopUpDataLV3 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==4) 
		{
			_HelpPopUpDataLV4 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==5) 
		{
			_HelpPopUpDataLV5 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==6) 
		{
			_HelpPopUpDataLV6 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==7) 
		{
			_HelpPopUpDataLV7 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==8) 
		{
			_HelpPopUpDataLV8 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==9) 
		{
			_HelpPopUpDataLV9 [e.Id].SetActive(e.IsActive);
		}

		if (Global.LevelSelect==10) 
		{
			_HelpPopUpDataLV10 [e.Id].SetActive(e.IsActive);
		}
	}

	void EndGame()
	{
		RandomPeople.Clear();

		if (Global.LevelSelect==1) 
		{
			for (int i = 0; i < _HelpPopUpDataLV1.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==2) 
		{
			for (int i = 0; i < _HelpPopUpDataLV2.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==3) 
		{
			for (int i = 0; i < _HelpPopUpDataLV3.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==4) 
		{
			for (int i = 0; i < _HelpPopUpDataLV4.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==5) 
		{
			for (int i = 0; i < _HelpPopUpDataLV5.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==6) 
		{
			for (int i = 0; i < _HelpPopUpDataLV6.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==7) 
		{
			for (int i = 0; i < _HelpPopUpDataLV7.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==8) 
		{
			for (int i = 0; i < _HelpPopUpDataLV8.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==9) 
		{
			for (int i = 0; i < _HelpPopUpDataLV9.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}

		if (Global.LevelSelect==10) 
		{
			for (int i = 0; i < _HelpPopUpDataLV10.Count; i++) 
			{
				EventManager.TriggerEvent (new HelpPeopleEvents (i,false));
			}
		}
			
	}
}