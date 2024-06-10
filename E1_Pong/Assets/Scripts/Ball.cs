using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour

{
    public TMP_Text pointsLeft;
    public TMP_Text pointsRignt;
    public Camera mainCam;
    public GameObject power;
    public GameObject power2; 
    public GameObject power3;
    public GameObject power4;
    public GameObject background1;
    public GameObject prefab;
    public GameObject prefab2;


    int playerA_points = 0;
    int playerB_points = 0;
    public float speed = 10;
    // Start is called before the first frame update
    public bool isPaused = false;
    void Start()
    {
        if ((playerA_points >= 3 ) || (playerB_points >= 3 ) )
        {
            SceneManager.LoadScene(2);
        }
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector2(speed*x, speed*y);
        pointsLeft.SetText(playerA_points.ToString());
        pointsRignt.SetText(playerB_points.ToString());
        StartCoroutine(PowerCome(2, power));
        StartCoroutine(PowerCome(4, power2));
        StartCoroutine(PowerCome(6, power3));
        StartCoroutine(PowerCome(8, power4));
        
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Pause();
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        GetComponent<AudioSource>().Play();
        if (hit.gameObject.name == "Left")
        {
            transform.position = new Vector3(1, 5, 0);
            playerB_points++;
            Start();
        } else if (hit.gameObject.name == "Right")
        {
            transform.position = new Vector3(1, 5, 0);
            playerA_points++;
            Start();
        }else if (hit.gameObject.name == "PowerUp")
        {
            mainCam.fieldOfView = 147;
            power.SetActive(false);
            background1.SetActive(false);
            Instantiate(prefab, new Vector3(-16, 4, 0), Quaternion.identity);
            Debug.Log("I was here 2!");
            StartCoroutine(PowerEnd(5));
        }else if (hit.gameObject.name == "PowerUp4")
        {
            mainCam.fieldOfView = 100;
            hit.gameObject.SetActive(false);
            background1.SetActive(false);
            Instantiate(prefab2, new Vector4(-1, 7, 0), Quaternion.identity);
            Debug.Log("I was here 3!");
            StartCoroutine(PowerEnd(5));
            
        }
    }

    void OnTriggerEnter(Collider touch)
    {
        if (touch.gameObject.name == "PowerUp2")
        {
            mainCam.fieldOfView = 40;
            touch.gameObject.SetActive(false);
            StartCoroutine(PowerEnd(5));
        }
        else if (touch.gameObject.name == "PowerUp3")
        {
            mainCam.fieldOfView = 50;
            touch.gameObject.SetActive(false);
            StartCoroutine(PowerEnd(5));
        }
    }

    IEnumerator PowerEnd(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        background1.SetActive(true);
        mainCam.fieldOfView = 60;
    }

    IEnumerator PowerCome(float delayTime, GameObject powerUp)
    {
        yield return new WaitForSeconds(delayTime);
        powerUp.SetActive(true);
    }

    void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
