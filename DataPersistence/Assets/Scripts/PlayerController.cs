using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] string nextLevel;
    [SerializeField] float speed;
    [SerializeField] int score;


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("persistentScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("persistentScore", score);
            SceneManager.LoadScene(nextLevel);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        score++;
    }
}
