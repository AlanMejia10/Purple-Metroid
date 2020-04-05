using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    float speed = 3.0f;
    float moveRange = 7.0f;
    [SerializeField] GameObject target;
    Animator animController;
    // Start is called before the first frame update
    void Start(){
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        animController.SetBool("isWalking", false);
        Vector2 distance = target.transform.position - this.transform.position;

        FlipCharacter(distance);     

        if(distance.magnitude < moveRange){
            this.transform.Translate(distance.normalized * speed * Time.deltaTime);
            animController.SetBool("isWalking", true);
        } 
    }

    private void FlipCharacter(Vector2 distance){
        float areFacingEachOther = Vector2.Dot(target.transform.right, distance);

        if (Mathf.Abs(areFacingEachOther) > 0)
            this.transform.localScale = new Vector2(-Mathf.Sign(areFacingEachOther), 1.0f);
    }
}
