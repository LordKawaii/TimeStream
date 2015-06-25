using UnityEngine;
using System.Collections;

public enum NodeType
{
    Brave,
    Timid,
    Curious,
    Direct,
    Waypoint
}

public enum Person
{
    Pawn,
    Enemy,
    None
};

public enum InterventionType
{
    InfoCryptic,
    InfoDirect,
    Weapon,
    Trap,
    None
};

public enum Obstical
{
    Blockade,
    LockedDoor
}


public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
