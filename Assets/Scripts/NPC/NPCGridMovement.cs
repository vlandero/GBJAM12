using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCGridMovement : MonoBehaviour
{
    [SerializeField] List<Transform> _targets;
    NPCPathfinding _pathfinding;
    private NPC _npc;
    int _iterator = 0;
    NavMeshAgent _agent;

    public Vector2 secondsToStopInterval;
    private bool isStopping = false;

    private int numberOfTargets = 0;
    private bool _AfterPause = false;
    void Start()
    {
        _pathfinding = GetComponent<NPCPathfinding>();
        _npc = GetComponent<NPC>();

        numberOfTargets = _targets.Count;
    }

    void Update()
    {
        if (PauseManager.Instance.isPaused || _npc.possessed)
        {
            _pathfinding.StopAllCoroutines();
            _AfterPause = true;
        }
        else if (_AfterPause)
        {
            _AfterPause = false;
            if (Vector2.Distance(_targets[_iterator].position, transform.position) < 0.5)
            {
                _pathfinding._end = null;
            }
            else
            {
                _pathfinding.CalculatePath(_targets[_iterator]);
            }
        }
        if (numberOfTargets > 0 && !isStopping && _pathfinding._end == null) {
            StartCoroutine(StopForRandomTime());
        }
    }

    public void SetRandomDestination()
    { 
        int newIterator = Random.Range(0, numberOfTargets);

        while(newIterator == _iterator)
            newIterator = Random.Range(0, numberOfTargets);

        _iterator = newIterator;

    }

    IEnumerator StopForRandomTime()
    {
        isStopping = true;

        float stopTime = Random.Range(secondsToStopInterval.x, secondsToStopInterval.y);
        yield return new WaitForSeconds(stopTime);

        SetRandomDestination();
        isStopping = false;
        _pathfinding.CalculatePath(_targets[_iterator]);
    }
}
