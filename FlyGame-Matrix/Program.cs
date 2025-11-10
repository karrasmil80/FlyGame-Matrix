using System;
using static System.Console;
using FlyGame_Matrix.Structs; //Importamos la structs
using System.Text; //Iconos

OutputEncoding = Encoding.UTF8;

//CONSTANTES GLOBALES
const int RowSize = 10;
const int ColSize = 10;
const int Attempts = 5;
const int Flylifes = 2;

//Procedimiento que imprime el vector
void PrintVector(){
    for(int i = 0; i < RowSize; i++){
        for(int j = 0; j < ColSize; j++){
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
        WriteLine($"Introduce el número de la casilla a la que lanzas la piedra (posición 1 a {RowSize} {ColSize})");
        string input = ReadLine();
        
        //Intenta realizar la conversion de string a entero
        if (int.TryParse(input, out result) && result >= 1 && result <= RowSize && result <= ColSize) {
            isOk = true; 
            
        } else {
            WriteLine($"Entrada no válida. Por favor, introduce un número entero entre 1 y {ColSize} {RowSize}.");
            isOk = false;
        }
        
    } while (!isOk); //Si el parseo a entero falla el bucle se repite
    
    return result - 1; //Utilizo el - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
}

void PlayFlyGame(){

    HitInfo throwRock = new HitInfo();
    
    do {
        
        throwRock.Hits = ThrowRock();
        
        
        
        
        
    } while(Flylifes != 0 || Attempts != 0);
}

int TakeOffFlyLife(){
    FlyState life;

    life.LifeNumber = Flylifes;

    return Flylifes - 1;
}

int TakeOffAttempts(){
    Configuration PlayerLife;

    PlayerLife.intentos = Attempts;

    return Attempts - 1;
}

void PrintMoscaState(){
    
}




//--INICIO DEL MAIN--

Configuration sizeMap;

//Matriz de tamaño [rowSize] filas y [colSize] columnas
sizeMap.Size = new int[RowSize, ColSize];

//Imprime el tamaño del vector
PrintVector();

//--FIN DEL MAIN--