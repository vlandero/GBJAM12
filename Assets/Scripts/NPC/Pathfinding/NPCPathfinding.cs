using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPathfinding : MonoBehaviour
{
    private Pathfinding _pathfinding;

    public float _speed = 4f;

    private Queue<Tile> _path;

    private Tile _start;
    public Tile _end;

    private void Start()
    {
        _pathfinding = FindAnyObjectByType<Pathfinding>();
    }
    public void CalculatePath(Transform target)
    {
        _start = _pathfinding.GetStart(transform);
        _end = _pathfinding.GetEnd(target);
        Queue<Tile> path = _pathfinding.FindPath(_start, _end);
        _start._Text = "Start";
        _end._Text = "End";
        Debug.Log("a fost calculat apth-ul");
        SetPath(path);
    }
    private void SetPath(Queue<Tile> path)
    {
        _path = path;
        StopAllCoroutines();
        StartCoroutine(MoveAlongPath(path));
    }

    private IEnumerator MoveAlongPath(Queue<Tile> path)
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 offset = new Vector3(0f, 0.5f, 0f);
        Vector3 lastPosition = transform.position;
        Debug.Log("Incepe coroutina");
        while (path.Count > 0)
        {
            Tile nextTile = path.Dequeue();
            Vector3 nextPosition = nextTile.transform.position + offset;
            float lerpVal = 0;
            Debug.Log("Incepe miscarea");
            while (lerpVal < 1)
            {
                lerpVal += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(lastPosition, nextPosition, lerpVal);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.5f / _speed);
            lastPosition = nextTile.transform.position + offset;
        }
        _end = null;
    }

}
