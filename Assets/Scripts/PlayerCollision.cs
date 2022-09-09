using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Colors")]
    [SerializeField] private Color32 redColor;
    [SerializeField] private Color32 greenColor;
    [SerializeField] private Color32 blueColor;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out Collectibles collectible)) return;  
        // This is an inverted if. If the above condition is not met, return void (stop this function).
        
        var collectibleType = collectible.GetCollectibleInfoOnContact();

        switch (collectibleType)
            {
                case CollectibleType.Red:
                    spriteRenderer.color = redColor;
                    break;
                case CollectibleType.Green:
                    spriteRenderer.color = greenColor;
                    break;
                case CollectibleType.Blue:
                    spriteRenderer.color = blueColor;
                    break;
            }
    }
}
