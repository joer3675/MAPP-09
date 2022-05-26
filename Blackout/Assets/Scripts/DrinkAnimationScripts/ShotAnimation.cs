using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    private void Update()
    {
        //animator.SetBool("IsPressed", isPressed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        /*if (Input.anyKeyDown)
        {
            isPressed = true;
            animator.SetTrigger("Animate");
            ButtonPressed();
        } */


    }

    public void ButtonPressed()
    {
       GetComponent<Animation>().Play("ShotAnimation");
    }
}
