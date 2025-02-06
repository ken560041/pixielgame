using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class TurretEnemy : Axolot
    {
        // Start is called before the first frame update
        public GameObject projectitle;
       
        public float fireDelay;
        public float fireDelaySeconds;
        public bool canFire = true;

        private void Update()
        {
            fireDelaySeconds-= Time.deltaTime;
            if (fireDelaySeconds <= 0) { 
            canFire = true;
                fireDelaySeconds = fireDelay;
            }
        }


        public override void checkDistance()
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius
          && Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                if (currentState == StateEnemy.idle || currentState == StateEnemy.walk && currentState != StateEnemy.stagger)
                {
                    if (canFire)
                    {
                        Vector2 tempVector = target.position - transform.position;
                        
                        GameObject current = Instantiate(projectitle, transform.position, Quaternion.identity);
                        current.GetComponent<Projectitle>().Lanch(tempVector);
                        canFire = false;
                        anima.SetBool("IsWalking", true);

                        ChangeState(StateEnemy.walk);
                    }

                }

            }
            else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
            {
                anima.SetBool("IsWalking", false);

            }
        }
    }
}
