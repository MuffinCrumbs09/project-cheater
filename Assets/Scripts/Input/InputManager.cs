using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, Controls.IPlayerActions
{
    #region Public Values
    public static InputManager Instance;
    public Vector2 MovementValue { get; private set; }
    #endregion

    #region Private Values
    private Controls _controls;
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);

        Instance = this;
    }

    private void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        ToggleControls(true);
        ToggleCursor(false);
    }

    /// <summary>
    /// Toggle controls On/Off
    /// </summary>
    /// <param name="toggle">True -> Visible | False -> Hidden</param>
    public void ToggleControls(bool toggle)
    {
        if (toggle)
            _controls.Player.Enable();
        else
            _controls.Player.Disable();
    }

    /// <summary>
    /// Toggle Cursor
    /// </summary>
    /// <param name="toggle">True -> Visible | False -> Hidden</param>
    public void ToggleCursor(bool toggle)
    {
        Cursor.visible = toggle;

        if (toggle)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
}
