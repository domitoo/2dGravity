using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GravityObject {

    // Use this for initialization
    public float speed = 4f; //歩くスピード
    //private Rigidbody2D rigidbody2D;
    private Animator anim;
    public bool isChangeDirection = false;
    [SerializeField]
    GameObject pivot;


    public void Start()
    {
        base.Start();
        //各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        
    }

    public void FixedUpdate()
    {
        base.FixedUpdate();
        //左キー: -1、右キー: 1
        float x = Input.GetAxisRaw("Horizontal");
        //左か右を入力したら
        if (x != 0)
        {
            //入力方向へ移動
            rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
            //localScale.xを-1にすると画像が反転する
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;
            //Wait→Dash
            anim.SetBool("Dash", true);
            //左も右も入力していなかったら
        }
        else
        {
            //横移動の速度を0にしてピタッと止まるようにする
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            //Dash→Wait
            anim.SetBool("Dash", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Gravity.y = -Gravity.y;
            //gameManager.ChangeGravity();
            //this.gameObject.transform.Rotate(new Vector3(180, 0, 0));
            this.gameObject.transform.RotateAround(pivot.transform.position, new Vector3(180, 0, 0), 180f);
        }


    }
}
