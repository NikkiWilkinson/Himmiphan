using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdletoWalk : MonoBehaviour
{

	public Animator animator;
	float InputX;
	public float InputY;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", move);
    }
}
