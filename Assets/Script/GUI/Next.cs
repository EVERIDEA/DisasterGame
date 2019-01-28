using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : StateComponentBase<GameManager>
{ 

    public override void EnterState()
    {
        Global.LevelSelect += 1;
        if (Global.LevelSelect>10)
        {
            Global.LevelSelect = 1;
        }
    }
    public override void ExitState()
    {
        
    }

    private void Update()
    {
    }
}
