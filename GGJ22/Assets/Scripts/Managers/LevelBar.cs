using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    public static int PlayerLevel = 1;
    public Slider slider;
    
    private float exp = 1;
    private float levelReq = 5;

    

    void Update()
    {
        slider.value = exp / (levelReq);
        
        if (exp >= levelReq) 
        {
            PlayerLevel++;
            levelReq += 3;
            exp = 0;
        }
    }
        
}