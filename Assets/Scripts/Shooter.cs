using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
            else
            {
                Debug.LogWarning(name + " can't find spawner in lane");
            }
        }
    }

    bool IsAttackerAheadInLane()
    {
        //If no attackers, exit method
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        //If attackers, are they ahead of the defender
        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false; //Attackers in lane, but behind defender
    }


}
