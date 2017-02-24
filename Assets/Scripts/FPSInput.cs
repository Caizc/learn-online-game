using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public const float baseSpeed = 6.0f;
    public float speed = 6.0f;

    private CharacterController _charactorController;

    public float gravity = -9.8f;

    void Start()
    {
        _charactorController = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement = movement * Time.deltaTime;
        movement = this.transform.TransformDirection(movement);
        _charactorController.Move(movement);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
