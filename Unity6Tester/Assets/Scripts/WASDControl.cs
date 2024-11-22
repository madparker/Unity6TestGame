using UnityEngine;
using UnityEngine.InputSystem;

public class WASDControl : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Vector2 moveInput;
    
    public float speed = 2;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = Time.deltaTime * speed * new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(move, Space.World);
    }
}