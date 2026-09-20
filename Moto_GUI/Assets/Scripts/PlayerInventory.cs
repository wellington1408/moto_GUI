using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets; 

public class PlayerInventory : MonoBehaviour
{
    [Header("Configuração Manual")]
    public int playerId = 1;
    [SerializeField] private bool usarIdDoInspector = true;

    [Header("Configuração de Velocidade")]
    [SerializeField] private float speedMultiplier = 1.20f;

    private int currentCoins = 0;

    private void Start()
    {
        PlayerInput pInput = GetComponent<PlayerInput>();
        
        if (!usarIdDoInspector && pInput != null)
        {
            playerId = pInput.playerIndex + 1; 
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterPlayer(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            currentCoins++;

            
            AumentarVelocidade();

          
            PlayerObserverManager.NotifyCoinsChanged(playerId, currentCoins);
            
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnCoinCollected();
            }

            Destroy(other.gameObject);
        }
    }

    private void AumentarVelocidade()
    {
        
        ThirdPersonController controller = GetComponent<ThirdPersonController>();
        
        if (controller != null)
        {
           
            controller.MoveSpeed *= speedMultiplier;
            
          
            controller.SprintSpeed *= speedMultiplier;
        }
    }

    public int GetCoins() => currentCoins;
}