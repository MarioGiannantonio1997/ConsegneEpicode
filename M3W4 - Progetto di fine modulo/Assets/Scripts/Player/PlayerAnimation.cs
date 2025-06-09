using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer; 

    private PlayerController playerController;
    private PlayerAimController playerAimController;

    [Header("Animation Settings")]
    [Tooltip("La soglia minima di movimento per attivare l'animazione di camminata.")]
    [SerializeField]
    private float movementThreshold = 0.1f; // Soglia per rilevare il movimento

    private void Awake()
    {
        // Mi stampo i controlli per assicurarmi che i riferimenti non siano nulli, spesso mi distraggo e non li metto
        if (playerAnimator == null)
            playerAnimator = GetComponent<Animator>();
        if (playerSpriteRenderer == null)
            playerSpriteRenderer = GetComponent<SpriteRenderer>();

        playerController = GetComponent<PlayerController>();
        playerAimController = GetComponent<PlayerAimController>();

        // Controlli per assicurarsi che i riferimenti non siano nulli
        if (playerAnimator == null) Debug.LogError("PlayerAnimation: Animator non trovato sul GameObject Player.");
        if (playerSpriteRenderer == null) Debug.LogError("PlayerAnimation: SpriteRenderer non trovato sul GameObject Player.");
        if (playerController == null) Debug.LogError("PlayerAnimation: PlayerController non trovato sul GameObject Player.");
        if (playerAimController == null) Debug.LogError("PlayerAnimation: PlayerAimController non trovato sul GameObject Player.");
    }

    private void Update()
    {
        // Gestione delle animazioni di movimento (Idle/Walk)
        HandleMovementAnimation();

        // Gestione dell'orientamento del corpo quando idle (basato sul mouse)
        HandleBodyOrientationAndSpriteFlip(); 
    }

    private void HandleMovementAnimation()
    {
        if (playerAnimator == null || playerController == null) return;

        bool isMoving = playerController.Direction.magnitude > movementThreshold;
        
        playerAnimator.SetBool("IsWalking", isMoving);

        // Se il player si sta muovendo, usa la sua direzione di movimento per le animazioni di camminata
        if (isMoving)
        {
            playerAnimator.SetFloat("MoveDirectionX", playerController.Direction.x);
            playerAnimator.SetFloat("MoveDirectionY", playerController.Direction.y);
        }
        else
        {
            // per evitare che il Blend Tree si fermi su una direzione residua. Quando non si muove, resetta la direzione di movimento a zero o a una direzione di default
            playerAnimator.SetFloat("MoveDirectionX", 0);
            playerAnimator.SetFloat("MoveDirectionY", 0);
        }
    }

    /// Determina la direzione del mouse rispetto al player e imposta i parametri 'LookDirectionX/Y' nell'Animator
    /// per l'animazione di Idle, e gestisce il flip dello sprite.
    private void HandleBodyOrientationAndSpriteFlip()
    {
        if (playerAnimator == null || playerSpriteRenderer == null || playerAimController == null) return;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z; 
        
        Vector2 directionToMouse = (mouseWorldPosition - transform.position).normalized;

        // Passa le componenti X e Y della direzione del mouse all'Animator per l'orientamento del corpo (Idle)
        playerAnimator.SetFloat("LookDirectionX", directionToMouse.x);
        playerAnimator.SetFloat("LookDirectionY", directionToMouse.y);

        // Gestisci il flip dello sprite basato sulla direzione orizzontale del mouse (Il corpo del player si orienta sempre verso il mouse)
        if (directionToMouse.x < 0) 
        {
            playerSpriteRenderer.flipX = true; 
        }
        else if (directionToMouse.x > 0) 
        {
            playerSpriteRenderer.flipX = false; 
        }
    }
}