using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCombatControls : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer,attackRadius,AttackDamage;
    [SerializeField]
    private Transform attackhitBox;
    [SerializeField]
    private LayerMask whatisDamege;
    private bool gotInput,isAttacking, isFristAttack;
    private float lastInputTime=Mathf.NegativeInfinity;
    private Animator anima;
    Vector2 movement;
    private float x, y;
    void Start()
    {
        
        
        anima = GetComponent<Animator>();
        
        anima.SetBool("CanAttack", combatEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCombatInput();
        checkAttack();
    }

    private void CheckCombatInput() { 
    if(Input.GetMouseButton(0))
        {

            //Attecp atttack
            gotInput = true;
            lastInputTime=Time.time;

        }

    }

    private void  checkAttack() {
        if (gotInput) { 
            if(!isAttacking) { 
                gotInput=false;
                isAttacking = true;
                isFristAttack=!isFristAttack;
                //anima.SetFloat("Horizontal", movement.x);
                x=anima.GetFloat("Horizontal");
                y = anima.GetFloat("Vertical");
                Debug.Log(x);
                Debug.Log(y);
                anima.SetBool("Attack1", true);
                anima.SetBool("FirstAttack", false) ;
                anima.SetBool("IsAttack", true);
            }
        }

        if(Time.time>=lastInputTime+inputTimer)
        {
            //Wait for new Input
            gotInput = false;
        }
    }
    private void CheckAttackHitBox() {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackhitBox.position, attackRadius, whatisDamege);
        foreach(Collider2D item in detectedObjects)
        {
            item.transform.parent.SendMessage("Damage", AttackDamage);
        }
    }
    private void FixedUpdate()
    {
        isAttacking = false;
        anima.SetBool("isAttacking", isAttacking);
        anima.SetBool("Attack1", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackhitBox.position, attackRadius);
    }
}
