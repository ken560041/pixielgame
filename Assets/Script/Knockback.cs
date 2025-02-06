using System.Collections;
using System.Collections.Generic;
using Aether;
using UnityEngine;
using UnityEngine.Windows;

public class Knockback : MonoBehaviour
{
    // Start is called before the first frame update

    public float thrust;
    public float knockTime;
    public PlayerMovement playerMovement;
    public float damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (collision.gameObject.CompareTag("Object"))
        {
            collision.GetComponent<Hana>().Smash();
        }

        if (collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Player")) { 
            Rigidbody2D hit=collision.GetComponent<Rigidbody2D>();
            
            if (hit != null)
            {
                bool isAttack = playerMovement.animator.GetBool("IsAttack");
                
                if (collision.gameObject.CompareTag("Enemy")&& (this.gameObject.CompareTag("Hitbox") || this.gameObject.CompareTag("MellHitBoxPlayer"))) {

                    if (this.gameObject.CompareTag("Hitbox") && playerMovement.currentState == PlayerState.attack)
                    {
                        Vector2 difference = hit.transform.position - transform.position;
                        difference = difference.normalized * thrust;
                        hit.AddForce(difference, ForceMode2D.Impulse);
                        hit.GetComponent<Enemy>().currentState = StateEnemy.stagger;
                        collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                        hit.GetComponent<Enemy>().currentState = StateEnemy.walk;

                    }
                    else if (this.gameObject.CompareTag("MellHitBoxPlayer")) {
                        Vector2 difference = hit.transform.position - transform.position;
                        difference = difference.normalized * thrust;
                        hit.AddForce(difference, ForceMode2D.Impulse);
                        hit.GetComponent<Enemy>().currentState = StateEnemy.stagger;
                        collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                        hit.GetComponent<Enemy>().currentState = StateEnemy.walk;

                    }
                    
                    
                }
                else if (collision.gameObject.CompareTag("Player") ){

                    if (this.gameObject.CompareTag("MellHitBoxEnemy")) {
                        if (collision.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                        {

                            
                            hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                            collision.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                            Vector2 difference = hit.transform.position - transform.position;
                            difference = difference.normalized * thrust;
                            hit.AddForce(difference, ForceMode2D.Impulse);

                        }
                    }
                    else if (this.gameObject.CompareTag("Enemy")){

                        if (collision.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                        {

                            
                            hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                            collision.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                            Vector2 difference = hit.transform.position - transform.position;
                            difference = difference.normalized * thrust;
                            hit.AddForce(difference, ForceMode2D.Impulse);

                        }
                    }



                }
                

            }
            
        }
    }
    
}
