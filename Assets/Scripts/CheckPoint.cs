using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform initPos;
    [SerializeField] private int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out MarioPlayerController mario))
        {
            mario.setCheckPoint(this);
        }
    }

    public Transform getCheckPointTransform()
    {
        return this.initPos;
    }

    public int getIndex()
    {
        return this.index;
    }
}
