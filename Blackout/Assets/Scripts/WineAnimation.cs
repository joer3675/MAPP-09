using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isPressed;

    
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
        
        
        /*if (isPressed == true)
        {
            animator.SetTrigger("Animate");
        } */
  

    }

    public void ButtonPressed()
    {
        GetComponent<Animation>().Play("WineAnimation");
     }

}
