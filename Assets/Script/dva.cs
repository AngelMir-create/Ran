using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class dva : MonoBehaviour
{
    public float forwardSpeed = 6f;          
    public float laneSwitchSpeed = 8f;      
    public float laneDistance = 2f;        

    private CharacterController controller;
    private int currentLaneIndex = 1;       
    private float targetXPosition;           
    private bool isChangingLane = false;
    private float jumpHeigth = 5f;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGrounded = false;
    public GameObject lossMenu;
    private bool isGameOver;
    private AudioSource audioSource;
    public AudioClip Sound_01;

   



   

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
            Debug.LogError("На объекте нет CharacterController!");

       
        targetXPosition = (currentLaneIndex - 1) * laneDistance;
        transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
       
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.deltaTime;
        controller.Move(forwardMove);

        
        if (isChangingLane)
        {
            float currentX = transform.position.x;
            float smoothX = Mathf.MoveTowards(currentX, targetXPosition, laneSwitchSpeed * Time.deltaTime);
            Vector3 newPos = transform.position;
            newPos.x = smoothX;
            transform.position = newPos;

            if (Mathf.Abs(smoothX - targetXPosition) < 0.05f)
            {
                isChangingLane = false;
                transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
            }
        }
    }
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            velocity.y = jumpHeigth;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (!isChangingLane && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-1);
        }
        else if (!isChangingLane && Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(+1);
        }
    }
    void ChangeLane(int direction)
    {
        int newLane = currentLaneIndex + direction;
        newLane = Mathf.Clamp(newLane, 0, 2);

        if (newLane != currentLaneIndex)
        {
            currentLaneIndex = newLane;
            targetXPosition = (currentLaneIndex - 1) * laneDistance;
            isChangingLane = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
              HandleGameOver();
              audioSource.PlayOneShot(Sound_01, 1f);

        }
    }

    private void HandleGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (lossMenu != null)
        {
            lossMenu.SetActive(true);
        }
        else
        {
            Debug.LogError("Не назначена панель lossMenu в инспекторе!");
        }
    }
    
}