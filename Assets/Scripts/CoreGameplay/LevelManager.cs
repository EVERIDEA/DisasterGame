using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
	public int Id;
	public GameObject LevelObject;
}

public class LevelManager : MonoBehaviour 
{
	[SerializeField]
	Level[] _Level;
	Dictionary<int,GameObject> _LevelData = new Dictionary<int, GameObject>();

	private void Awake()
	{
        for (int i = 0; i < _Level.Length; i++) 
		{
            _LevelData.Add (_Level[i].Id, _Level[i].LevelObject);
		}
	}

    private void OnEnable()
    {
        EventManager.AddListener<LevelEvents>(LevelHandler);
    }

    private void OnDisable()
    {
        EventManager.RemoveAllListeners();
    }

    private void Start()
    {
        EventManager.TriggerEvent(new LevelEvents(Global.LevelSelect, true));
    }

    void LevelHandler(LevelEvents e)
	{
		_LevelData [e.Id].SetActive (e.IsActive);
	}
}