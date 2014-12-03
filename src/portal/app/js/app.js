'use strict';

angular.module('taskApp', [
	'ui.router',
	'taskApp.controllers',
	'taskApp.filters',
	'taskApp.directives',
	'toaster'
])
.config(function($stateProvider, $urlRouterProvider) {
	
	// For unmatch url, we set an default redirect
	$urlRouterProvider.otherwise("/taskList");

	$stateProvider
		.state('taskList' , {
			url:'/taskList',
			templateUrl: 'partials/tasklist.html'
		})
		.state('taskCreate' , {
			url:'/taskCreate',
			templateUrl: 'partials/taskcreate.html'
		})
		.state('userList' , {
			url:'/userList',
			templateUrl: 'partials/userlist.html'
		})
		.state('userCreate' , {
			url:'/userCreate',
			templateUrl: 'partials/usercreate.html'
		})
	})
