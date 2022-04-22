using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreindlyNPCNavigation : MonoBehaviour
{
    [SerializeField] GameObject pathingParent;
    float waitTimer = .25f;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] int waypointIndex = 0;
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
        if (m_Animator.GetBool("Waiting") == false)
        { 
            Move();
        }
    }

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();
        foreach (Transform child in pathingParent.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    private void Move()
    {
        if (waypointIndex > waypoints.Count - 1)
        {
            waypointIndex = 0;
            Debug.Log("Reset");
        }
        Debug.Log(waypoints.Count - 1);
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
        m_Animator.SetBool("Waiting", false);
    }
}