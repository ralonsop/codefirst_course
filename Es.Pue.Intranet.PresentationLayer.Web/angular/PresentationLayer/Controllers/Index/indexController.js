app.controller('indexController', 
	function($scope, $interval,$http) {
  var ctr = this;
  ctr.$http = $http;

ctr.addProject=function(){
    ctr.nuevoProyecto.Cardinality=
    ctr.projects.length;
    ctr.projects.push(ctr.nuevoProyecto);
    ctr.nuevoProyecto=
    projectsService.crearProject();
}
ctr.saveProjects=function(){

projectsService.
projectsSave('REST',ctr);


}

ctr.removeProject=function(project){
var newProjects=[];
ctr.projects.forEach(function(element,index){
    if(element!=project)
    {
        element.Cardinality=
        newProjects.length;

        newProjects.push(element);
    }
}); 
ctr.projects=newProjects;

}
ctr.selectProject=function(project){
ctr.selectedProject=project;
}


ctr.addPerson=function(){
ctr.nuevaPersona.Cardinality=
ctr.selectedProject.Team.length;

ctr.selectedProject.Team.push(ctr.nuevaPersona);

ctr.nuevaPersona=
projectsService.crearPersona();

}

ctr.removePerson=function(persona){

var newTeam=[];
ctr.selectedProject.team.forEach(function(element,index){
	if(element!=persona)
	{
		element.Cardinality=newTeam.length;
		newTeam.push(element);
	}
}); 
ctr.selectedProject.Team=newTeam;

}




ctr.ordenar=function(prop){

ctr.orderByDirection =
 (ctr.orderByProperty === prop) ? 
 !ctr.orderByDirection : false;
   
    ctr.orderByProperty = prop;
  
}

ctr.updateMVVM=function(){
     $scope.$apply();
}

$scope.$watch('ctr.projects',
    function(newValue,oldValue) {
    if(newValue!=oldValue && 
        oldValue.length>0){

        newValue.forEach(function(element,index){

     var project=null;
     project= oldValue.filter(function(v) {
    return v.Id === element.Id;})[0];

    if(project===null ||
     (!angular.equals(element,project)&&
    ctr.modifiedProjects.filter(function(v) {
    return v.Id === element.Id;})[0]==undefined)
     ){
        ctr.modifiedProjects.push(element);
    }


        });


           projectsService.
        projectsSave('LocalStorage',ctr.projects);
        console.log('Watcher!!')
            }
    },true);

        $interval(function(){
             projectsService.
        projectsSave('LocalStorage',ctr.projects);
         console.log('Watcher!!')
            ctr.projects=[];


        }, 9000000);

inicializarModelo();
function inicializarModelo (){
ctr.projects=[];
ctr.modifiedProjects=[];
ctr.selectedProject = {};
ctr.orderByProperty = 'Cardinality';
ctr.orderByDirection = false;

ctr.nuevoProyecto=
projectsService.crearProject();

projectsService.getProjects('REST', ctr);
}

});

function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("personId",
     ev.target.getAttribute('data-object-id'));
}

function drop(ev) {
    ev.preventDefault();

    var personIdOrigen = 
    ev.dataTransfer.getData("personId");
   
    var personIdDestino=
    ev.target.getAttribute('data-object-id');   

var team=
   angular.element(document.body).scope().ctr.team;

    var cardinalityOrigen = team.filter(function(v) {
    return v.Id === personIdOrigen; 
})[0].Cardinality;

  var cardinalityDestino = team.filter(function(v) {
    return v.Id === personIdDestino; 
})[0].Cardinality;
  

team.forEach(function(element,index){
  if (element.Cardinality == cardinalityOrigen) {
    element.Cardinality = cardinalityDestino;
    }

    else 
    if (cardinalityOrigen > cardinalityDestino){
    if (element.Cardinality < cardinalityOrigen && element.Cardinality >= cardinalityDestino) {
    element.Cardinality++;
    }
    } else {
    if (element.Cardinality > cardinalityOrigen && element.Cardinality <= cardinalityDestino) {
    element.Cardinality--;
    }       
    }
      
});

 angular.element(document.body)
 .scope().ctr.updateMVVM();
}



