using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Rotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); //This will rotate the object a little bit every frame (making it look like a smooth rotation)
	}
}
