using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator animator;
    Ray ray;
    RaycastHit raycastHit;

    float x;
    float z;
    float velocitySpeed;

    CinemachineTransposer cinemachineTransposer;
    [SerializeField] CinemachineVirtualCamera playerCam;

    Vector3 pos;
    Vector3 currentPos;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        cinemachineTransposer = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currentPos = cinemachineTransposer.m_FollowOffset;
    }

    private void Update()
    {

        MoveCharacter();
        calculateVelcocityAndAnim();
        cameraMovement();
    }

    private void MoveCharacter()
    {


        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                navMeshAgent.destination = raycastHit.point;
            }
        }


    }

    private void calculateVelcocityAndAnim()
    {
        //calculate velocity speed
        x = navMeshAgent.velocity.x;
        z = navMeshAgent.velocity.z;

        velocitySpeed = x + z;

        if (velocitySpeed != 0)
        {
            animator.SetBool("sprinting", true);
        }
        else if (velocitySpeed == 0)
        {
            animator.SetBool("sprinting", false);
        }
    }

    private void cameraMovement()
    {
        // get mouse position 
        pos = Input.mousePosition;
        cinemachineTransposer.m_FollowOffset = currentPos;

        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                currentPos = pos / 200;
            }
        }
    }
}
