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
		for (int i = 0; i < ListQuiz.Count; i++) {
			if (IdQuestionPopup == ListQuiz [i].Id) {
				QuestionContent.text = ListQuiz [i].Question;
				Answer1Content.text = ListQuiz [i].ListAnswer [0].AnswerContent;
				AnswerButton [0].GetComponent<AnswerHolder> ().AnswerValue = ListQuiz [i].ListAnswer [0].IsRight;
				AnswerButton [0].onClick.AddListener (delegate {
					Debug.Log (AnswerButton [0].GetComponent<AnswerHolder> ().AnswerValue.ToString ());
					QuestionUI.SetActive (false);
					EventManager.TriggerEvent (new MovePlayerEvents (false));
					EventManager.TriggerEvent (new OnMoveEvents (true));
					EventManager.TriggerEvent (new HelpCountEvents (1));

					if (AnswerButton [0].GetComponent<AnswerHolder> ().AnswerValue == true) {
						EventManager.TriggerEvent (new SavedCountEvents (1));
					} else {
						EventManager.TriggerEvent (new WrongCountEvents (1));
					}
				});
				Answer2Content.text = ListQuiz [i].ListAnswer [1].AnswerContent;
				AnswerButton [1].GetComponent<AnswerHolder> ().AnswerValue = ListQuiz [i].ListAnswer [1].IsRight;
				AnswerButton [1].onClick.AddListener (delegate {
					Debug.Log (AnswerButton [1].GetComponent<AnswerHolder> ().AnswerValue.ToString ());
					QuestionUI.SetActive (false);
					EventManager.TriggerEvent (new MovePlayerEvents (false));
					EventManager.TriggerEvent (new OnMoveEvents (true));
					EventManager.TriggerEvent (new HelpCountEvents (1));

					if (AnswerButton [1].GetComponent<AnswerHolder> ().AnswerValue == true) {
						EventManager.TriggerEvent (new SavedCountEvents (1));
					} else {
						EventManager.TriggerEvent (new WrongCountEvents (1));
					}
				});
			}
				
			QuestionUI.SetActive (true);
		}
	}
}
