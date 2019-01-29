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
	
public class PlayerActionEvents:GameEvent
{
	public bool IsActive;

	public PlayerActionEvents(bool isActive)
	{
		IsActive = isActive;
	}
}

public class HelpCountEvents : GameEvent
{
	public int HelpCount;

	public HelpCountEvents(int helpCount)
	{
		HelpCount = helpCount;
	}
}

public class SavedCountEvents : GameEvent
{
	public int SavedCount;

	public SavedCountEvents(int savedCount)
	{
		SavedCount = savedCount;
	}
}

public class WrongCountEvents : GameEvent
{
	public int WrongCount;

	public WrongCountEvents(int wrongCount)
	{
		WrongCount = wrongCount;
	}
}

public class HelpPeopleEvents : GameEvent
{
	public int Id;
	public bool IsActive;

	public HelpPeopleEvents(int id, bool isActive)
	{
		Id = id;
		IsActive = isActive;
	}
}

public class AddRandomPeopleEvents:GameEvent
{
	
}

public class RemoveRandomPeopleEvents:GameEvent
{
	public int Id;
	public RemoveRandomPeopleEvents(int id)
	{
		Id = id;
	}
}

public class PlayerMoveEvents:GameEvent
{
	public bool Move;
	public PlayerMoveEvents(bool move)
	{
		Move = move;
	}
}

public class PeopleMoveEvents:GameEvent
{
	public bool Wander;
	public PeopleMoveEvents(bool wander)
	{
		Wander = wander;
	}
}

public class LevelEvents:GameEvent
{
	public int Id;
	public bool IsActive;

	public LevelEvents(int id, bool isActive)
	{
		Id = id;
		IsActive = isActive;
	}
}

public class ResultEvents : GameEvent
{

}