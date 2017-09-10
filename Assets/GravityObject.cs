using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour {
    public GameManager gameManager;
    public Vector3 Gravity = new Vector3(0, -9.8f, 0);
    public Rigidbody2D rigidbody2D;
    // Use this for initialization
    public void Start () {

        gameManager = GameManager.Instance;
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public void FixedUpdate() {
        rigidbody2D.AddForce(Gravity);
    }
}
