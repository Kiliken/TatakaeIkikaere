using System.Linq.Expressions;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Vector2Int gridPosition;

    void Start()
    {
        gridPosition = new Vector2Int(1, 1); // Starting grid tile
    }

    public void MoveTo(Vector3 worldTarget, Vector2Int newGridPos)
    {
        if (IsValidPosition(gridPosition, newGridPos))
        {
            transform.position = new Vector3(worldTarget.x, worldTarget.y, transform.position.z);

            gridPosition = newGridPos;
        }
    }


    private bool IsValidPosition(Vector2Int prevPos, Vector2Int newPos)
    {
        return Vector2Int.Distance(prevPos, newPos) <= 1f;
    }
}
