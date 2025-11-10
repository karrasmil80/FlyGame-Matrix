using System;
using static System.Console; //Para evitar escribir console en los comandos de impresion etc...
using FlyGame_Matrix.Structs; //Importamos la structs
using System.Text; //Iconos

OutputEncoding = Encoding.UTF8;

//CONSTANTES GLOBALES
const int RowSize = 3;
const int ColSize = 3;
const int Attempts = 5;
const int Flylifes = 2;

//Procedimiento que imprime el vector
void PrintVectorAndHit(){
    
    FlyState positionCol;
    FlyState positionRow;
    
    positionCol.PositionCol = GenerateFlyPositionCol();
    positionRow.PositionRow = GenerateFlyPositionRow();

    HitInfo hitCol;
    HitInfo hitRow;

    hitRow.HitRow = ThrowRockRow();
    hitCol.HitCol = ThrowRockCol();
    
    for(int i = 0; i < RowSize; i++){
        for(int j = 0; j < ColSize; j++){
            if(i == positionRow.PositionRow && j == positionCol.PositionCol){
                Write("[🪰]");
                
            } else if(i == hitRow.HitRow && j == hitCol.HitCol){
                Write("[🪨]");
                
            } else {
                Write($"[{i}{j}]");
            }
            
        }
        WriteLine();
    }

    
}

int GenerateFlyPositionRow(){
    Random random = new Random();
    
    FlyState position;
    position.PositionRow = random.Next(0, RowSize);
    
    return position.PositionRow ;
}

int GenerateFlyPositionCol(){
    Random random = new Random();
    
    FlyState position;
    position.PositionCol = random.Next(0, ColSize);
    
    return position.PositionCol ;
}

int ThrowRockCol() {
    
    //Utilizo él - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
    int result = -1;
    
    //Variable bandera para decidir cuando se repite el bucle
    bool isOk = false;

    do {
        WriteLine($"Introduce el número de la casilla a la que lanzas la piedra (posición 1 a {ColSize})");
        string input = ReadLine();
        
        //Intenta realizar la conversion de string a entero
        if (int.TryParse(input, out result) && result >= 1 && result <= ColSize) {
            isOk = true; 
            
        } else {
            WriteLine($"Entrada no válida. Por favor, introduce un número entero entre 1 y {ColSize}");
            isOk = false;
        }
        
    } while (!isOk); //Si el parseo a entero falla el bucle se repite
    
    return result - 1; //Utilizo el - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
}

int ThrowRockRow() {
    
    //Utilizo él - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
    int result = -1;
    
    //Variable bandera para decidir cuando se repite el bucle
    bool isOk = false;

    do {
        WriteLine($"Introduce el número de la casilla a la que lanzas la piedra (posición 1 a {RowSize})");
        string input = ReadLine();
        
        //Intenta realizar la conversion de string a entero
        if (int.TryParse(input, out result) && result >= 1 && result <= RowSize) {
            isOk = true; 
            
        } else {
            WriteLine($"Entrada no válida. Por favor, introduce un número entero entre 1 y {RowSize}.");
            isOk = false;
        }
        
    } while (!isOk); //Si el parseo a entero falla el bucle se repite
    
    return result - 1; //Utilizo el - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
}

string AnalizarGolpeo(FlyState position, HitInfo hitInfo){

    HitInfo hitType;
    
    hitType.Goal = "🎯 Has dado a la mosca! Enhorabuena 🎯";
    hitType.Almost = "☣️ Casi das a la mosca, cambiando de posicion... ☣️";
    hitType.Miss = " ❌ Has fallado, sigue intentandolo ❌";

    if(position.PositionCol == hitInfo.HitCol && position.PositionRow == hitInfo.HitRow){
        return hitType.Goal;
        TakeOffFlyLife();
        
    } else if(position.PositionCol == hitInfo.HitCol && position.PositionRow == hitInfo.HitRow - 1){
        return hitType.Almost;
        TakeOffAttempts();
        
    } else if(position.PositionCol == hitInfo.HitCol + 1 && position.PositionRow == hitInfo.HitRow - 1){
        return hitType.Almost;
        
    } else if(position.PositionCol == hitInfo.HitCol + 1 && position.PositionRow == hitInfo.HitRow){
        return hitType.Almost;
        
    } else if(position.PositionCol == hitInfo.HitCol + 1 && position.PositionRow == hitInfo.HitRow + 1){
        return hitType.Almost;
        
    } else if(position.PositionCol == hitInfo.HitCol  && position.PositionRow == hitInfo.HitRow + 1 ){
        return hitType.Almost;
        
    } else if(position.PositionCol == hitInfo.HitCol - 1 && position.PositionRow == hitInfo.HitRow + 1){
        return hitType.Almost;
        
    } else if(position.PositionCol == hitInfo.HitCol - 1 && position.PositionRow == hitInfo.HitRow){
        return hitType.Almost;
        
    } else if(position.PositionCol == hitInfo.HitCol - 1 && position.PositionRow == hitInfo.HitRow - 1){
        return hitType.Almost;
    }

    else{
        return hitType.Miss;
    }
    
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





//--INICIO DEL MAIN--

Configuration sizeMap;

//Matriz de tamaño [rowSize] filas y [colSize] columnas
sizeMap.Size = new int[RowSize, ColSize];

//Imprime el tamaño del vector
PrintVectorAndHit();

//--FIN DEL MAIN--