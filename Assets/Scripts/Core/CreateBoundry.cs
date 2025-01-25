using UnityEngine;

public class CreateBoundry : MonoBehaviour
{
    public Transform boundryleftbottom;
    public Transform boundryrighttop;
    public Camera mainCamera;
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        boundryleftbottom.position = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        boundryrighttop.position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
}
