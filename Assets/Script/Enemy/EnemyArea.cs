using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class EnemyArea : Axolot 
    {
        // Start is called before the first frame update

        public Collider2D boundary;
        public override void checkDistance()
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius && boundary.OverlapPoint(target.position))
            {
               if (currentState == StateEnemy.idle || currentState == StateEnemy.walk && currentState != StateEnemy.stagger)
                    {
                        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                        changeAnim(temp - transform.position);
                        myrigidbody2D.MovePosition(temp);
                        ChangeState(StateEnemy.walk);
                        anima.SetBool("IsWalking", true);
                    }
            }
            else if(Vector3.Distance(target.position,transform.position)>chaseRadius
                || !boundary.OverlapPoint(target.position))
            {
                anima.SetBool("IsWalking", false);
            }
        }
    }
}
