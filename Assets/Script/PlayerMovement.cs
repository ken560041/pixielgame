using System.Collections;
using System.Collections.Generic;
using Aether;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState { 
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float moveSpeed;
    public Vector3 movement;
    public Animator animator;
    bool isMoving,isAttack;
    public PlayerState currentState;
    public FloatValue playerhealth;
    public Signaler signhealth;
    public VectorValues startingPosition;

    public Inventory playerInventory;
    public SpriteRenderer itemSprite;

    public Signaler playerHit;


    public GameObject arrow; 
    void Start()
        {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Horizontal", 1);
        animator.SetFloat("Vertical", 0);
        transform.position = startingPosition.initialValues;

    }

    // Update is called once per frame
    private void Awake()
    {
        animator = GetComponent<Animator>();
        

    }
    void Update()
    {

        if (currentState == PlayerState.interact) {

            return;
        }

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(movement.x);


        if (Input.GetMouseButtonDown(0) && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());

        }
        else if (Input.GetButtonDown("Arrow") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger) {
            StartCoroutine(ArrowAttackCo());
        
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            MoveCharacter();
        }
            
    }

    
    void MoveCharacter() {
        if (movement != Vector3.zero)
        {

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            //animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetBool("isMoving",true);
            Move();
        }
        else
        {

            animator.SetBool("isMoving", false);
        }
        
    }

    void Move()
    {
        movement.Normalize();
        rb.MovePosition(transform.position+movement*moveSpeed*Time.deltaTime);
    }
    private IEnumerator AttackCo()
    {

        animator.SetBool("IsAttack", true);
        currentState = PlayerState.attack;
        yield return null;
        
        yield return new WaitForSeconds(.25f);

        animator.SetBool("IsAttack", false);
        if (currentState != PlayerState.interact) { 
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator ArrowAttackCo()
    {

        /* animator.SetBool("IsAttack", true);*/
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        yield return new WaitForSeconds(.25f);

        /*animator.SetBool("IsAttack", false);*/
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void MakeArrow() {
        Vector2 temp = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        ArrowPlayer arrowPlayer = Instantiate(arrow, transform.position, Quaternion.identity).GetComponent<ArrowPlayer>();
        arrowPlayer.SetUp(temp, ChooseArrowDirection());
    }
    public Vector3 ChooseArrowDirection() {
        float temp = Mathf.Atan2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        return new Vector3(0, 0, temp);
    }
    public void RaiseItem() {

        if (playerInventory.currentItem != null)
        {

            if (currentState != PlayerState.interact)
            {

                animator.SetBool("Item", true);
                currentState = PlayerState.interact;
                
                itemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {

                animator.SetBool("Item", false);
                currentState = PlayerState.idle;
                itemSprite.sprite = null;
                playerInventory.currentItem = null;

            }
        }
    }
    
    public void Knock(float knockTime, float damage)
    {
        playerhealth.RuntimeValue -= damage;
        signhealth.Raise();
        if (playerhealth.RuntimeValue > 0) {
            
            StartCoroutine(KnockCo(knockTime));

        }
        else
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("MenuGame");

        }
        
    }

    private IEnumerator KnockCo( float knockTime)
    {
        playerHit.Raise();
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            
            currentState = PlayerState.idle;
            rb.velocity=Vector2.zero;
        }

    }

    

}

