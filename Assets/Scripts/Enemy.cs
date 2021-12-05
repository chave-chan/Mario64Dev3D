using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum ENEMY_STATE
    {
        PATROL, CHASING, DIE
    }

    [SerializeField] private MeshAgentTarget _meshAgentTarget;
    private ENEMY_STATE currentState = ENEMY_STATE.PATROL;
    private bool playerInRoom = true;
    private bool playerHeard = false;
    private float currentHitTime = 0;
    
    void startPatrol()
    {
        currentState = ENEMY_STATE.PATROL;
        //TODO: init patrol state
    }

    void startChasing()
    {
        currentState = ENEMY_STATE.CHASING;
        //TODO: init chasing state
    }

    void startDie()
    {
        currentState = ENEMY_STATE.DIE;
    }

    void updatePatrol()
    {
        if(playerHeard)
            startChasing();
        _meshAgentTarget.Patrol();
    }

    void updateChasing()
    {
        if(!playerHeard)
            startPatrol();
        _meshAgentTarget.Chase();
    }

    void updateDie()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        switch (currentState)
        {
            case ENEMY_STATE.PATROL:
                updatePatrol();
                break;
            case ENEMY_STATE.CHASING:
                updateChasing();
                break;
            case ENEMY_STATE.DIE:
                updateDie();
                break;
        }
    }

    public void SetPlayerHeard(bool playerHeard)
    {
        this.playerHeard = playerHeard;
    }

    public void SetEnemyDie()
    {
        startDie();
    }
}
