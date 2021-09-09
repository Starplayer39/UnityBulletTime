using UnityEngine;

public class SampleInputManager : MonoBehaviour
{
    public static SampleInputManager Instance;

    public bool isLeftMouseButtonDown { get; private set; }

    public bool isRightMouseButtonDown { get; private set; }

    public float mouseX { get; private set; }

    public float mouseY { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        isLeftMouseButtonDown = Input.GetMouseButtonDown(0);
        isRightMouseButtonDown = Input.GetMouseButtonDown(1);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
}
