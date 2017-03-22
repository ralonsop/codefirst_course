var projectDAO_LocalStorage = (
    function () {
        function privateProjectsSave(ctr) {
           
            localStorage.setItem(
                'projects',
                JSON.stringify(ctr.projects)
                );           
        } 
        function privateSaludo() {
            return 'Hola';
        }
        function privateGetProjects(){
       return JSON.parse(
        localStorage.getItem('projects'));
                      
        }

        return{
            projectsSave: privateProjectsSave,
            getProjects: privateGetProjects
        };
})();