using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Answer
{
	public string AnswerContent;
	public bool IsRight;

}
[System.Serializable]
public class Quiz
{
	public int Id;
	public string Question;
	public List <Answer> ListAnswer = new List<Answer>(); 
}
	
public class RandomQuizEvents : GameEvent 
{
	
}

public class MovePlayerEvents : GameEvent
{
	public bool IsMove;

	public MovePlayerEvents(bool isMove)
	{
		IsMove = isMove;
	}
}

public class OnMoveEvents : GameEvent
{
	public bool OnMove;

	public OnMoveEvents(bool onMove)
	{
		OnMove = onMove;
	}
}

public class PlayerActionEvents:GameEvent
{
	public bool IsActive;

	public PlayerActionEvents(bool isActive)
	{
		IsActive = isActive;
	}
}