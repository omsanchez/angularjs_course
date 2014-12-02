'use strict';

/* Filters */

angular.module('taskApp.filters', [])
.filter('withStatus', function() {
    return function(tasks, status) {
    	
    	if (status == "Todas")
    		return tasks;

    	var withStatus = [];
		for(var i=0; i<tasks.length; i++){
		 	var task = tasks[i];
		 	if (task.status == status){
		 		withStatus.push(task)
		 	}
		}
		return withStatus;
    };
});
