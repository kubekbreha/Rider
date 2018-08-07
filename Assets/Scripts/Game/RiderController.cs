using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*
 * Create by Kubo Brehuv 31.7.2018
 */
public class RiderController : MonoBehaviour {

    public GameObject rider;
    public float speed = 20.0f;
    public float rotationSpeed = 2.5f;

    private Rigidbody2D rbRider;
    private Vector3 originalRiderTrans;

    private bool isMovingForward = false;
    private bool isMovingBackward= false;
    private bool isGrounded = false;
    private bool cantMove = false;
    private float scoreMeters;

    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject failedPanel;
    public GameObject playBoard;

    public Text scoreText;

    private void Start()
    {
        pausePanel.SetActive(false);
        failedPanel.SetActive(false);
        originalRiderTrans = rider.transform.position;
        rbRider = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update () {

        scoreMeters = rider.transform.position.x - originalRiderTrans.x;

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

        if (CheckIfDead()) 
            PlayerFailed();

        scoreText.text = (int)scoreMeters + " m";
	}


    private void FixedUpdate()
    {
        if (!cantMove)
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
            if (isMovingForward)
            {
                if (isGrounded)
                    rbRider.AddForce(transform.right * speed * Time.fixedDeltaTime * 100.0f, ForceMode2D.Force);
                else
                    rbRider.AddTorque(rotationSpeed * Time.fixedDeltaTime * 20.0f, ForceMode2D.Force);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


    public void RoofOfCarCollisionEnter(CrashedCar crashedCar)
    {
        cantMove = true;
        Invoke("CarFallOnRoof", 4);
    } 

    public void RoofOfCarCollisionExit(CrashedCar crashedCar)
    {
        cantMove = false;
    } 

    private bool CheckIfDead(){
        if(rider.transform.position.y < -20)
            return true;
        return false;
    }


    public void RestartGame()
    {
        playBoard.GetComponent<PlayBoardGenerator>().ResetLinesToStartPosition();

        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        failedPanel.SetActive(false);
        rbRider.velocity = Vector3.zero;
        rbRider.rotation = 0f;
        rider.transform.position = originalRiderTrans;
        Time.timeScale = 1.0f;  
        cantMove = false;
    }


    public void PauseGame()
    {
        Time.timeScale = 0.0f;  
        cantMove = true;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }


    public void ResumeGame() 
    {
        Time.timeScale = 1.0f;  
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        cantMove = false;
    }

    public void PlayerFailed(){
        Time.timeScale = 0.0f;
        cantMove = true;
        pauseButton.SetActive(false);
        failedPanel.SetActive(true);
    }


    public void CarFallOnRoof()
    {
        if (cantMove)
        {
            Time.timeScale = 0.0f;
            pauseButton.SetActive(false);
            failedPanel.SetActive(true);
        }
    }

}