﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Waypoints
{
    public class NPCConnectedPatrol : MonoBehaviour
    {
        private Animator anim;

        [SerializeField]
        bool _patrolWaiting;

        [SerializeField]
        float _totalWaitTime = 3f;

        [SerializeField]
        float _switchProbability = 0.2f;

        [SerializeField]
        List<Waypoint> _patrolPoints;

        NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;

        public bool _travelling;
        bool _waiting;
        float _waitTimer;
        int _waypointsVisited;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Start()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>();

            if(_navMeshAgent == null)
            {
                Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
            }
            else
            {
                if (_currentWaypoint == null)
                {
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

                    if (allWaypoints.Length > 0)
                    {
                        while (_currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                            ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                            if(startingWaypoint != null)
                            {
                                _currentWaypoint = startingWaypoint;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Failed to find any waypoints for use in the scene");
                    }
                }
                SetDestination();
            }
        }

        public void Update()
        {
            if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
            {
                _travelling = false;
                _waypointsVisited++;

                if (_patrolWaiting)
                {
                    _waiting = true;
                    _waitTimer = 0f;
                }
                else
                {
                    SetDestination();
                }
            }

            if (_waiting)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;

                    SetDestination();
                }
            }
        }

        private void SetDestination()
        {
            if (_waypointsVisited > 0)
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.NextWaypoint(_previousWaypoint);
                _previousWaypoint = _currentWaypoint;
                _currentWaypoint = nextWaypoint;
            }

            Vector3 targetVector = _currentWaypoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }
}

