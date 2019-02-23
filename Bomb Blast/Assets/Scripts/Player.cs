using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Character character;
    public Bomb bbomb;
    public int thrower;
    public int next;

    private bool throwing;
    private Vector3 startThrow;

	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		if(character.hasBomb)
        {
            print(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch));
            if (!throwing && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0)
            {
                throwing = true;
                startThrow = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            }
            if (throwing && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) <= 0)
            {
                throwing = false;

                // do fancy magic to see who you throw it to
                bbomb.ThrowBomb(thrower, next);
            }
        }
    }


}
