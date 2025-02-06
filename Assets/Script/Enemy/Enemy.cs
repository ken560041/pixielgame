using System.Collections;
using System.Collections.Generic;
using Aether;
using Unity.VisualScripting;
using UnityEngine;


public enum StateEnemy
{
    idle,
    walk,
    attack,
    dead,
    stagger
}
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("State Machine")]
    public StateEnemy currentState;
    [Header("Enemy Stats")]
    public FloatValue maxHealth;
    public float health;
    public string nameEnemy;
    public float baseAttack;
    public float moveSpeed;
    public Vector2 homePos;
    [Header("Attack Slash")]
    public GameObject slashFX;

    private void Awake(){
        health = maxHealth.initValue;
        homePos = transform.position;
    }

    private void OnEnable()
    {
        transform.position = homePos;
        health = maxHealth.initValue;
        currentState = StateEnemy.idle;
    }

    public void Knock(Rigidbody2D rb, float knockTime,float damage)
    {
        StartCoroutine(KnockCo(rb, knockTime));
        TakeDamage(damage);
    }

    

    private void TakeDamage(float damage) { 
    
    
        if (health > 0) {

            SlashFX();
        }
        health -= damage;
        if (health <= 0) { 
        
        this.gameObject.SetActive(false);
        }
    }
    private void SlashFX()
    {

        if (slashFX != null)
        {
            GameObject fx = Instantiate(slashFX, transform.position, Quaternion.identity);
            Destroy(fx, 0.25f);
        }
    }
    private IEnumerator KnockCo(Rigidbody2D rb, float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = StateEnemy.idle;
            rb.velocity = Vector2.zero;
        }

    }
    
}
