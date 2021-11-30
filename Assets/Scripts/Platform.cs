using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Animation animation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MarioPlayerController>() != null)
        {
            //other.transform.parent = transform;
            animation.CrossFade("PlatformMovement");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<MarioPlayerController>() != null)
        {
            //other.transform.parent = null;
        }
    }
}
