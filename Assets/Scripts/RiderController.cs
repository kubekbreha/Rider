using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class RiderController : MonoBehaviour {

    public Rigidbody2D rbRider;
    public float speed = 20.0f;
    public float rotationSpeed = 2.5f;

    private bool isMovingForward = false;
    private bool isMovingBackward= false;
    private bool isGrounded = false;

    public GameObject pauseButton;
    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update () {

        //moving backward
        if (Input.GetMouseButtonDown(0))
            isMovingBackward = true;
        if (Input.GetMouseButtonUp(0))
            isMovingBackward = false;

        //moving forward
        if(Input.GetMouseButtonDown(1))
            isMovingForward = true;
        if (Input.GetMouseButtonUp(1))
            isMovingForward = false;
        
	}

    private void FixedUpdate()
    {
        //moving backward
        if (isMovingBackward)
        {
            if (isGrounded)
                rbRider.AddForce(-1 * transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
            else
                rbRider.AddTorque(-1 * rotationSpeed * Time.fixedDeltaTime * 20.0f, ForceMode2D.Force);
        }

        //moving forward
        if(isMovingForward){
            if (isGrounded)
                rbRider.AddForce(transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
            else
                rbRider.AddTorque( rotationSpeed * Time.fixedDeltaTime * 20.0f, ForceMode2D.Force);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log(collision.collider.ToString());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public void RestartGame()
    {
    }

    public void PauseGame()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

}
