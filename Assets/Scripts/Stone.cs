using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            animator.SetTrigger("underAttack trigger");
        }
    }
}
