using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private Animator unityAnimatior;

    private void Awake()
    {
        targetPosition = transform.position;
    }


    private void Update()
    {

       
        float stoppingDistance = .1f;

        if (Vector3.Distance(transform.position,targetPosition)>stoppingDistance)
        {
            float moveSpeed = 2f;
            Vector3 moveDirection=(targetPosition-transform.position).normalized;
            transform.position += moveDirection* moveSpeed*Time.deltaTime;
            float rotateSpeed = 5f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed*Time.deltaTime);
            unityAnimatior.SetBool("IsWalking", true);


        }
        else
        {
            unityAnimatior.SetBool("IsWalking", false);
        }

       
    }



    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        
    }
}






