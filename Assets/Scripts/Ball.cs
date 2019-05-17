
using UnityEngine;

public class Ball : MonoBehaviour {

    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRighidbody2D;
    Level level;

    // Use this for initialization
    void Start ()
    {
        CountNumberOfBalls();

        paddleToBallVector = transform.position- paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRighidbody2D = GetComponent<Rigidbody2D>();
		
	}

    private void CountNumberOfBalls()
    {
        level = FindObjectOfType<Level>();
        if(tag == "BallNumber")
        {
            level.CountBalls();
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!hasStarted)
        { 
            LockBallToPaddle();
            LounchOnMouseClick();
        }
    }

    private void LounchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRighidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //need to fix problem when the ball block in horizontally
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(0f, randomFactor), 
            UnityEngine.Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRighidbody2D.velocity += velocityTweak;
        }
    }
}
