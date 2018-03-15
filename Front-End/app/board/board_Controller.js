angular.module("appModule")
    .controller("homeController",function ($scope) {
        //va almacenar informacion del jugador actual, se le pueden incorporar más detalles
        $scope.player = {
            name : "Josue Arce",
            currentPoints : 0
        };
        //va almacenar información del oponente actual, se le pueden incorporar más detalles
        $scope.opponent = {
          name : "Daniel Montero",
          currentPoints : 0
        };
        //Matriz logica que permitirá manejar los movimientos en el tablero
        $scope.matrizLogica = [];
        //Contiene el tamaño de la matriz, escogido por el usuario
        $scope.tam = {
           fila : 2,
           col : 2
        };

        //Permite crear la matriz con todos sus espacios por defecto
        //El tamaño lo recibe por parametros y luego se generar
        function generate_matriz(tam) {
            //Se crea toda la matriz y se inicializa cada espacio en -1
            for(var filas = 0; filas <  tam.fila; filas++){
                $scope.matrizLogica[filas] = [];
                for(var cols = 0; cols < tam.col; cols++){
                    $scope.matrizLogica[filas][cols] = 0;
                }
            }
            //$scope.matrizLogica[1][1] = 1; $scope.matrizLogica[1][2] = 2;
            //$scope.matrizLogica[2][1] = 2; $scope.matrizLogica[2][2] = 1;
            console.log($scope.matrizLogica);
            pintar_matriz(tam);
        }

        //Está a cargo de traducir la matriz lógica a la matriz visual
        function pintar_matriz(tam) {
            var height = 400/tam.fila; // obtiene la altura de cada celda
            var width = 1000/tam.col; // obtiene el ancho de cada celda
            var tBody = document.createElement('tbody');
            var img;
            var celda;
            var hilera;

            for(var fila = 0; fila < tam.fila;fila++){

                hilera = document.createElement('tr');hilera.setAttribute('id',fila); // filas de la tabla

                for(var col = 0; col < tam.col;col++){

                    celda = document.createElement('td');celda.setAttribute('id',col); // celda de cada fila

                    celda.style.width = width+"px";
                    celda.style.height = height+"px";


                    if($scope.matrizLogica[fila][col] == 1)
                    {
                        //celda.innerHTML= document.getElementById('player1Token');
                    }
                    else if($scope.matrizLogica[fila][col] == 2)
                    {
                        //celda.innerHTML= document.getElementById('player2Token');
                    }

                    hilera.appendChild(celda);
                }
                tBody.appendChild(hilera);
            }
            document.getElementById("table-board").appendChild(tBody);
        }

        generate_matriz($scope.tam);
    })
;