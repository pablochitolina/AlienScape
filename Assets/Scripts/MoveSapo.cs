using UnityEngine;
using System.Collections;

public class MoveSapo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * 3);
	}
}
