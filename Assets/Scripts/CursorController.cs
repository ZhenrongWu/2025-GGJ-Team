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
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }
}