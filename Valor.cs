using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Valor : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text text;

    public GameObject MyImage;

    public Color color = Color.white;

   public void ChangeText(int WaveText)
   {
     //print(WaveText);
     
     text.text = WaveText.ToString();

     float r = ((-51*WaveText + 255));

     MyImage.GetComponent<Image>().color = new Color32((byte)r, (byte)r , (byte)r, 255);

      //image.color = color;
   }
   // f(x)=-51*x+255

   public void TextValue()
   {
     print(int.Parse(text.text));
   }
}
