using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class BasicEnemyController : MonoBehaviour
    {
        // Start is called before the first frame update

        private enum State
        {
            Walking , 
            KnockBack,
            Dead
        }

        private State currentState;

        private void Update()
        {
            switch (currentState)
            {
                case State.Walking:
                    UpdateWalkingState(); break;
                case State.Dead:
                    UpdateDeadState(); break;
                case State.KnockBack:
                    UpdateKnockBackState(); break;
            }
        }







        //Walking State


        private void EnterWalkingState() { 
        
        }

        private void UpdateWalkingState() { }

        private void ExitWalkingState() { }



        //KnockState
        private void EnterKnockBackState()
        {

        }

        private void UpdateKnockBackState() { }

        private void ExitKnockBackState() { }



        //DeadState

        private void EnterDeadState()
        {

        }

        private void UpdateDeadState() { }

        private void ExitDeadState() { }

        private void SwitchState(State state)
        {
            switch(currentState)
            {
                case State.Walking:
                    ExitWalkingState(); break;
                case State.Dead:

                    ExitKnockBackState(); break;
                case State.KnockBack:
                    ExitKnockBackState(); break;
            }
            switch (state)
            {
                case State.Walking:
                    EnterWalkingState(); break;
                case State.Dead:

                    EnterKnockBackState(); break;
                case State.KnockBack:
                    EnterKnockBackState(); break;

            }
            currentState=state;
        }
    }
}
