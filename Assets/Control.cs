using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Animator animator;
    SpriteRenderer ren;
    Rigidbody2D body;
    int walking = 0;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ren = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        animator.ResetTrigger("triggerJump");
        if (Input.GetKeyDown(KeyCode.W)) {
            animator.SetTrigger("triggerJump");
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            walking = -1;
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            walking = 0;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            walking = 1;
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            walking = 0;
        }

        if (walking == 1) {
            ren.flipX = false;
        }
        else if (walking == -1) {
            ren.flipX = true;
        }

        animator.SetInteger("walking", walking);

        doCamera();
    }

    void doCamera() {
        Vector3 pos = cam.transform.position;
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        pos.y = Mathf.Max(pos.y, 0f);
        pos.x = Mathf.Max(pos.x, -11.42f);
        pos.x = Mathf.Min(pos.x, 22.58f);

        cam.transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col) {
        animator.SetTrigger("triggerIdle");
        // walking = 0;
    }
}
