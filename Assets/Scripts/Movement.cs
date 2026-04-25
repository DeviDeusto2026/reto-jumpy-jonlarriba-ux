using UnityEditor.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canJump = true;
    public bool rising = false;

    public float posY = 0;
    public int speed = 30;
    public int jumpForce = 300;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Jumping();
    }


    private void Moving()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * jumpForce);
            rising = true;
            posY = gameObject.transform.position.y;
        }
        checkMaxHeight();

        if(rising == true)
        {
            rb.excludeLayers = 64; // This must be written in binary, because each one means an activation of a different layer.
            Debug.Log(LayerMask.NameToLayer("Ground"));
        }
        else
        {
            rb.excludeLayers = 0; //This means nothing
        }

    }

    /**
     * Checks when the max height was reached after a jump. When so, the status of rising is deactivated.
     **/ 
    private void checkMaxHeight()
    {
        if (posY + jumpForce/112.5 <= this.transform.position.y)
        {
            rising = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = false;
        }

    }
}