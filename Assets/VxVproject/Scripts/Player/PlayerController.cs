using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float mouseSensitivity = 1f;
    #endregion

    #region References
    private Rigidbody rb;
    private Transform cameraTransform;
    #endregion

    #region InternalVariables
    private Vector3 movementVector = Vector3.zero;
    private float xRotation;
    private float yRotation;
    private Vector2 deltaMouse;
    #endregion

    #region Mono
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        Look();
    }

    private void LateUpdate() {
    }

    private void FixedUpdate() {
        Move();
    }
    #endregion

    #region InternalMethods
    // Move player in every four direction with WASD
    private void Move() {
        movementVector = transform.right * InputManager.PlayerMove.x + transform.forward * InputManager.PlayerMove.y;
        movementVector = movementVector.normalized * movementSpeed;
        rb.velocity = movementVector;
    }

    private void Look() {
        deltaMouse = InputManager.PlayerLook * mouseSensitivity;
        // Scale to match old input system.
        deltaMouse *= 0.5f;
        deltaMouse *= 0.1f;

        // up and down - rotate camera
        xRotation -= deltaMouse.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // left & right - rotate player
        yRotation += deltaMouse.x;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
    #endregion
}
