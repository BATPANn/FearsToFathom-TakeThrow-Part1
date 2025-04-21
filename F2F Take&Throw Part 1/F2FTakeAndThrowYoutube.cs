using UnityEngine;
using UnityEngine.UI;

public class F2FTakeAndThrowYoutube : MonoBehaviour
{


    bool Caninteract = true;

    public Transform HeldPoint;

    [SerializeField] float ThrowForce = 10f;

    private GameObject HeldObject;
    private Rigidbody HeldRB;

    public Text InteractionText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Caninteract == true)
        {


            if(HeldObject == null)
            {


                Ray ray1 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit1;

                if(Physics.Raycast(ray1, out hit1, 5f))
                {


                    if (hit1.collider.CompareTag("Throwable"))
                    {


                        InteractionText.text = "Take";

                        if(Input.GetMouseButtonDown(0))
                        {



                            InteractionText.text = "";

                            // Pick up

                            HeldObject = hit1.collider.gameObject;
                            HeldRB = HeldObject.GetComponent<Rigidbody>();

                            HeldObject.transform.SetParent(HeldPoint);
                            HeldObject.transform.localPosition = Vector3.zero;
                            HeldObject.transform.localRotation = Quaternion.identity;

                            HeldRB.useGravity = false;
                            HeldRB.isKinematic = true;





                        }



                    }
                    else
                    {


                        InteractionText.text = "";


                    }




                }
                else
                {


                    InteractionText.text = "";


                }





            }
            else
            {



                if(Input.GetMouseButtonDown(1))
                {


                    // Drop
                    HeldObject.transform.SetParent(null);

                    HeldRB.useGravity = true;
                    HeldRB.isKinematic = false;

                    HeldObject = null;
                    HeldRB = null;



                }

                if (Input.GetMouseButtonDown(0))
                {


                    // Throw

                    HeldObject.transform.SetParent(null);

                    HeldRB.useGravity = true;
                    HeldRB.isKinematic = false;

                    HeldRB.AddForce(Camera.main.transform.forward * ThrowForce, ForceMode.Impulse);

                    HeldObject = null;
                    HeldRB = null;



                }





            }






        }



    }
}
