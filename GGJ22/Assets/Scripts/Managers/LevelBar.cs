using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelBar : MonoBehaviour
{
    public  int PlayerLevel = 1;
    public Slider slider;
    public int cesetCount;
    public float exp = 1;
    public TMP_Text levelReqCounter ;
    public TMP_Text levelCounter;

    public float cesetReq = 0;
    public float levelReq = 5;
    public TMP_Text cestCounter;



    void Update()
    {
        levelCounter.text = "x "+ PlayerLevel.ToString();
        cesetReq = levelReq - exp;
        levelReqCounter.text = cesetReq.ToString();
        cestCounter.text = cesetCount.ToString();
        slider.value = exp / (levelReq);
        
        if (exp >= levelReq) 
        {
            PlayerLevel++;
            exp = exp - levelReq;

            levelReq += 3;
        }
    }
        
}