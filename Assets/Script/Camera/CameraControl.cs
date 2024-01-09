using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject target;
    private Vector3 targetPosition;
    private float moveSpeed;

    void Awake() {
        target = GameObject.Find("Player");
        targetPosition = target.transform.position;
        moveSpeed = 3.0f;
    }

    void Update() {
        if(target.gameObject != null)
        {
            // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            // vectorA -> B까지 T의 속도로 이동
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate() {

    }
}
