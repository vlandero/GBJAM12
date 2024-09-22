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
    public Vector2 secondsToStopInterval;
    private bool isStopping = false;
    private bool finishedScareAnim = false;

    private int numberOfTargets = 0;
    private bool _AfterPause = false;
    private bool _isHeadingTowardsExit = false;
    Rigidbody2D _rigidbody;
    void Start()
    {
        _pathfinding = GetComponent<NPCPathfinding>();
        _npc = GetComponent<NPC>();
        _rigidbody = GetComponent<Rigidbody2D>();

        numberOfTargets = _targets.Count;
    }

    void Update()
    {
        if (_npc.scared && !_isHeadingTowardsExit)
        {
            _rigidbody.velocity = Vector2.zero;
            StopAllCoroutines();
            isStopping = true;
            _pathfinding.StopAllCoroutines();
            _isHeadingTowardsExit = true;
            _npc.scareSign.SetActive(true);
            StartCoroutine(ContinueAfterScare());
            return;
        }
        if (PauseManager.Instance.isPaused || _npc.possessed)
        {
            _rigidbody.velocity = Vector2.zero;
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
                if (_isHeadingTowardsExit)
                {
                    Debug.Log(GameManager.Instance.mapExit);
                    _pathfinding.CalculatePath(GameManager.Instance.mapExit);
                }
                else _pathfinding.CalculatePath(_targets[_iterator]);
            }
        }
        if(_pathfinding._end == null && !isStopping)
        {
            if (_isHeadingTowardsExit && finishedScareAnim) Destroy(gameObject, 2f);
            else if (numberOfTargets > 0)
            {
                StartCoroutine(StopForRandomTime());
            }
        }
    }

    private IEnumerator ContinueAfterScare()
    {
        yield return new WaitForSeconds(1);
        _pathfinding._speed *= 1.5f;
        _pathfinding.CalculatePath(GameManager.Instance.mapExit);
        isStopping = false;
        finishedScareAnim = true;
    }

    public void SetRandomDestination()
    {
        int newIterator = Random.Range(0, numberOfTargets);
        //int newIterator = Mathf.Abs(_iterator - 2);

        while (newIterator == _iterator) newIterator = Random.Range(0, numberOfTargets);

        //Debug.Log("old: " + _iterator);
        _iterator = newIterator;
        //Debug.Log("new: " + _iterator);

    }

    IEnumerator StopForRandomTime()
    {
        isStopping = true;

        float stopTime = Random.Range(secondsToStopInterval.x, secondsToStopInterval.y);
        yield return new WaitForSeconds(stopTime);
        if (!_isHeadingTowardsExit)
        {
            SetRandomDestination();
            isStopping = false;
            _pathfinding.CalculatePath(_targets[_iterator]);
        }
        
    }
}
