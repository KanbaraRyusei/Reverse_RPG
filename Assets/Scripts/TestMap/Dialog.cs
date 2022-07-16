using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class Dialog : MonoBehaviour
{

    [SerializeField]
    string messsage = "";

    public bool canActivater;

    


   
    Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
       
        flowchart = GetComponent<Flowchart>();
        


    } 
    void Update()
        {
            if (Input.GetMouseButtonDown(1)&& canActivater)
            {
                StartCoroutine(Talk());

           
            }


            IEnumerator Talk()
        {

          

            flowchart.SendFungusMessage(messsage);
            yield return new WaitUntil(() => flowchart.GetExecutingBlocks().Count == 0);
            

          
        }
        }
    private void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canActivater = true;

           
        }
        else
        {
           
        }

    }
    private void OnCollisionExit2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "Player")

        {
            canActivater = false;

          

        }  //gameObject.GetComponent<PlayerController>().enabled = false; //gameObject.GetComponent<PlayerController>().enabled = true;


       

        // Update is called once per frame
      

    }
}

