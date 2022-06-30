using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private float activeMoveSpeed;
    [SerializeField]
    [Header("マップシーンの名前")]
    string _mapSceneName;

    [SerializeField, Tooltip("移動スピード")]
    private int movespeed;

    [SerializeField]
    private Animator playerAnime;




    public Rigidbody2D rb;

   
    // Start is called before the first frame update


  
    void Start()
    {

        activeMoveSpeed = movespeed;





    }

    // Update is called once per frame


    void Update()
    {
        //ノックバック




        //移動
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * activeMoveSpeed;


        if (rb.velocity != Vector2.zero)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    playerAnime.SetFloat("X", 1f);
                    playerAnime.SetFloat("Y", 0);


                }
                else
                {
                    playerAnime.SetFloat("X", -1f);
                    playerAnime.SetFloat("Y", 0);


                }

            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                playerAnime.SetFloat("X", 0);
                playerAnime.SetFloat("Y", 1);


            }
            else
            {
                playerAnime.SetFloat("X", 0);
                playerAnime.SetFloat("Y", -1);


            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneLoder.LoadScene(_mapSceneName);
        }
    }
}