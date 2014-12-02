'use strict';

/* Directives */


angular.module('taskApp.directives', [])
.directive('taskItem',  function() {
	return {
		restrict: 'AC',
	  template: '<span> {{ task.code }} - {{ task.description }} </span> <p> Asignado a {{ task.user.name }} {{task.user.lastname }} </p> <p> Estatus: {{ task.status }} </p> '
	};
});
