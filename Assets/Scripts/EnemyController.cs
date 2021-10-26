using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    float rotationEnemy = 1.5f;
    [SerializeField] float speedEnemy = 3f;
    int routine;

    enum behaviour { A , B, C};
    [SerializeField] private behaviour chooseEnemy;

    void Start()
    {
        player = GameObject.Find("Player");
        routine = Random.Range(1, 3);
    }

    void Update()
    {
        switch(chooseEnemy)
        {
            case behaviour.A:
                LookAtPlayer();
                break;

            case behaviour.B:
                MoveTowards();
                break;
            case behaviour.C:
                if(routine==1)
                {
                    LookAtPlayer();
                }
                if(routine==2)
                {
                    MoveTowards();
                }
                break;
            default:
                Debug.Log("Enemigo no encontrado");
                break;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation,newRotation,rotationEnemy* Time.deltaTime);
    }

    private void MoveTowards()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
       
        if(!(Vector3.Distance(player.transform.position, transform.position)<=2.2f))
        {
            transform.position += speedEnemy * direction * Time.deltaTime;
            Quaternion newRotation = Quaternion.LookRotation(direction);
            transform.rotation = newRotation;
        }
    }


}
