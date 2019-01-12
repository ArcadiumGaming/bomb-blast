using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public GameObject[] players;
    private List<Character> characters;
    private Transform bombLoc;

	// Use this for initialization
	void Start () {
        bombLoc = GetComponent<Transform>();
        characters = new List<Character>();

        foreach (GameObject player in players)
        {
            characters.Add(player.GetComponent<Character>());
        }

        bombLoc.position = players[0].GetComponent<Transform>().position;
        characters[0].hasBomb = true;

        StartCoroutine(waiter());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ThrowBomb(int thrower, int next)
    {
        print("COM " + thrower + " THREW IT TO " + next);
        characters[thrower].hasBomb = false;
        characters[next].hasBomb = true;
        Transform targetLoc = players[next].GetComponent<Transform>();
        bombLoc.position = targetLoc.position;
    }

    IEnumerator waiter()
    {

        int wait_time = Random.Range(5, 15);
        print(wait_time);
        yield return new WaitForSeconds(wait_time);
        
        Explode();
    }

    private void Explode()
    {
        int loser = -1; 
        for(int i = 0; i<characters.Count; i++)
        {
            if (characters[i].hasBomb)
            {
                loser = i;
                break;
            }
        }
        print("PLAYER " + loser + " LOSES.");
        GameObject.Destroy(gameObject);

    }
}
