using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatus  {

    public System.String Id;
    public System.Int32 Hp;
    public System.Int32 Mp;

    public PlayerStatus(string id, int hp, int mp)
    {
        Id = id;
        Hp = hp;
        Mp = mp;
    }
}
