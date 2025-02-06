using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Axolot : Enemy
{
    // Start is called before the first frame update
    [Header("Target Variables")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    
    [Header("Animator")]
    public Animator anima;
    public Rigidbody2D myrigidbody2D;
    void Start()
    {

        currentState = StateEnemy.idle;
        myrigidbody2D = GetComponent<Rigidbody2D>();
        /*myrigidbody2D.transform.position = homePos;*/
        anima = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        
        /*anima.SetBool("IsWalking", true);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkDistance();
        
    }


    public virtual void checkDistance()
    {

        if(Vector3.Distance(target.position,transform.position)<=chaseRadius
            && Vector3.Distance(target.position,transform.position)>attackRadius) {
            if (currentState == StateEnemy.idle || currentState == StateEnemy.walk && currentState != StateEnemy.stagger)
            {
               Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp-transform.position);
                myrigidbody2D.MovePosition(temp);
                anima.SetBool("IsWalking", true);

                ChangeState(StateEnemy.walk);
                
            }
            
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anima.SetBool("IsWalking", false);
        }
    }
    public void ChangeState(StateEnemy newState) {
        if (currentState != newState) { 
            currentState = newState;
        }
    }

    public void SetAnimFloat(Vector2 setVector) { 
    
        anima.SetFloat("MoveX",setVector.x);
        anima.SetFloat("MoveY", setVector.y);
    }

    public void changeAnim(Vector2 direction) {

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) { 
            if(direction.x>0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x<0) { 
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x)<Mathf.Abs(direction.y))
        {
            if(direction.y>0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y<0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
}
