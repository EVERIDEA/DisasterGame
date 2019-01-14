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

	public List <Quiz> ListQuiz = new List<Quiz>();

	private void Awake()
	{
		for (int i = 0; i < ListQuiz.Count; i++) 
		{
			
			if (IdQuestionPopup==ListQuiz[i].Id) 
			{
				QuestionContent.text = ListQuiz[i].Question;
				Answer1Content.text = ListQuiz [i].ListAnswer [0].AnswerContent;
				Answer2Content.text = ListQuiz [i].ListAnswer [1].AnswerContent;
			}
		}

		/*
		foreach (var quizdata in ListQuiz) 
		{
			if (IdQuestionPopup==quizdata.Id) 
			{
				QuestionContent.text = ListQuiz[quizdata.Id].Question;
				Answer1Content.text = ListQuiz [quizdata.Id].ListAnswer [0].AnswerContent;
				Answer2Content.text = ListQuiz [quizdata.Id].ListAnswer [1].AnswerContent;
			}
		}
		*/
	}
}
