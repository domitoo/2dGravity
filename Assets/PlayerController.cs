using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float speed = 4f; //歩くスピード
    private Rigidbody2D rigidbody2D;
    private Animator anim;

    void Start()
    {
        //各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
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
        
    }
    public void ChangeGravity()
    {

        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -this.gameObject.GetComponent<Rigidbody2D>().gravityScale;
        if (this.gameObject.transform.position.y > 0)
        {
            this.gameObject.transform.position -= new Vector3(0, 0.1f, 0);
        }
        else
        { 
            this.gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
        Vector2 temp = this.gameObject.transform.localScale;
        temp.y = -temp.y;
        this.gameObject.transform.localScale = temp;
    }
}
