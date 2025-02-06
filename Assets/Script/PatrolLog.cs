using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Aether
{
    public class PatrolLog : Axolot
    {
        // Start is called before the first frame update

        public Transform[] path;
        public int currentPoint;
        public Transform currentGoal;
        public float roundingDistance;
        


        public override void checkDistance()
        {

            if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                if (currentState == StateEnemy.idle || currentState == StateEnemy.walk && currentState != StateEnemy.stagger)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myrigidbody2D.MovePosition(temp);
                    anima.SetBool("IsWalking", true);

                    // ChangeState(StateEnemy.walk);

                }

            }

            else if ( Vector3.Distance(target.position, transform.position) > chaseRadius)
            {
                /*  anima.SetBool("IsWalking", false);*/
                anima.SetBool("IsWalking", true);
                
                if (Vector3.Distance(transform.position, path[currentPoint].position) >= roundingDistance) {
                    
                    Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myrigidbody2D.MovePosition(temp);
                }
                else if(Vector3.Distance(transform.position, path[currentPoint].position)<roundingDistance)
                {
                    ChangeGoal();

                }
                

            }
        }

        private void ChangeGoal() {
            if (currentPoint== path.Length - 1) {
                currentPoint = 0;
                currentGoal = path[0];

            }
            else
            {

                currentPoint++;
                currentGoal = path[currentPoint];

            }
        
        }
    }
}
