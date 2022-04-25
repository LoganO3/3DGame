using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreindlyNPCNavigation : MonoBehaviour
{
    [SerializeField] GameObject pathingParent;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] int waypointIndex = 0;
    int waitTime = 0;
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GetWaypoints();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pathingParent)
        {
            m_Animator.SetBool("Waiting", true);
        }
        else if (waitTime >= 3)
        {
            m_Animator.SetBool("Waiting", false);
            waitTime = 0;
        }
        if (m_Animator.GetBool("Waiting") == false)
        { 
            Move();
        }
    }

    public List<Transform> GetWaypoints()
    {
        if (!pathingParent)
        {
            var waypoints = new List<Transform>();
            return waypoints;
        }
        else
        {
            var waypoints = new List<Transform>();
            foreach (Transform child in pathingParent.transform)
            {
                waypoints.Add(child);
            }
            return waypoints;
        }
    }

    private void Move()
    {
        if(!pathingParent) { return; }
        else if (waypointIndex > waypoints.Count - 1)
        {
            waypointIndex = 0;
        }
        Vector3 Distance = gameObject.transform.position - waypoints[waypointIndex].transform.position;
        Vector3 DistanceNormalized = Distance.normalized;
        Vector3 targetPosition = waypoints[waypointIndex].transform.position + DistanceNormalized;
        GetComponent<NavMeshAgent>().SetDestination(targetPosition);
        if (Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position) < 1.0f)
        {
            m_Animator.SetBool("Waiting", true);
            waypointIndex = waypointIndex + 1;
        }
    }

    private void StartMove()
    {
        waitTime++;
    }
}