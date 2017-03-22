app.controller('indexController',
	function ($scope, $http) {

	    $scope.Candidates = [];
        
	    $scope.candidatesCopy = [];

	    ServiceManager.CandidateService.getCandidates($http, function (data) {
	        $scope.Candidates = data;

	        $scope.candidatesCopy = angular.copy(data);
	    });

	    //for (var i = 0; i < 6; i++)
	    //{
	    //    $scope.Candidates.push(ServiceManager.CandidateService.NewCandidate());
	    //}

	    $scope.anadirCandidato = function () {
	        console.log("añadir candidato");
	        $scope.Candidates.push(ServiceManager.CandidateService.NewCandidate());
	    }

	    $scope.guardarCandidatos = function () {
	        console.log("Guardamos candidatos");

	        if (!angular.equals($scope.Candidates, $scope.candidatesCopy))
	        {
	            console.log("No iguales");

	            var candidatechange = [];


	            for(var cont=0; cont < $scope.Candidates.length; cont++)
	            {
	                //console.log($scope.Candidates[cont]);

	                if (cont < $scope.candidatesCopy.length)
	                {
	                    if (!angular.equals($scope.Candidates[cont], $scope.candidatesCopy[cont]))
	                    {
	                        //ServiceManager.CandidateService.saveCandidate($http, $scope.Candidates[cont]);
	                        candidatechange.push($scope.Candidates[cont]);
	                    }
	                }
	                else
	                {
	                    console.log($scope.Candidates[cont]);
	                    //ServiceManager.CandidateService.saveCandidate($http, $scope.Candidates[cont]);
	                    candidatechange.push($scope.Candidates[cont]);
	                }
	            }

	            if (candidatechange.length > 0)
	            {
	                ServiceManager.CandidateService.saveCandidates($http, candidatechange);
	            }
	        }
	    }
	    
	});