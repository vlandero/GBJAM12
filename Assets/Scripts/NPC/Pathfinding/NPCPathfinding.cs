using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPathfinding : MonoBehaviour
{
    private Pathfinding _pathfinding;

    [HideInInspector] public float _speed = 1f;

    private Queue<Tile> _path;

    private Tile _start;
    [HideInInspector] public Tile _end;
    private Rigidbody2D _rigidbody;

    private NPC _npc;

    private void Start()
    {
        _pathfinding = FindAnyObjectByType<Pathfinding>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _npc = GetComponent<NPC>();
        _speed = _npc.movementSpeed;
    }
    public void CalculatePath(Transform target)
    {
        _start = _pathfinding.GetStart(transform);
        _end = _pathfinding.GetEnd(target);
        Queue<Tile> path = _pathfinding.FindPath(_start, _end);
        //_start._Text = "Start";
        //_end._Text = "End";
        // Debug.Log("a fost calculat path-ul");
        SetPath(path);
    }
    private void SetPath(Queue<Tile> path)
    {
        _path = path;
        StopAllCoroutines();
        if (path != null)
        {
            StartCoroutine(MoveAlongPath(path));
        }
        else
        {
            _end = null;
        }
    }

    private IEnumerator MoveAlongPath(Queue<Tile> path)
    {
        yield return new WaitForSeconds(0.2f);
        Vector3 offset = new Vector3(0f, 0.5f, 0f);
        Vector3 lastPosition = transform.position;
        // Debug.Log("Incepe coroutina");
        while (path.Count > 0)
        {
            Tile nextTile = path.Dequeue();
            Vector3 nextPosition = nextTile.transform.position + offset;
            
            // Debug.Log(nextTile);
            _rigidbody.velocity = (nextPosition - lastPosition) * _speed;

            yield return new WaitUntil(() => Vector2.Distance(transform.position, nextPosition) <= 0.2);
            _rigidbody.velocity = Vector2.zero;
            lastPosition = nextTile.transform.position + offset;
        }
        _end = null;
    }

}
