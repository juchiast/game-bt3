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

    GameObject height;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ren = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        height = GameObject.Find("height");
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

        height.transform.localScale = new Vector3(1 + 2 * (transform.position.y + 2.25f), 1, 1);
        height.transform.position = new Vector3(-8 + cam.transform.position.x, 4.4f + cam.transform.position.y, 0);
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
