ServiceManager.CandidateService=(
    function () {

        function privateGetNewGuid() {
            function fd() {
                return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
            }
            return fd() + fd() + '-' + fd() + '-' + fd() + '-' + fd() + '-' + fd() + fd() + fd();
        }

        function privateNewCandidate()
        {
            return {
                Id : privateGetNewGuid(),
                Recruiters : [],
                Login : null,
                LoginId : null,
                CandidateData: [],
                Exams: [],
                DBInsertedDate: null,
                Active: true
            }
        }

        function privateGetCandidates($http, callback) {
            ServiceManager.PersistenceManager.CandidateDAO_Rest.getCandidates($http, callback);
        }

        function privateSaveCandidate($http, candidato) {
            console.log(candidato);
            ServiceManager.PersistenceManager.CandidateDAO_Rest.setCandidate($http, candidato);
        }

        function privateSaveCandidates($http, candidatos) {
            console.log(candidatos);
            ServiceManager.PersistenceManager.CandidateDAO_Rest.saveCandidates($http, candidatos);
        }

        return {
            getNewGuid: privateGetNewGuid,
            NewCandidate: privateNewCandidate,
            getCandidates: privateGetCandidates,
            saveCandidate: privateSaveCandidate,
            saveCandidates: privateSaveCandidates
        }
    }
());