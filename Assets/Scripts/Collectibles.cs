using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleType collectibleType;
    
    public CollectibleType GetCollectibleInfoOnContact()
    {
        gameObject.SetActive(false);

        return collectibleType;
    }

    public void SetCollectibleType(CollectibleType value)
    {
        collectibleType = value;
    }
}
