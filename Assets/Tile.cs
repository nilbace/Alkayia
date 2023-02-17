using UnityEngine;

public class Tile : MonoBehaviour
{
    public int number;
    public int x;
    public int y;

    public void SetNumber(int number)
    {
        this.number = number;
        GetComponentInChildren<TextMesh>().text = number.ToString();
    }

    public void SetPosition(int x, int y) {
    this.x = x;
    this.y = y;
    transform.position = new Vector3(x * GameManager.instance.gridSize, y * GameManager.instance.gridSize, 0);
    }

    public bool IsEmpty() {
    return number == 0;
    }

    public bool CanMergeWith(Tile nextTile) {
    return number == nextTile.GetNumber();
    }

    public int GetNumber() {
    return number;
    }
}
