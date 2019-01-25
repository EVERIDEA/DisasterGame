﻿using System.Collections;
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

	//Result
	public GameObject Result;
	public Text ResultHelpText;
	public Text ResultSavedText;
	public Text ResultWrongText;

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

	private void Update()
	{
		if (Help == 0) 
		{
			Result.SetActive (true);
			ResultHelpText.text= Help.ToString ();
			ResultSavedText.text = Saved.ToString ();
			ResultWrongText.text = Wrong.ToString ();
		}
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

	void Restart()
	{
		Help = 10;
		HelpText.text="10";
		Saved = 0;
		SavedText.text="0";
		Wrong = 0;
		WrongText.text="0";
	}

}