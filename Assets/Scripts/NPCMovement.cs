using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] List<Transform> _targets;
    private NPC _npc;
    int _iterator = 0;
    NavMeshAgent _agent;

    public Vector2 secondsToStopInterval;
    private bool isStopping = false;

    private int numberOfTargets = 0;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _npc = GetComponent<NPC>();

        numberOfTargets = _targets.Count;
    }

    void Update()
    {
        if (PauseManager.Instance.isPaused)
        {
            _agent.enabled = false;
        }
        else
        {
            _agent.enabled = true;
        }
        if (_npc.possessed && _agent.enabled)
        {
            _agent.enabled = false;
        }
        else if(!_npc.possessed && !_agent.enabled)
        {
            _agent.enabled = true;
        }

        if (_agent.enabled && numberOfTargets > 0 && !isStopping) {
            if (Vector2.Distance(transform.position, _targets[_iterator].position) < 0.2f)
            {
                StartCoroutine(StopForRandomTime());
            }
            else
            {
                _agent.SetDestination(_targets[_iterator].position);
            }
        }
    }

    public void SetRandomDestination()
    {
        _iterator = Random.Range(0, numberOfTargets);
    }

    IEnumerator StopForRandomTime()
    {
        isStopping = true;
        _agent.isStopped = true;

        float stopTime = Random.Range(secondsToStopInterval.x, secondsToStopInterval.y);
        yield return new WaitForSeconds(stopTime);

        SetRandomDestination();
        _agent.isStopped = false;
        isStopping = false;
    }
}
