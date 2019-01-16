using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	public Text HelpText;
	public Text SavedText;
	public Text WrongText;

	int Help;
	int Saved;
	int Wrong;

	private void Awake()
	{
		EventManager.AddListener<HelpCountEvents>(HelpCountHandler);
		EventManager.AddListener<SavedCountEvents>(SavedCountHandler);
		EventManager.AddListener<WrongCountEvents>(WrongCountHandler);
	}

	private void Start()
	{
		Help = 10;
		HelpText.text="10";
		Saved = 0;
		SavedText.text="0";
		Wrong = 0;
		WrongText.text="0";
	}

	void HelpCountHandler(HelpCountEvents e)
	{
		Help -= e.HelpCount;
		HelpText.text = Help.ToString ();
	}

	void SavedCountHandler(SavedCountEvents e)
	{
		Saved += e.SavedCount;
		SavedText.text = Saved.ToString ();
	}

	void WrongCountHandler(WrongCountEvents e)
	{
		Wrong += e.WrongCount;
		WrongText.text = Wrong.ToString ();
	}

}