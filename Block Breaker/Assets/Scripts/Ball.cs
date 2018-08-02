using UnityEngine;

public class Ball: MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float speed = 100f;
    [SerializeField] float vX = 0.1f; 
    [SerializeField] float vY = 0.5f;
    [Range(0.05f, 5f)]
    [SerializeField] float randomFactor;
    [SerializeField] AudioClip[] ballSound;

    private bool start = false;
    private float deltaSpeed;
    private AudioClip click;
    private AudioSource ballAudio;
    private Rigidbody2D ballBody;
    private Vector2 paddlePos, paddleToBallVector, randomBallVector;

    // Use this for initialization
    void Start () {
        ballAudio = GetComponent<AudioSource>();
        ballBody = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        deltaSpeed = speed * Time.deltaTime;
        if (!start)
        {
            handleStart();
        }
        else {
            ballBody.velocity = deltaSpeed * (ballBody.velocity.normalized);
        }
    }

    private void handleStart()
    {
        paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
            ballBody.velocity = new Vector2(vX, vY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (start) {
            randomBallVector = new Vector2(Random.Range(-randomFactor, randomFactor), Random.Range(-randomFactor, randomFactor));
            ballBody.velocity += randomBallVector;

            click = ballSound[Random.Range(0, ballSound.Length)];
            ballAudio.PlayOneShot(click);
        }
    }
}
