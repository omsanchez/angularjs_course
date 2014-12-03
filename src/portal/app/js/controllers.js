'use strict';

/* Controllers */

angular.module('taskApp.controllers', [])

.controller('AppCtrl', function(){
	
})

.controller('TaskCtrl', function($scope, $location, toaster, $http, $q){

	$scope.statusFilter = "Todas";

	$scope.loadingData = false;

	var editedTask = {
		'description': '',
		'assigned': {
			'id': '',
			'name': ''
		}
	};

	$scope.addTask = function(){
		toaster.pop('success', "Tarea creada", "La tarea ha sido creada correctamente");
		$location.path( "/taskList" );
	}

	function loadTask(){
		$scope.loadingData = true;
		var defer = $q.defer();
		$http
		.get('http://localhost:12547/api/Tasks')
		.success(function(data, status, headers, config){
			$scope.tasks = data;
			$scope.loadingData = false;
		})
		.error(function(){
			$scope.loadingData = false;
			console.log("Error...")
		})

	};

	loadTask();
})