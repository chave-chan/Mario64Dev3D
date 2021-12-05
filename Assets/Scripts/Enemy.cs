using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum ENEMY_STATE
    {
        PATROL, CHASING, IDLE, ALERT, ATTACK, HIT, DIE
    }

    [SerializeField] private MeshAgentTarget _meshAgentTarget;
    private ENEMY_STATE currentState = ENEMY_STATE.PATROL;
    private bool playerInRoom = true;
    private bool playerHeard = false;
    private bool playerDetected = false;
    private bool playerInRange = false;
    [SerializeField] private float hitTime = 15f;
    private float currentHitTime = 0;
    
    void startPatrol()
    {
        currentState = ENEMY_STATE.PATROL;
        //TODO: init patrol state
    }

    void startAlert()
    {
        currentState = ENEMY_STATE.ALERT;
    }
    
    void startChasing()
    {
        currentState = ENEMY_STATE.CHASING;
        //TODO: init chasing state
    }

    void startAttack()
    {
        currentState = ENEMY_STATE.ATTACK;
    }

    void startHit()
    {
        currentState = ENEMY_STATE.HIT;
        currentHitTime = hitTime;
    }

    void startDie()
    {
        currentState = ENEMY_STATE.DIE;
    }

    void updatePatrol()
    {
        if(playerHeard)
            startAlert();
        _meshAgentTarget.Patrol();
    }

    void updateAlert()
    {
        if(playerDetected)
            startChasing();
        if(!playerHeard)
            startPatrol();
        _meshAgentTarget.Alert();
    }

    void updateChasing()
    {
        if(!playerDetected)
            startAlert();
        if(playerInRange)
            startAttack();
        _meshAgentTarget.Chase();
    }

    void updateAttack()
    {
        if(!playerInRange)
            startChasing();
        _meshAgentTarget.Attack();
    }

    void updateHit()
    {
        if (currentHitTime <= 0f)
        {
            startAlert();
        }
        else
        {
            hitTime -= Time.deltaTime;
        }
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
            case ENEMY_STATE.ALERT:
                updateAlert();
                break;
            case ENEMY_STATE.CHASING:
                updateChasing();
                break;
            case ENEMY_STATE.ATTACK:
                updateAttack();
                break;
            case ENEMY_STATE.HIT:
                updateHit();
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

    public void SetPlayerDetected(bool playerDetected)
    {
        this.playerDetected = playerDetected;
    }

    public void SetPlayerInRange(bool playerInRange)
    {
        this.playerInRange = playerInRange;
    }

    public void SetEnemyHit()
    {
        startHit();
    }

    public void SetEnemyDie()
    {
        startDie();
    }
}

/*
interface EnemyState
{
    void setState(Enemy enemy);
    void updateState(Enemy enemy);
}
*/
