using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveDiego : MonoBehaviour
{
    // Start is called before the first frame update
    public int Grid; // esto es el tamaño de mi grid un 10 es un 10x10 un 5 es un 5x5 

    // el plan es usar una matriz doble a ver si puedo hacerlo asi

    public int[][] ArrayTest;

    public GameObject prefab;

    public Coroutine miCorutina;

    

    public GameObject[] Cells;

    public int MaxValueCell;

    public int[] MaxValuePossibilty;

    public GameObject[] CellsImage;




    void Start()
    {
        MaxValuePossibilty = new int[MaxValueCell + 1];

        for(int i = 0; i < MaxValueCell + 1; i++)
        {
            MaxValuePossibilty[i] = i;
            
        }
      
       
        StartWave();

        

        
        
    }

      public int[] ReturnGridwidth()
    {
        int[] Width = new int[Grid];
        
        for(int i = 0; i < Width.Length ; i++)
          {
               //Width[i] = Random.Range(0, Grid); // el ultimo numero no se incluye en el random range

                Width[i] = -1;

           

         }

        return Width;

    }


    public void StartWave()
    {
        StartWaveCollapse();
        //StartWaveCollapseSpiral();

       //StartWaveCollapseSpiral();
    

    }

    public int HandHeight;

    public int HandWidth;

    public void StartWaveCollapse()
    {
          ArrayTest = new int[Grid][];

        for(int i = 0; i<ArrayTest.Length; i++)
        {
             ArrayTest[i] = ReturnGridwidth();  

        }

        Cells = new GameObject[Grid * Grid];

        for(int i = 0 ; i < ArrayTest.Length  ; i++)
        {
           

            for(int j =  0; j < ArrayTest[i].Length ; j++)
            {
                  //print(" el array " + i + "en " + j + "tiene estos valores " + "" + ArrayTest[i][j]);


                   GameObject Cell = Instantiate(prefab, new Vector2(j * 2.5f, i * 2.5f), Quaternion.identity);

                   Cells[ (Grid * i) + j] = Cell;

                   Valor valor = Cell.GetComponent<Valor>();
                    
                    ArrayTest[i][j] = GetCellValuePrint(i , j);

                   

                    valor.ChangeText(ArrayTest[i][j]);
                               //

                   Cell.name = "fila" +i+"columna"+j +" vale" + ArrayTest[i][j];

                    //print(ArrayTest[i][j]);

                   




            }

           
        }

    }

     public int j, i;

    public void StartWaveCollapseSpiral()
    {
         ArrayTest = new int[Grid][];

         int left = 0;
         int top = Grid - 1;
     

         
        for(int i = 0; i<ArrayTest.Length; i++)
        {
             ArrayTest[i] = ReturnGridwidth();  

        }

         Cells = new GameObject[Grid * Grid];

              // izquierda a drecha 

              // N VALE 3

        for(i= 1; i <= Grid/2 ; i++, left++, top--)
    {


         for(j = left ; j <= top ; j++)
         {
            GameObject Cell = Instantiate(prefab, new Vector2(j * 2.5f, left * 2.5f), Quaternion.identity);

            Cells[ (Grid * left) + j] = Cell;

            Valor valor = Cell.GetComponent<Valor>();

            ArrayTest[left][j] = GetCellValuePrint(left , j);

            valor.ChangeText(ArrayTest[left][j]);

            print(" el array " + left + "en " + j + "tiene estos valores " + "" + ArrayTest[left][j]);

             Cell.name = "fila" +left +"columna"+j +" vale" + ArrayTest[left][j];

          

            //Cell.name = "fila" +i+"columna"+j +" vale" + ArrayTest[i][j];

         }



         for(j = left + 1; j <= top ;  j++ )
         {
           
            GameObject Cell = Instantiate(prefab, new Vector2(top * 2.5f, j * 2.5f), Quaternion.identity);

            Cells[ (Grid * j) + top] = Cell;

            Valor valor = Cell.GetComponent<Valor>();

             ArrayTest[j][top] = GetCellValuePrint(j , top);

            valor.ChangeText(ArrayTest[j][top]);

             Cell.name = "fila" +j +"columna"+top +" vale" + ArrayTest[j][top];


           

            //print(" el array " + j + "en " + N + "tiene estos valores " + "" + ArrayTest[i][j]);
         
         }

    
         for(j = top - 1  ; j >= left  ; j--)
         {
            GameObject Cell = Instantiate(prefab, new Vector2(j * 2.5f, top * 2.5f), Quaternion.identity);

             Cells[ (Grid * top) + j] = Cell;

              Valor valor = Cell.GetComponent<Valor>();

              ArrayTest[top][j] = GetCellValuePrint(top , j);

               valor.ChangeText(ArrayTest[j][top]);

            Cell.name = "fila" +top +"columna"+j +" vale" + ArrayTest[top][j];

     


         }


         for(j = top-1; j>=left + 1; j--)
         {
            GameObject Cell = Instantiate(prefab, new Vector2(left * 2.5f, j * 2.5f), Quaternion.identity);

             Cells[ (Grid * j) + left] = Cell;

            Valor valor = Cell.GetComponent<Valor>();

            ArrayTest[j][left] = GetCellValuePrint(j , left);

            valor.ChangeText(ArrayTest[j][left]);

             Cell.name = "fila" +j +"columna"+left +" vale" + ArrayTest[j][left];


         }

     }
        


        

         


        

        
    }

    // metodo de espiral cuadrada vamos a ello
    // for(int k = 0; i < Grid/2 ; k++);
    //izquierda//derecha
    //abajo arriba
    //derecha izquierda
    //arriba 
    // hay que repetir esto por en Grid/2 un cuadrado 4*4 solo se tiene que hacer dos veces, numero imppares ? ni puta idea 
    //for(int i = 0; i < Grid ; i++)
    //{
    //   if k == even or 0 GetValue(Array[k][i]);
    //}  else if k == not even GetValue(Array[i][Gird - k])



      public int GetCellValuePrint(int height, int width)
    {
      
        int[] ArrayFinal;

         int[] Up = CheckStateUpDown(height, width, 1);

        int[] Down =  CheckStateUpDown(height, width, -1);

         int[] Right = CheckStateLeftRight(height, width, 1);

         int[] Left = CheckStateLeftRight(height, width, -1);

        var resultFinal = Up.Intersect(Down).Intersect(Right).Intersect(Left); 

        if(resultFinal.Any())
        {
            ArrayFinal = resultFinal.ToArray();

            foreach(var item in resultFinal)
            {
                //print(item);
            }

             //Valor valor = Cells[ (Grid * height) + width].GetComponent<Valor>();
        
             //valor.ChangeText(ArrayTest[height][width] );

             //valor.TextValue();

             return ArrayFinal[Random.Range(0, ArrayFinal.Length)];

            
                   
        }else
        {
             return 0;

        }



        

    }

     public int[] CheckStateUpDown(int height, int width, int direction)
    {
        int newHeight = direction == 1 ? height + 1 : height -1 ;

        if(newHeight < 0 || newHeight >= Grid)
        {     
            return MaxValuePossibilty;

        }else if(ArrayTest[newHeight][width] == -1 )
        {
       
            return MaxValuePossibilty;

        }
        else
        {
            
            int[] result = new int[3];

            result[0] = ArrayTest[newHeight][width] - 1 ;

            if(result[0] == -1)
            {
                result[0] = 0;
            }

            result[1] = ArrayTest[newHeight][width];

            result[2] = ArrayTest[newHeight][width] + 1;

             if(result[2] >= MaxValueCell)
            {
                result[2] = MaxValueCell;

                
            }

            //print("NUMERO POSIBLE DETECTADO");

            return result;
        }
    }





    public int[] CheckStateLeftRight(int height, int width, int direction)
    {
        int newWidth = direction == 1 ? width + 1 : width -1 ;

        if(newWidth < 0 || newWidth >= ArrayTest[height].Length)
        {
           
            return MaxValuePossibilty;

        
            
        }else if(ArrayTest[height][newWidth] == -1)
        {

            return MaxValuePossibilty;


        }
        else
        {
             int[] result = new int[3];

            result[0] = ArrayTest[height][newWidth] - 1;

              if(result[0] == -1)
            {
                result[0] = 0;
            }


            result[1] = ArrayTest[height][newWidth];

            result[2] = ArrayTest[height][newWidth] + 1;

              if(result[2] >= MaxValueCell)
            {
                result[2] = MaxValueCell;
            }


            return result;
            //print("NUMERO POSIBLE DETECTADO");
        }
    }

   
    public void Restart()
    {
        //  if(miCorutina != null)
        // {
        //      StopCoroutine(miCorutina);
        //  }

         for(int i = 0; i < Cells.Length; i ++)
         {
            Destroy(Cells[i]);

         }

         StartWave();

         



    }
    
}


 