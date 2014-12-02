'use strict';

/* Directives */


angular.module('taskApp.directives', [])
.directive('taskItem',  function() {
	return {
	  templateUrl: 'task-item.html'
	};
});
