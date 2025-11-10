using System;
using static System.Console; //Para evitar escribir console en los comandos de impresion etc...
using FlyGame_Matrix.Structs; //Importamos la structs
using System.Text; //Iconos

OutputEncoding = Encoding.UTF8;

//CONSTANTES GLOBALES
const int RowSize = 3;
const int ColSize = 2;
const int Flylifes = 2;
const int MaxPlayerAttempts = 5;

//Procedimiento que imprime el vector
void PrintVectorAndHit(FlyState position, HitInfo hitInfo){
    
    for(int i = 0; i < RowSize; i++){
        for(int j = 0; j < ColSize; j++){
            // Comprobamos si es la mosca
            if(i == position.PositionRow && j == position.PositionCol){
                Write("[🪰]");
                // Comprobamos si es el golpe
            } else if(i == hitInfo.HitRow && j == hitInfo.HitCol){
                Write("[🪨]");
            } else {
                Write($"[{i}{j}]");
            }
            
        }
        WriteLine();
    }
    WriteLine("------------------------");
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
    
    return result - 1; //Utilizo él - 1 para que comience a pegar en un numero equivalente a la posicion de los indices
}

int ThrowRockRow() {
    
    //Utilizo él - 1 para que comience a pegar en un número equivalente a la posicion de los índices
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

int TakeOffPlayerLife(int intentos){
    return intentos - 1;
}

int takeOffFlylife(ref int flyLifes){
    return flyLifes - 1; 
}

void AnalizarGolpeo(FlyState position, HitInfo hitInfo, ref int intentos, ref int flyLifes){
    
    HitInfo hitType;
    hitType.Goal = "🎯 Has dado a la mosca! Enhorabuena 🎯";
    hitType.Almost = "☣️ Casi das a la mosca, cambiando de posicion... ☣️";
    hitType.Miss = " ❌ Has fallado, sigue intentandolo ❌";

    if(position.PositionCol == hitInfo.HitCol && position.PositionRow == hitInfo.HitRow){
        WriteLine(hitType.Goal);
        flyLifes = takeOffFlylife(ref flyLifes);
        WriteLine($"A la mosca le quedan {flyLifes} vidas");


    } else if(position.PositionCol == hitInfo.HitCol && position.PositionRow == hitInfo.HitRow - 1){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
        
    } else if(position.PositionCol == hitInfo.HitCol + 1 && position.PositionRow == hitInfo.HitRow - 1){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else if(position.PositionCol == hitInfo.HitCol + 1 && position.PositionRow == hitInfo.HitRow){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else if(position.PositionCol == hitInfo.HitCol + 1 && position.PositionRow == hitInfo.HitRow + 1){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else if(position.PositionCol == hitInfo.HitCol  && position.PositionRow == hitInfo.HitRow + 1 ){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else if(position.PositionCol == hitInfo.HitCol - 1 && position.PositionRow == hitInfo.HitRow + 1){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else if(position.PositionCol == hitInfo.HitCol - 1 && position.PositionRow == hitInfo.HitRow){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else if(position.PositionCol == hitInfo.HitCol - 1 && position.PositionRow == hitInfo.HitRow - 1){
        WriteLine(hitType.Almost);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
        
    } else {
        WriteLine(hitType.Miss);
        intentos = TakeOffPlayerLife(intentos);
        WriteLine($"Te quedan {intentos} intentos");
    }
}

void PlayFlyGame(){

    int playerAttempts = MaxPlayerAttempts;
    int flylifes = Flylifes;
    
    do{
        FlyState flyPosition = new FlyState();
        flyPosition.PositionCol = GenerateFlyPositionCol();
        flyPosition.PositionRow = GenerateFlyPositionRow();
    
        HitInfo hitInfo = new HitInfo();
        hitInfo.HitRow = ThrowRockRow();
        hitInfo.HitCol = ThrowRockCol();

        PrintVectorAndHit(flyPosition, hitInfo);
    
        AnalizarGolpeo(flyPosition, hitInfo, ref playerAttempts, ref flylifes);

        if(playerAttempts == 0){
            WriteLine("Te has quedado sin intentos, suerte la proxima vez");
        }

        if(flylifes == 0){
            WriteLine("La mosca se ha quedado sin vidas ¡Has ganado!");
        }
        
    } while(flylifes != 0 && playerAttempts != 0 );
}


//--INICIO DEL MAIN--

Configuration sizeMap;

//Matriz de tamaño [rowSize] filas y [colSize] columnas
sizeMap.Size = new int[RowSize, ColSize];

//Imprime el tamaño del vector
PlayFlyGame();

//--FIN DEL MAIN--