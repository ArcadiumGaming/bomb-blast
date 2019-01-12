using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDuperAI : MonoBehaviour
{

    private Character character;
    public Bomb bbomb;
    public int thower;
    public int next;
    private bool isThrowing = false;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.hasBomb && !isThrowing)
        {
            isThrowing = true;
            StartCoroutine(waiter());
            
        }
    }

    IEnumerator waiter()
    {

        int wait_time = Random.Range(0, 5);
        yield return new WaitForSeconds(wait_time);
        isThrowing = false;
        bbomb.ThrowBomb(thower, next);
    }
}
