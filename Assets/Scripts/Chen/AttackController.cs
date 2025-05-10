using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    public static AttackController Instance;
    public int currentAttackType = 8;
    public bool hasCenter = false;
    public Vector2Int center = new Vector2Int(-10, -19);

    private void Awake()
    {
        Instance = this;
    }

    public void ExecuteAttack()
    {
        //Execute and calculate Damage;
       

    }

    public bool IsTileAttackPattern(Vector2Int checkPos)
    {

        Vector2Int offset = checkPos - center;

        switch (currentAttackType)
        {
            case 1:
                // Attack 1: only center
                return offset == Vector2Int.zero;

            case 2:
                // Attack 2: center + top adjacent
                return (offset == Vector2Int.zero || offset == Vector2Int.down);

            case 3:
                // Attack 3: center, left adjacent, and right adjacent
                return (offset.y == 0 && Mathf.Abs(offset.x) == 1) || offset == Vector2Int.zero;

            case 4:
                // Attack 4: x without center / four corners
                return (Mathf.Abs(offset.x) == 1 && Mathf.Abs(offset.y) == 1);

            case 5:
                // Attack 5: cross shape (like a plus sign)
                return (offset.x == 0 || offset.y == 0) && (Mathf.Abs(offset.x) <= 1 && (Mathf.Abs(offset.y)) <= 1);

            case 6:
                // Attack 6: Left and right columns (relative to center)
                return Mathf.Abs(offset.x) == 1 && Mathf.Abs(offset.y) <= 1;

            case 7:
                // Attack 7: "エ" shape (or horizontal fat I)
                return offset == Vector2Int.zero || (Mathf.Abs(offset.y) == 1 && (Mathf.Abs(offset.x) <= 1));

            case 8:
                // Attack 8: Everything but the center
                return (offset.x != 0 || offset.y != 0) && (Mathf.Abs(offset.x) <= 1 && (Mathf.Abs(offset.y)) <= 1);

            case 9:
                // Attack 9: all squares
                return (Mathf.Abs(offset.x) <= 1 && (Mathf.Abs(offset.y)) <= 1);

            default:
                return false;
        }


    }


}
