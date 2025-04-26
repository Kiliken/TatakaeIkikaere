using UnityEngine;

public class GridButton : MonoBehaviour
{
    public Vector2Int gridPosition;

    public void OnClick()
    {
        Vector3 worldPos = transform.position;
        worldPos.z = 0f;

        FindObjectOfType<Ghost>().MoveTo(worldPos, gridPosition);
    }
}
