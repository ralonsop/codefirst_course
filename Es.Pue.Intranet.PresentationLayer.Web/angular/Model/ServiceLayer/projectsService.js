var projectsService = (
    function () {  
        function privateProjectsSave(
            persistenceTechnology,ctr){  
            var dao;
            switch(persistenceTechnology)
            {
                case 'LocalStorage':
                dao=projectDAO_LocalStorage;
                break;
                case 'REST':
                dao = projectDAO_REST;
                break;
              
            }
            dao.projectsSave(ctr);
        }

        function privateGetProjects(
           persistenceTechnology, ctr) {
            var dao;
            switch (persistenceTechnology) {
                case 'LocalStorage':
                    dao = projectDAO_LocalStorage;
                    break;
                case 'REST':
                    dao = projectDAO_REST;
                    break;

            }
            dao.getProjects(ctr);
        }
        function privateCrearPersona(){
        
        return {
            Id:privateGetGUID(),
            Name:null,
            Surname:null,
            Nif:null,
            DBInsertedDate:null,
            Active:true,
            Cardinality:0
        };
        }
        function privateCrearProject(){
        
        return {
            Id:privateGetGUID(),
            Name:null,
            Entries:[],
            Team:[],
            DBInsertedDate:null,
            Active:true,
            Cardinality:0
        };
        }

    function privateGetGUID() {
    function fd() {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
    }
    return fd() + fd() + '-' + fd() + '-' + fd() + '-' + fd() + '-' + fd() + fd() + fd();
    }

        return{
            crearPersona:privateCrearPersona,
            crearProject:privateCrearProject,
            getGUID:privateGetGUID,
            projectsSave: privateProjectsSave,
            getProjects:privateGetProjects
        };
})();