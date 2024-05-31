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
   

    int playerA_points = 0;
    int playerB_points = 0;
    public float speed = 10;
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(power);
        }else if (hit.gameObject.name == "PowerUp4")
        {
            mainCam.fieldOfView = 100;
            Destroy(hit.gameObject);
        }
    }

    void OnTriggerEnter(Collider touch)
    {
        if (touch.gameObject.name == "PowerUp2")
        {
            mainCam.fieldOfView = 60;
            Destroy(touch.gameObject);
        }else if (touch.gameObject.name == "PowerUp3")
        {
            mainCam.fieldOfView = 50;
            Destroy(touch.gameObject);
        }
    }
}
