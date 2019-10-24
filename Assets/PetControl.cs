using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetControl : MonoBehaviour
{
    Animator animator;
    SpriteRenderer ren;
    int state = 0;
    int count = 0;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        ren = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        count += 1;
        if (count / 40 % 2 == 0) {
            ren.flipX = true;
        } else {
            ren.flipX = false;
        }
        if (count % 30 == 0) {
            state = 2;
        } else {
            state = 1;
        }
        animator.SetInteger("pet_state", state);
        if (animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("default")).IsName("pet-walk")) {
            int d = 0;
            if (ren.flipX) d = -1;
            else d = 1;
            Vector2 pos = transform.position;
            pos.x += d * 0.06f;
            transform.position = pos;
        }
    }
}
