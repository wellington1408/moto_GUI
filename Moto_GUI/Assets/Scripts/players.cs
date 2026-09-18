using UnityEngine;
using UnityEngine.InputSystem;

public class players : MonoBehaviour
{
    [SerializeField] private PlayerInput player1;
    [SerializeField] private PlayerInput player2;

    void Start()
    {
        if (player1 != null && player2 != null)
        {
            
            player1.SwitchCurrentControlScheme("P1teclado", Keyboard.current);
            player2.SwitchCurrentControlScheme("P2teclado", Keyboard.current);
        }
    }
}