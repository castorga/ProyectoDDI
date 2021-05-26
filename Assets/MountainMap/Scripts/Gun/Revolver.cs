using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isIdle")) {
            if(Input.GetMouseButton(0)) {
                animator.Play("Armature|Fire");
            }
        }

        if(Input.GetMouseButton(2)) {
            animator.Play("Armature|Reload");
        }

    
    }
}
