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
    float Score;

	//Result
	public GameObject Result;
	public Text ResultHelpText;
	public Text ResultSavedText;
	public Text ResultWrongText;
    public Text ResultTimeText;
    public Text ResultDurationText;
    public Text ScoreText;

	private void Awake()
	{
		
	}

	private void Start()
	{
		Help = 10;
		HelpText.text="10";
		Saved = 0;
		SavedText.text="0";
		Wrong = 0;
		WrongText.text="0";
        Score = 0;
	}

	private void Update()
	{
		if (Help == 0) 
		{
            EventManager.TriggerEvent(new ResultEvents());
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

    private void OnEnable()
    {
        EventManager.AddListener<HelpCountEvents>(HelpCountHandler);
        EventManager.AddListener<SavedCountEvents>(SavedCountHandler);
        EventManager.AddListener<WrongCountEvents>(WrongCountHandler);
        EventManager.AddListener<ResultEvents>(ResultHandler);
    }

    private void OnDisable()
    {
        EventManager.RemoveAllListeners();
    }

    /*
     * Kuis
     * 
     * Jumlah pertanyaan = 10
     * ---------------------------   x
     * Jumlah benar = user defined
     * Jumlah salah = user defined
     * ---------------------------   +
     * Perolehan
     * Waktu
     * 
     * Jumlah waktu = 120 detik
     * Jumlah durasi = user defined
     * ----------------------------  -
     * Time skor  =
     * 
     * Rumus Skor
     * 
     * [Score = ((Jumlah benar - Jumlah salah) * Jumlah pertanyaan) + (Jumlah waktu - durasi)]
     * 
     */

    void ResultHandler(ResultEvents e)
    {
        Time.timeScale = 0;
        Result.SetActive(true);
        ResultHelpText.text = Help.ToString();
        ResultSavedText.text = Saved.ToString();
        ResultWrongText.text = Wrong.ToString();
        ResultTimeText.text = Global.Timer.ToString("F0");
        ResultDurationText.text = Global.Duration.ToString("F0");

        Score = ((Saved - Wrong) * Help) + (Global.Timer - Global.Duration);
        if (Score<0)
        {
            Score = 0;
        }
        ScoreText.text = Score.ToString("F0");
    }
}