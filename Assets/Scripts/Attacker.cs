using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private GameObject currentTarget;
    private float currentSpeed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter with " + collision);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //Called from animator during the attack animation
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
            
        }
        
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
