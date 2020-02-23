using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageSwitcher : MonoBehaviour
{
    [SerializeField]
    public Sprite starterImage;
    [SerializeField]
    public Sprite otherImage;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();        
    }



    public void changeImages(bool isStarter)
    {
        image.sprite = isStarter ? starterImage : otherImage;
    }

}
