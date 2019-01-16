using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuizManager : MonoBehaviour
{
	public Text QuestionContent;
	public Text Answer1Content;
	public Text Answer2Content;
	public int IdQuestionPopup;
	public GameObject QuestionUI;
	public Button [] AnswerButton;

	public List <Quiz> ListQuiz = new List<Quiz>();

	private void Awake()
	{
		EventManager.AddListener<RandomQuizEvents>(QuizRandomizer);
	}

	private void QuizRandomizer(RandomQuizEvents e)
	{
		IdQuestionPopup=Random.Range (1,11);
		Debug.Log (IdQuestionPopup);
		EventManager.TriggerEvent (new PlayerActionEvents (false));
		for (int i = 0; i < ListQuiz.Count; i++) 
		{
			if (IdQuestionPopup==ListQuiz[i].Id) 
			{
				QuestionContent.text = ListQuiz[i].Question;
				Answer1Content.text = ListQuiz [i].ListAnswer [0].AnswerContent;
				AnswerButton[0].GetComponent<AnswerHolder>().AnswerValue=ListQuiz[i].ListAnswer[0].IsRight;
				AnswerButton [0].onClick.AddListener(delegate
					{
						Debug.Log (AnswerButton[0].GetComponent<AnswerHolder>().AnswerValue.ToString ());
						QuestionUI.SetActive (false);
						EventManager.TriggerEvent(new MovePlayerEvents (false));
						EventManager.TriggerEvent (new OnMoveEvents (true));
					});
				Answer2Content.text = ListQuiz [i].ListAnswer [1].AnswerContent;
				AnswerButton[1].GetComponent<AnswerHolder>().AnswerValue=ListQuiz[i].ListAnswer[1].IsRight;
				AnswerButton [1].onClick.AddListener(delegate
					{
						Debug.Log (AnswerButton[1].GetComponent<AnswerHolder>().AnswerValue.ToString ());
						QuestionUI.SetActive (false);
						EventManager.TriggerEvent (new MovePlayerEvents (false));
						EventManager.TriggerEvent (new OnMoveEvents (true));
					});
			}

			/*
			if (i > ListQuiz.Count) 
			{
				QuestionContent.text = ListQuiz[ListQuiz.Count].Question;
				Answer1Content.text = ListQuiz [ListQuiz.Count].ListAnswer [0].AnswerContent;
				AnswerButton [0].onClick.AddListener(delegate
					{
						//bool answerValue1=ListQuiz[ListQuiz.Count].ListAnswer[0].IsRight;
						Debug.Log ("Value2.1");
					});
				Answer2Content.text = ListQuiz [ListQuiz.Count].ListAnswer [1].AnswerContent;
				AnswerButton [1].onClick.AddListener(delegate
					{
						//bool answerValue2=ListQuiz[ListQuiz.Count].ListAnswer[1].IsRight;
						Debug.Log ("Value2.2");
					});

			}
			*/
		}
		QuestionUI.SetActive (true);

	}
}
