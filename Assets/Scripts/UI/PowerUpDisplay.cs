using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplay : MonoBehaviour
{
    [SerializeField] private Texture speedPowerUpTexture;
    [SerializeField] private Texture shieldPowerUpTexture;
    
    private RawImage _rawImage;
    
    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _rawImage.enabled = false;
    }
    
    public void SetSpeedPowerUp()
    {
        _rawImage.texture = speedPowerUpTexture;
        _rawImage.enabled = true;
    }
    
    public void SetShieldPowerUp()
    {
        _rawImage.texture = shieldPowerUpTexture;
        _rawImage.enabled = true;
    }
    
    public void Reset()
    {
        _rawImage.enabled = false;
        _rawImage.texture = null;
    }
}
