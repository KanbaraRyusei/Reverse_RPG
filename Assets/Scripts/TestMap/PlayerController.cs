using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class PlayerController : MonoBehaviour
{

    private float activeMoveSpeed;

    [SerializeField, Tooltip("移動スピード")]
    private int movespeed;

    [SerializeField]
    private Animator playerAnime;

    public Rigidbody2D rb;

    [SerializeField]
    string messsage = "";

    public bool canActivater;

    Flowchart flowchart;




    // Start is called before the first frame update



    void Start()
    {

        activeMoveSpeed = movespeed;
        flowchart = GetComponent<Flowchart>();





    }

    // Update is called once per frame


    void Update()
    {
        {
            if (Input.GetMouseButtonDown(1) && canActivater)
            {
                StartCoroutine(Talk());


            }


            IEnumerator Talk()
            {



                flowchart.SendFungusMessage(messsage);
                yield return new WaitUntil(() => flowchart.GetExecutingBlocks().Count == 0);
                ShopManager.Instance.ShopOpen();


            }
        }




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
  private void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "ShopNPC")
        {
            canActivater = true;

        }
        else if(other.gameObject.tag == "Enemy")
        {
                Debug.Log("シーン移行_Battle");
            
        }
      


    }
    private void OnCollisionExit2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "ShopNPC")

        {
            canActivater = false;



        }
    }
}