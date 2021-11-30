using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReset : MonoBehaviour
{
    [SerializeField] private Transform initPos;
    [SerializeField] private GameManager gameManager;

    public void OnEnable()
    {
        //gameManager.addRestartListener(this);
    }

    public void OnDisable()
    {
        
    }
}
