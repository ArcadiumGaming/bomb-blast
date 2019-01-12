using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Character character;
    public Bomb bbomb;
    public int thower;
    public int next;

	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		if(character.hasBomb)
        {
            if(Input.GetButtonDown("Horizontal"))
            {
                bbomb.ThrowBomb(thower, next);
                print("I THREW IT");

            }
        }
	}
}
