using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private MapGenerator _mapGenerator;

    private void Awake()
    {
        _mapGenerator = FindObjectOfType<MapGenerator>();
    }
    Queue<Tile> AStar(Tile start, Tile goal)
    {
        Dictionary<Tile, Tile> NextTileToGoal = new Dictionary<Tile, Tile>();//Determines for each tile where you need to go to reach the goal. Key=Tile, Value=Direction to Goal
        Dictionary<Tile, int> costToReachTile = new Dictionary<Tile, int>();//Total Movement Cost to reach the tile

        PriorityQueue<Tile> frontier = new PriorityQueue<Tile>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            Tile curTile = frontier.Dequeue();
            if (curTile == start)
                break;

            foreach (Tile neighbor in _mapGenerator.Neighbors(curTile))
            {
                int newCost = costToReachTile[curTile] + neighbor._Cost;
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    if (neighbor._TileType != Tile.TileType.Wall)
                    {
                        costToReachTile[neighbor] = newCost;
                        int priority = newCost + Distance(neighbor, start);
                        frontier.Enqueue(neighbor, priority);
                        NextTileToGoal[neighbor] = curTile;
                        //neighbor._Text = costToReachTile[neighbor].ToString();
                    }
                }
            }
        }

        if (NextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }

        Queue<Tile> path = new Queue<Tile>();
        Tile pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        return path;
    }

    public Queue<Tile> FindPath(Tile start, Tile end)
    { 
        return AStar(start, end);
    }

    int Distance(Tile t1, Tile t2)
    {
        return Mathf.Abs(t1._X - t2._X) + Mathf.Abs(t1._Y - t2._Y);
    }

    public Tile GetStart(Transform location)
    {
        int gridX = Mathf.RoundToInt(location.position.x + 0.5f);
        int gridY = Mathf.RoundToInt(location.position.y - 0.5f);

        if (gridX >= 0 && gridX < _mapGenerator.sizeX && gridY >= 0 && gridY < _mapGenerator.sizeY)
        {
            return _mapGenerator.grid[gridX, gridY];
        }

        return null;
    }

    public Tile GetEnd(Transform location)
    {
        int gridX = Mathf.RoundToInt(location.position.x + 0.5f);
        int gridY = Mathf.RoundToInt(location.position.y - 0.5f);

        if (gridX >= 0 && gridX < _mapGenerator.sizeX && gridY >= 0 && gridY < _mapGenerator.sizeY)
        {
            return _mapGenerator.grid[gridX, gridY];
        }

        return null;
    }
}
