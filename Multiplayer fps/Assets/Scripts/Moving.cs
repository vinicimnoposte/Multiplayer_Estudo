using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moving : NetworkBehaviour
{
    public float ms = 5f;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }
    [Client(RequireOwnership = true)]
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 offset = new Vector3(horizontal, Physics.gravity.y, vertical) * (ms * Time.deltaTime);

        _characterController.Move(offset);
    }
}
