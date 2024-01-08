using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public static PlayerControl instance = null;
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private float horizontal;
    private float vertical;
    private float moveSpeed;
    private bool keyDownLeft = false;

    void Awake() {
        // 싱글톤 인스턴스 생성 로직
        if (instance == null) {
            instance = this;
        } else if(instance != this) {
        	Destroy(this.gameObject);
        }

        // 씬이 변경되도 오브젝트 유지
        DontDestroyOnLoad(this.gameObject);

        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        vertical = Input.GetAxisRaw("Vertical") * moveSpeed;
        moveSpeed = 2.0f;

        if (Input.GetKeyDown(KeyCode.A)) {
            keyDownLeft = true;
        } else if(Input.GetKeyDown(KeyCode.D)) {
            keyDownLeft = false;
        }
    }

    void FixedUpdate() {
        // keyDownLeft가 true면 X축 플립
        sprite.flipX = keyDownLeft;

        rigid.velocity = new Vector2(horizontal, vertical);
    }

    public float GetHorizontal() {
        return horizontal;
    }

    public float GetVertical() {
        return vertical;
    }
}
