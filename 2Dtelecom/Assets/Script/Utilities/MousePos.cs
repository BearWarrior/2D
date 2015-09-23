using UnityEngine;
using System.Collections;

public class MousePos : MonoBehaviour {

    public static Vector2 position;
	// Use this for initialization
	void Start () {
        position = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
        position = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
    }
}
