using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    [SerializeField]
    GameObject player;
    Vector3 Gravity = new Vector3(-9.8f, 0, 0);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraControll();
    }

    void CameraControll()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 temp = this.transform.position;

        if (playerPos.x > transform.position.x + 1 || playerPos.x < transform.position.x - 1)
        {
            temp.x = playerPos.x;
        }
        if (playerPos.y > transform.position.y + 1 || playerPos.y < transform.position.y - 1)
        {
            temp.y = playerPos.y;
        }

        this.transform.position = Vector3.Lerp(this.transform.position, temp, 2 * Time.deltaTime);
    }


    public void ChangeGravity()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Obj");
        foreach (GameObject obj in objs)
        {
            //obj.GetComponent<Rigidbody2D>().AddForce(Gravity);
        }

    }

}
