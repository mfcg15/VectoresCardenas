using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedPlayer = 4.5f;
    float axisHorizontal, axisVertical, gyration;

    void Start()
    {
        
    }

    void Update()
    {
        MoveRotation();
    }

    private void MoveRotation()
    {
        gyration += Input.GetAxisRaw("Horizontal");
        axisHorizontal = Input.GetAxisRaw("Horizontal");
        axisVertical = Input.GetAxisRaw("Vertical");
        Quaternion angle = Quaternion.Euler(0, gyration, 0);

        transform.localRotation = angle;
        transform.Translate(speedPlayer * Time.deltaTime * new Vector3(axisHorizontal, 0, axisVertical));
    }
}
