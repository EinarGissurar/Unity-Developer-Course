using UnityEngine;

public class Ball: MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float vX = 2f; 
    [SerializeField] float vY = 10f;

    [SerializeField] AudioClip[] ballSound;

    private Vector2 paddleToBallV;

    private bool start = false;
    private AudioClip click;
    private AudioSource ballAudio;

    // Use this for initialization
    void Start () {
        ballAudio = GetComponent<AudioSource>();
        paddleToBallV = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!start)
        {
            handleStart();
        }
    }

    private void handleStart()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallV;
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(vX, vY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (start) {
            click = ballSound[Random.Range(0, ballSound.Length)];
            ballAudio.PlayOneShot(click);
        }
    }
}
