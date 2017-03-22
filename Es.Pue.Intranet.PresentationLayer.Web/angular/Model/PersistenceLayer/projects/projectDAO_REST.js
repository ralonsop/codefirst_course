var projectDAO_REST = (
    function () {
        function privateProjectsSave(ctr){
            ctr.$http({
                method:'POST',
                url:'http://mutuaapi.azurewebsites.net/api/projects',
                data:ctr.projects
            }).
             then(
             function successCallback(response){
                 if(response.data!=null){
                     ctr.projects=response.data;
                 }
             },
             function errorCallback(response){
                 console.log(response.data);
             }			
             );      
        } 

       function privateGetProjects(ctr){
      
           ctr.$http({
               method:'GET',
               url:'http://mutuaapi.azurewebsites.net/api/projects'
           }).
		    then(
			function successCallback(response){
			    if(response.data!=null){
			        ctr.projects=response.data;
			    }
			},
			function errorCallback(response){
			    console.log(response.data);
			}			
			);                    
        }

        return{
            projectsSave: privateProjectsSave,
            getProjects:privateGetProjects
        };
})();