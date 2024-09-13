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
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _npc = GetComponent<NPC>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_npc.possessed && _agent.enabled)
        {
            _agent.enabled = false;
        }
        else if(!_npc.possessed && !_agent.enabled)
        {
            _agent.enabled = true;
        }

        if (_agent.enabled) {
            if (Vector2.Distance(transform.position, _targets[_iterator].position) < 0.2f)
            {
                if (_iterator == _targets.Count - 1)
                    _iterator = 0;
                else
                    _iterator++;
            }

            _agent.SetDestination(_targets[_iterator].position);
        }
    }
}
