using Mirror;
using UnityEngine;

namespace _Project.Scripts
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float _movementSpeed = 5f;

        private void Update()
        {
            if (!isLocalPlayer) return;
        
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            transform.Translate(movement * (_movementSpeed * Time.deltaTime), Space.World);
        }
    }
}
