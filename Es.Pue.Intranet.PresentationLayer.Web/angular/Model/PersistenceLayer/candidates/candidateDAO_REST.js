ServiceManager.PersistenceManager.CandidateDAO_Rest = (
    function () {

        function privateGetCandidates($http, callback) {
            $http({
                method: 'GET',
                url: 'http://localhost:52546/candidatesapi/candidates'
            }).
		    then(
			function successCallback(response) {
			    if (response.data != null) {
			        callback(response.data);
			        //ctr.$scope.Candidates = response.data;
			    }
			},
			function errorCallback(response) {
			    console.log(response.data);
			}
			);
        }

        function privateSetCandidate($http, candidato) {
            console.log(candidato);

            $http({
                method: 'POST',
                url: 'http://localhost:52546/CandidatesApi/Candidate',
                data: candidato
            }).
            then(
            function successCallback(response) {
                console.log(response.data);
            },
            function errorCallback(response) {
                console.log(response.data);
            }
            );
        }

        function privateSaveCandidates($http, candidatos) {
            console.log(candidatos);

            $http({
                method: 'POST',
                url: 'http://localhost:52546/CandidatesApi/Candidates',
                data: candidatos
            }).
            then(
            function successCallback(response) {
                console.log(response.data);
            },
            function errorCallback(response) {
                console.log(response.data);
            }
            );
        }

        return {
            getCandidates: privateGetCandidates,
            setCandidate: privateSetCandidate,
            saveCandidates: privateSaveCandidates
        }

    }
());