using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject brumeObject;
    void Start()
    {
        var animator = brumeObject.GetComponent<Animator>();
        animator.SetBool("isStarted", true);
    }
}
