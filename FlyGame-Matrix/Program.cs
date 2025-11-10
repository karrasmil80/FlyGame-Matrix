using System;
using static System.Console;
using FlyGame_Matrix.Structs; //Importamos la structs
using System.Text; //Iconos

OutputEncoding = Encoding.UTF8;

//CONSTANTES GLOBALES
const int rowSize = 10;
const int colSize = 10;


//Procedimiento que imprime el vector
void printVector(){
    for(int i = 0; i < rowSize; i++){
        for(int j = 0; j < colSize; j++){
            Write($"[{i}{j}]");
        }
        WriteLine();
    }
}

int ThrowRock() {
    
    //Utilizo el - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
    int result = -1;
    
    //Variable bandera para decidir cuando se repite el bucle
    bool isOk = false;

    do {
        WriteLine($"Introduce el número de la casilla a la que lanzas la piedra (posición 1 a {rowSize} {colSize})");
        string input = ReadLine();
        
        //Intenta realizar la conversion de string a entero
        if (int.TryParse(input, out result) && result >= 1 && result <= rowSize && result <= colSize) {
            isOk = true; 
            
        } else {
            WriteLine($"Entrada no válida. Por favor, introduce un número entero entre 1 y {colSize} {rowSize}.");
            isOk = false;
        }
        
    } while (!isOk); //Si el parseo a entero falla el bucle se repite
    
    return result - 1; //Utilizo el - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
}

void PlayFlyGame(){
    
}




//--INICIO DEL MAIN--

Configuration sizeMap;

//Matriz de tamaño [rowSize] filas y [colSize] columnas
sizeMap.Size = new int[rowSize, colSize];

//Imprime el tamaño del vector
printVector();

//--FIN DEL MAIN--