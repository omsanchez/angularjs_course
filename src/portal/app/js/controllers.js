'use strict';

/* Controllers */

angular.module('taskApp.controllers', [])

.controller('AppCtrl', function(){
	
})

.controller('TaskCtrl', function($scope, $location, toaster){

	$scope.statusFilter = "Todas";

	$scope.tasks = [
		{
			'code': 'TSK01',
			'description' : 'Implementar la notificación de la creación de una borrador de reporte de falla',
			'user' : {
				'name': 'Beatriz',
				'lastname': 'Torres' 
			},
			'status': 'Planeada'
		},
		{
			'code': 'TSK02',
			'description' : 'Agregar la unidad de medida del número de parte',
			'user' : {
				'name': 'Alonso',
				'lastname': 'Roque' 
			},
			'status': 'En proceso'
		},
		{
			'code': 'TSK03',
			'description' : 'Implementar Envio de Cotización por parte del proveedor',
			'user' : {
				'name': 'Oscar',
				'lastname': 'Sánchez' 
			},
			'status': 'Completada'
		}
	];

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

})