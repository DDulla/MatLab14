using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity = 1;
    [SerializeField] private float jumpForce = 1;

    private Vector2 direction;
    [SerializeField]private bool OnJump;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(direction.x * velocity, rb.linearVelocity.y, rb.linearVelocity.z);
        rb.linearVelocity = dir;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            OnJump = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meta"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        OnJump = false;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpPlayer();
        }
    }
    private void OnJumpPlayer()
    {
        if (OnJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}