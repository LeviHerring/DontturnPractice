using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WeaponWheelController : MonoBehaviour
{
    public Animator animator;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;

    public RectTransform rectTransform; 

    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3(1f, 1f, 1f); 
         
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Pressed"); 
            weaponWheelSelected = !weaponWheelSelected; 
        }

        if(weaponWheelSelected)
        {
            animator.SetBool("openWeaponWheel", true);  
        }
        else
        {
            animator.SetBool("openWeaponWheel", false);
        }

        switch (weaponID)
        {
            case 0:
                selectedItem.sprite = noImage;         
                break;
            case 1:
                Debug.Log("E");
                break;
            case 2:
                Debug.Log("Jump High");
                break;
            case 3:
                Debug.Log("Run Fast");
                break;
            case 4:
                Debug.Log("Dash Fast");
                break;
        }

    }

}
