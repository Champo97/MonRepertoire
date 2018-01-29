app.controller("morceauController", ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {

    $scope.ListMorceaux = [];

    //Récupérer la liste des morceaux
    $http.get("api/morceau/getAll").then(function (data) {
        var listMorceaux = data.data;
        for (var morceauIndex = 0; morceauIndex < listMorceaux.length; morceauIndex++)
        {
            $scope.ListMorceaux.push(listMorceaux[morceauIndex]);
        }
    }, function (error) {
        console.log("Error - " + error.status + error.data.MessageDetail);
    });

    //Ajouter un nouveau morceau 
    $scope.Add = function () {
        var morceau = {
            Titre : $scope.Titre
            ,Tonalite : $scope.Tonalite
            ,Grille : $scope.Grille
            ,Complexite : $scope.Complexite
        };
        debugger;
        $http.post("/api/morceau/addOne", morceau).then(function (data) {
            $location.path('/morceaux');
        }, function(error){console.log("Error - " + error.status + error.data.MessageDetail);});
    }
    
    if ($routeParams.MorceauId) {
        $scope.MorceauId = $routeParams.morceauId;

        $http.get('/api/morceau/getOne/' + $scope.MorceauId).then(function (data) {
            $scope.Titre = data.Titre;
            $scope.Tonalite = data.Tonalite;
            $scope.Grille = data.Grille;
            $scope.Complexite = data.Complexite;
        });
    }

    //Modifier le morceau 
    $scope.Update = function () {
        debugger;
        var morceau = {
            MorceauId : $scope.MorceauId
            ,Titre: $scope.Titre
            , Tonalite: $scope.Tonalite
            , Grille: $scope.Grille
            , Complexite: $scope.Complexite
        };
        if ($scope.MorceauId > 0) {

            $http.put("Server/api/morceau/updateOne", morceau).then(function (data) {
                $location.path('/morceaux');
            }, function(error){console.log("Error - " + error.status + error.data.MessageDetail);});
        }
    }

    //Supprimer le morceau 
    $scope.Delete = function () {
        if ($scope.MorceauId > 0) {

            $http.delete("Server/api/morceau/deleteOne/" + $scope.MorceauId).then(function (data) {
                $location.path('/morceaux');
            },function(error){console.log("Error - " + error.status + error.data.MessageDetail);});
        }
    }

    $scope.Close = function () {
        $location.path('/morceaux');
    }

}]);
