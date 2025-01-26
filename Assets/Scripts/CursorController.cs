using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D fan1, fan2;

    private void Start()
    {
        SetCursor(fan1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SetCursor(fan2);
        else if (Input.GetMouseButtonUp(0))
            SetCursor(fan1);
    }

    private void SetCursor(Texture2D texture2D)
    {
        Vector2 origin = new Vector2(texture2D.width / 2, texture2D.height / 2);
        Cursor.SetCursor(texture2D, origin, CursorMode.ForceSoftware);
    }
}